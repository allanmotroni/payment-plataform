namespace PaymentPlataform.Services.Authorizers;

public interface IAuthorizerService 
{
    Task<bool> AuthorizerAsync();
}
