using BookStore.Models.DataTransferObjects;
using BookStore.Models.Interfaces;
using BookStore.Utility.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentsController(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDto>>> GetAllPayments()
        {
            var payments = await _paymentRepository.GetAllPaymentsAsync();
            return Ok(payments.Select(p => _mapper.MapPaymentToPaymentDto(p)));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDto>> GetPaymentById(int id)
        {
            var payment = await _paymentRepository.GetPaymentByIdAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            return Ok(_mapper.MapPaymentToPaymentDto(payment));
        }

        [HttpPost]
        public async Task<ActionResult<PaymentDto>> CreatePayment(PaymentDto paymentDto)
        {
            var payment = _mapper.MapPaymentDtoToPayment(paymentDto);
            await _paymentRepository.CreatePaymentAsync(payment);

            return CreatedAtAction("GetPaymentById", new { id = payment.payment_id }, _mapper.MapPaymentToPaymentDto(payment));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment(int id, PaymentDto paymentDto)
        {
            if (id != paymentDto.PaymentId)
            {
                return BadRequest();
            }

            var payment = _mapper.MapPaymentDtoToPayment(paymentDto);
            await _paymentRepository.UpdatePaymentAsync(payment);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            await _paymentRepository.DeletePaymentAsync(id);
            return NoContent();
        }
    }
}