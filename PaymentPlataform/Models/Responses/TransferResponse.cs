namespace PaymentPlataform.Models.Responses;

public record TransferResponse(
    Guid id, 
    Wallet Sender, 
    Wallet Receiver, 
    decimal value);
