namespace PaymentPlataform.Models
{
    public class Transfer
    {
        public Guid Id { get; set; }

        public int SenderId { get; set; }
        public Wallet Sender { get; set; }

        public int ReceiverId { get; set; }
        public Wallet Receiver { get; set; }

        public decimal Value { get; set; }

        private Transfer() { }

        public Transfer(
            int senderId, 
            int receiverId, 
            decimal value)
        {
            Id = Guid.NewGuid();
            SenderId = senderId;
            ReceiverId = receiverId;
            Value = value;
        }
    }
}
