namespace CardDemoXamarin.Culqi
{
    public class CulqiPaymentRequest
    {
        public string card_number { get; set; }
        public string cvv { get; set; }
        public string expiration_month { get; set; }
        public string expiration_year { get; set; }
        public string email { get; set; }
    }
}
