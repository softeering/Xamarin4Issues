using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;

namespace ADALIssue.View
{
	public partial class ADALTestPage : ContentPage
	{
		public const string Authority = "https://login.windows.net/expediacorp.onmicrosoft.com";
		public const string ResourceId = "https://expedientmobile-dev.azurewebsites.net";
		public const string ClientId = "You can ask for our client if needed";
		public const string RedirectUrl = "https://expedientmobile-dev.azurewebsites.net/login/done";

		public ADALTestPage()
		{
			InitializeComponent();
		}

		public object PlatformParameters { get; set; }

		public async void uxLoginButtonClicked(object sender, EventArgs args)
		{
			var param = this.PlatformParameters as IPlatformParameters;

			AuthenticationContext authContext = new AuthenticationContext(Authority);

			/*
				the following line makes the app crash when there is at least one item returned by the call TokenCache.ReadItems()...
				Was working before the update to Xamarin4

				Also tried different PCL profiles with no luck
					- portable45-net45+win8
					- portable45-net45+win8+wpa81
			*/

			var token = authContext.TokenCache.ReadItems().FirstOrDefault();

			if (token != null)
				await authContext.AcquireTokenSilentAsync(ResourceId, ClientId);
			else
				await authContext.AcquireTokenAsync(ResourceId, ClientId, new Uri(RedirectUrl), param);

			token = authContext.TokenCache.ReadItems().FirstOrDefault();
		}
	}
}
