using Microsoft.AspNetCore.Mvc;
using PaymentPlataform.Models.Requests;
using PaymentPlataform.Services.Transfers;

namespace PaymentPlataform.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;

        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(TransferRequest request)
        {
            var result = await _transferService.ExecuteAsync(request);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
