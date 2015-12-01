using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;

namespace ADALIssue
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Label {
                            XAlign = TextAlignment.Center,
                            Text = "Welcome to Xamarin Forms!"
                        }
                    }
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts

            try
            {
                AuthenticationContext authContext = new AuthenticationContext("https://login.windows.net/expediacorp.onmicrosoft.com");
                var tokens = authContext.TokenCache.ReadItems().ToArray();
                Debug.WriteLine("Tokens read");
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.ToString());
                throw exc;
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
