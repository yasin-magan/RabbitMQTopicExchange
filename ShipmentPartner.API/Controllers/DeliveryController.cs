using CargoShipment.Currier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CargoShipment.Currier.Models;

namespace ShipmentPartner.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly ShipmentContext _context;

        //private readonly IDeliveryRegionService _deliveryRegionService;
        public DeliveryController(ShipmentContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();

            //deliveryRegionService.DeliverToRegion();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllDleivery()
        {
            return Ok(await _context.Deliverys.ToArrayAsync());
        }
        [HttpPost]
        public async Task<ActionResult<Delivery>> PostDelivery(Delivery delivery)
        {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
           
            _context.Deliverys.Add(delivery);
            await _context.SaveChangesAsync();
            return CreatedAtAction(
                "GetDelivery",
                new { id = delivery.Id },
                delivery);
        }
       
        [HttpGet("{id}")]
        public async Task<ActionResult> GetDelivery(int id)
        {
            var delivery = await _context.Deliverys.FindAsync(id);
            if (delivery == null)
            {
                return NotFound();
            }
            return Ok(delivery);
        }
    }
}