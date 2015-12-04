using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamlCompileIssue.View.Control
{
    public partial class SelectionTabItem : ContentView
    {
        public SelectionTabItem()
        {
            InitializeComponent();
            this.IsSelected = false;
        }

        public static BindableProperty IconProperty = BindableProperty.Create<SelectionTabItem, ImageSource>(ctrl => ctrl.Icon,
            defaultValue: null, defaultBindingMode: BindingMode.Default,
            propertyChanging: (bindable, oldValue, newValue) => ((SelectionTabItem)bindable).Icon = newValue);

        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set
            {
                SetValue(IconProperty, value);
                this.uxIcon.Source = value;
            }
        }

        public static BindableProperty TitleProperty = BindableProperty.Create<SelectionTabItem, string>(ctrl => ctrl.Title,
            defaultValue: null, defaultBindingMode: BindingMode.TwoWay,
            propertyChanging: (bindable, oldValue, newValue) => ((SelectionTabItem)bindable).Title = newValue);

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set
            {
                SetValue(TitleProperty, value);
                this.uxTitle.Text = value;
            }
        }

        public static BindableProperty IsSelectedProperty = BindableProperty.Create<SelectionTabItem, bool>(ctrl => ctrl.IsSelected,
            defaultValue: false, defaultBindingMode: BindingMode.Default,
            propertyChanging: (bindable, oldValue, newValue) => ((SelectionTabItem)bindable).IsSelected = newValue);

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set
            {
                SetValue(IsSelectedProperty, value);
                this.BackgroundColor = value ? (Color)this.Resources["TabSelectedColor"] : (Color)this.Resources["TabNotSelectedColor"];
            }
        }

        public static BindableProperty ValueProperty = BindableProperty.Create<SelectionTabItem, object>(ctrl => ctrl.Value,
            defaultValue: null, defaultBindingMode: BindingMode.Default,
            propertyChanging: (bindable, oldValue, newValue) => ((SelectionTabItem)bindable).Value = newValue);

        public object Value
        {
            get { return GetValue(ValueProperty); }
            set
            {
                SetValue(ValueProperty, value);
                uxTapGesture.CommandParameter = value;
            }
        }

        public event EventHandler Tapped
        {
            add { this.uxTapGesture.Tapped += value; }
            remove { this.uxTapGesture.Tapped -= value; }
        }
    }
}
