namespace PaymentPlataform.Models.Responses;

public record WalletResponse(
    int id,
    string FullName,
    string Document,
    string Email,
    string UserType,
    decimal balance);

