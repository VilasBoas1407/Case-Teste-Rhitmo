using Api.Domain.Enum;
using Newtonsoft.Json;

namespace Api.Domain.Model
{

    public class InsertUserModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("cpf")]
        public string CPF { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }
        [JsonProperty("paymentType")]
        public PaymentType PaymentType { get; set; }
        [JsonProperty("cardName")]
        public string CardName { get; set; }
        [JsonProperty("cardNumber")]
        public string CardNumber { get; set; }
        [JsonProperty("cardSafeCode")]
        public int CardSafeCode { get; set; }
        [JsonProperty("monthExpiration")]
        public int MonthExpiration { get; set; }
        [JsonProperty("yearExpiration")]
        public int YearExpiration{get;set;}

    }
}
