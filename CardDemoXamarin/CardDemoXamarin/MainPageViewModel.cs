using CardDemoXamarin.Culqi;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Xamarin.Forms;

namespace CardDemoXamarin
{
    public class MainPageViewModel: BindableObject
    {
        private readonly ICulqiService _culqiService;
        private string _cardNumber;
        private string _expiration;
        private string _cvc;

        public MainPageViewModel(ICulqiService culqiService)
        {
            _culqiService = culqiService;
            PayCommand = new Command(Pay);
        }

        public MainPageViewModel():this(App.CulqiService)
        {
        }

        public string CardNumber
        {
            get => _cardNumber;
            set
            {
                _cardNumber = value;
                OnPropertyChanged();
            }
        }

        public string Expiration
        {
            get => _expiration;
            set { _expiration = value; OnPropertyChanged();}
        }

        public string CVC
        {
            get => _cvc;
            set { _cvc = value; OnPropertyChanged();}
        }

        public ICommand PayCommand { get;}


        private async void Pay(object obj)
        {
            var req = new CulqiPaymentRequest()
            {
                card_number = CardNumber?.Replace(" ",string.Empty)?.Normalize(),
                email = "sample@email.com",
                cvv = CVC?.Normalize(),
                expiration_month = Expiration?.Split('/')[0],
                expiration_year = GetYear(Expiration)
            };

            var resp = await _culqiService.CreateToken(req,CancellationToken.None);

            await App.Current.MainPage.DisplayAlert(resp.IsSuccessStatusCode?"Response": "Error", await resp.Content.ReadAsStringAsync(), "Ok");
        }

        public static string GetYear(this string expiration)
        {
            var twoParts = expiration.Split('/');
            var years = int.Parse(twoParts[1]);
            var milleniumPart = DateTime.Now.Year / 1000f;
            var year = Math.Floor(milleniumPart) * 1000;
            var currentYear = year + years;
            return currentYear.ToString(CultureInfo.InvariantCulture);
        }
    }
}
