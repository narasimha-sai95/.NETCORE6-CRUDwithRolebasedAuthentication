using Cards.API.Data;
using Cards.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cards.API;

namespace Cards.API.Controllers
{
    [Authorize(Roles =UserRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
 
    public class CardsController : ControllerBase
    {
        private readonly CardsDbContext cardsDbContext;
       

       
        public CardsController(CardsDbContext cardsDbContext)
        {
            this.cardsDbContext = cardsDbContext;
        }
       
        

        //Get All Cards
        [HttpGet]

        public async Task<IActionResult> GetAllCards()
        {
            var cards = await cardsDbContext.Cards.ToListAsync();
            return Ok(cards);
        }
        
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetCard")]
        public async Task<IActionResult> GetCard([FromRoute] Guid id)
        {
            var card= await cardsDbContext.Cards.FirstOrDefaultAsync(x=>x.Id==id);

            if (card == null)
            {
                return NotFound("Card not found");
            }
            return Ok(card);
        }

        [HttpPost]
        //add a card
        public async Task<IActionResult> AddCards([FromBody] Card c)
        {
            c.Id = Guid.NewGuid();
            await cardsDbContext.Cards.AddAsync(c);
            await cardsDbContext.SaveChangesAsync();
            // var cards = await cardsDbContext.Cards.ToListAsync();
            return CreatedAtAction(nameof(GetCard), new {id=c.Id }, c);
        }



        //Updating a Card
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCard([FromRoute] Guid id, [FromBody] Card c)
        {
            var exisitingcard = await cardsDbContext.Cards.FirstOrDefaultAsync(x => x.Id == id);

            if(exisitingcard != null)
            {
                exisitingcard.CardholderName=c.CardholderName;
                exisitingcard.CardNumber = c.CardNumber;
                exisitingcard.ExpiryMonth = c.ExpiryMonth;
                exisitingcard.ExpiryYear = c.ExpiryYear;
                exisitingcard.CVV = c.CVV;
                await cardsDbContext.SaveChangesAsync();
                return Ok(exisitingcard);

            }

            return NotFound("Card not found");
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCard([FromRoute] Guid id)
        {
            var exisitingcard = await cardsDbContext.Cards.FirstOrDefaultAsync(x => x.Id == id);

            if (exisitingcard != null)
            {
                cardsDbContext.Remove(exisitingcard);
                await cardsDbContext.SaveChangesAsync();
                return Ok(exisitingcard);

            }

            return NotFound("Card not found");
        }




    }
}
