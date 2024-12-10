using PaymentPlataform.Models;
using PaymentPlataform.Models.Responses;

namespace PaymentPlataform.Mappers
{
    public static class TransferMapper
    {
        public static TransferResponse ToTransferResponse(this Transfer transfer)
        {
            return new TransferResponse(
                transfer.Id, 
                transfer.Sender, 
                transfer.Receiver, 
                transfer.Value);
        }
    }
}
