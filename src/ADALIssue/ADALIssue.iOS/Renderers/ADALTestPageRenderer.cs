using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ADALIssue.View.ADALTestPage), typeof(ADALIssue.iOS.ADALTestPageRenderer))]
namespace ADALIssue.iOS
{
	public class ADALTestPageRenderer : PageRenderer
	{
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var page = this.Element as ADALIssue.View.ADALTestPage;
			if (page != null)
				page.PlatformParameters = new PlatformParameters(this);
		}
	}
}

