using PaymentPlataform.Models.Enums;

namespace PaymentPlataform.Models;

public class Wallet
{
    public int Id { get; set; }
    public string Fullname { get; set; }
    public string Document { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public decimal Balance { get; set; }
    public UserType UserType { get; set; }
    
    private Wallet() { }

    public Wallet(
        string fullName, 
        string document, 
        string email, 
        string password, 
        UserType userType, 
        decimal balance = 0)
    {
        Fullname = fullName;
        Document = document;
        Email = email;
        Password = password;
        UserType = userType;
        Balance = balance;
    }

    public void Debit(decimal value)
    {
        Balance -= value;
    }

    public void Credit(decimal value)
    {
        Balance += value;
    }
}

