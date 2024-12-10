using System.ComponentModel.DataAnnotations;

namespace PaymentPlataform.Models.Requests;

public record TransferRequest(
    [Required(ErrorMessage = "Value is required")] decimal Value,
    [Required(ErrorMessage = "Sender Id is required")] int SenderId,
    [Required(ErrorMessage = "Receiver Id is required")] int ReceiverId);