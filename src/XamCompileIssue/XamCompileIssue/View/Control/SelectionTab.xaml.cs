using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;

namespace XamlCompileIssue.View.Control
{
	[ContentProperty("Items")]
	public partial class SelectionTab : Grid
	{
		public SelectionTab()
		{
			InitializeComponent();
			//this.ChildAdded += SelectionTab_ChildAdded;
			//this.ChildRemoved += SelectionTab_ChildRemoved;
			//this.ChildrenReordered += SelectionTab_ChildrenReordered;
		}

		private void SelectionTab_ChildrenReordered(object sender, EventArgs e)
		{

		}

		private void SelectionTab_ChildRemoved(object sender, ElementEventArgs e)
		{
			this.Refresh();
		}

		private void SelectionTab_ChildAdded(object sender, ElementEventArgs e)
		{
			this.Refresh();
		}

		private SelectionTabItem[] _items;
		public SelectionTabItem[] Items
		{
			private get { return this._items; }
			set
			{
				this._items = value;
				this.Init();
			}
		}

		private void Init()
		{
			this.ColumnDefinitions.Clear();

			if (this.Items == null || this.Items.Count() < 1)
				return;

			foreach (SelectionTabItem item in this.Items)
			{
				this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
				item.Tapped -= OnItemTapped;
				item.Tapped += OnItemTapped;
				Grid.SetColumn(item, this.ColumnDefinitions.Count - 1);
				this.Children.Add(item);
			}
		}

		private void Refresh()
		{
			var columnCount = this.Children.Count;
			this.ColumnDefinitions.Clear();

			foreach (SelectionTabItem item in this.Children.OfType<SelectionTabItem>())
			{
				this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
				item.Tapped -= OnItemTapped;
				item.Tapped += OnItemTapped;
				Grid.SetColumn(item, this.ColumnDefinitions.Count - 1);
				this.Children.Add(item);
			}
		}

		private void OnItemTapped(object sender, EventArgs e)
		{
			var args = (TappedEventArgs)e;

			foreach (SelectionTabItem item in this.Children.OfType<SelectionTabItem>())
			{
				item.IsSelected = (item.Value == args.Parameter);
			}

			if (this.Command != null)
				this.Command.Execute(args.Parameter);
		}

		public static BindableProperty CommandProperty = BindableProperty.Create<SelectionTab, ICommand>(ctrl => ctrl.Command,
			defaultValue: null, defaultBindingMode: BindingMode.Default,
			propertyChanging: (bindable, oldValue, newValue) => ((SelectionTab)bindable).Command = newValue);

		public ICommand Command
		{
			get { return (ICommand)GetValue(CommandProperty); }
			set { SetValue(CommandProperty, value); }
		}
	}
}