using PaymentPlataform.Models.Enums;
using PaymentPlataform.Utils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PaymentPlataform.Models.Requests
{
    public class WalletRequest
    {
        [Required(ErrorMessage = "Fullname is required")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Document is required")]
        [CpfCnpjValidation(ErrorMessage = "Document invalid")]
        public string Document { get; set; }

        [Required(ErrorMessage = "E-mail is required")]
        [EmailAddress(ErrorMessage = "E-mail not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "User type is required")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UserType UserType { get; set; }

        [Required(ErrorMessage = "Wallet balance is required")]
        public decimal Balance { get; set; }
    }
}
