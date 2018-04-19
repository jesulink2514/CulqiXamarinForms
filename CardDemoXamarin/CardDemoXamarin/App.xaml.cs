using CardDemoXamarin.Culqi;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CardDemoXamarin
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new CardDemoXamarin.MainPage();
		}

        private static readonly Lazy<ICulqiService> culqiService = new Lazy<ICulqiService>(CreateCulqiService);

        private static ICulqiService CreateCulqiService()
        {
            //TODO:PUT YOUR APIKEY HERE
            const string culqiApiKey = "pk_xxxxxxx_live_test_etc";

            var culquiSettings = new RefitSettings()
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(culqiApiKey)
            };

            return RestService.For<ICulqiService>("https://api.culqi.com", culquiSettings);
        }

        public static ICulqiService CulqiService => culqiService.Value;

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
