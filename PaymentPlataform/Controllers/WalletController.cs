using Microsoft.AspNetCore.Mvc;
using PaymentPlataform.Models.Requests;
using PaymentPlataform.Services.Wallets;

namespace PaymentPlataform.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _walletService.GetAsync();
            
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(WalletRequest request)
        {
            var result = await _walletService.ExecuteAsync(request);
            if(!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Created();
        }
    }
}
