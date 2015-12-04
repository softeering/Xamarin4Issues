using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamlCompileIssue.ViewModel;

namespace XamlCompileIssue.View
{
	public partial class CustomControl : ContentPage
	{
		public CustomControl()
		{
			InitializeComponent();
			this.BindingContext = new CustomControlViewModel();
		}
	}
}
