using BookStore.Models.DataTransferObjects;
using BookStore.Models.Interfaces;
using BookStore.Utility.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMapper _mapper;

        public SubscriptionsController(ISubscriptionRepository subscriptionRepository, IMapper mapper)
        {
            _subscriptionRepository = subscriptionRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubscriptionDto>>> GetAllSubscriptions()
        {
            var subscriptions = await _subscriptionRepository.GetAllSubscriptionsAsync();
            return Ok(subscriptions.Select(s => _mapper.MapSubscriptionToSubscriptionDto(s)));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubscriptionDto>> GetSubscriptionById(int id)
        {
            var subscription = await _subscriptionRepository.GetSubscriptionByIdAsync(id);

            if (subscription == null)
            {
                return NotFound();
            }

            return Ok(_mapper.MapSubscriptionToSubscriptionDto(subscription));
        }

        [HttpPost]
        public async Task<ActionResult<SubscriptionDto>> CreateSubscription(SubscriptionDto subscriptionDto)
        {
            var subscription = _mapper.MapSubscriptionDtoToSubscription(subscriptionDto);
            await _subscriptionRepository.CreateSubscriptionAsync(subscription);

            return CreatedAtAction("GetSubscriptionById", new { id = subscription.subscription_id }, _mapper.MapSubscriptionToSubscriptionDto(subscription));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubscription(int id, SubscriptionDto subscriptionDto)
        {
            if (id != subscriptionDto.SubscriptionId)
            {
                return BadRequest();
            }

            var subscription = _mapper.MapSubscriptionDtoToSubscription(subscriptionDto);
            await _subscriptionRepository.UpdateSubscriptionAsync(subscription);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscription(int id)
        {
            await _subscriptionRepository.DeleteSubscriptionAsync(id);
            return NoContent();
        }
    }
}