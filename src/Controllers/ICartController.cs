using MovieReviewApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MovieReviewApi.Controllers
{
    public interface ICartController
    {
        Task<ActionResult<Cart>> GetCart(int cartId); // GET
        Task<ActionResult> AddTicketToCart(int cartId, Ticket ticket); // POST
        Task<ActionResult> RemoveTicketFromCart(int cartId, int ticketId); // DELETE
    }
}
