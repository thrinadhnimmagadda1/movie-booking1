using Microsoft.AspNetCore.Mvc;
using MovieReviewApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase, ICartController
{
    // private readonly ApplicationDbContext _context;
    // public CartController(ApplicationDbContext context)
    // {
    //     _context = context;
    // }

    // In-memory list for carts ~ temporary
    private List<Cart> carts = new List<Cart>();

    // GET: api/cart/{cartId}
    [HttpGet("{cartId}")]
    public async Task<ActionResult<Cart>> GetCart(int cartId)
    {
        // var cart = await _context.Carts
        //     .Include(c => c.Tickets)
        //     .FirstOrDefaultAsync(c => c.Id == cartId);
        // if (cart == null)
        // {
        //     cart = new Cart { Id = cartId, Tickets = new List<Ticket>(), TotalAmount = 0 };
        //     _context.Carts.Add(cart);
        //     await _context.SaveChangesAsync();
        // }
        // return Ok(cart);

        // In-memory list for carts ~ temporary
        var cart = carts.FirstOrDefault(c => c.Id == cartId);
        if (cart == null)
        {
            cart = new Cart { Id = cartId, Tickets = new List<Ticket>(), TotalAmount = 0 };
            carts.Add(cart);
        }
        return Ok(cart);
    }

    // POST: api/cart/add
    [HttpPost("add")]
    public async Task<ActionResult> AddTicketToCart(int cartId, Ticket ticket)
    {
        if (ticket == null)
        {
            return BadRequest(new { Message = "Invalid ticket data provided" }); // 400 Bad Request
        }

        // var cart = await _context.Carts
        //     .Include(c => c.Tickets)
        //     .FirstOrDefaultAsync(c => c.Id == cartId);
        // if (cart == null)
        // {
        //     cart = new Cart { Id = cartId, Tickets = new List<Ticket>(), TotalAmount = 0 };
        //     _context.Carts.Add(cart);
        // }
        // cart.Tickets.Add(ticket);
        // cart.TotalAmount += ticket.Price;
        // await _context.SaveChangesAsync(); // Save changes to the database
        // return Ok(new { Message = "Ticket added to cart successfully", Cart = cart });

        // In-memory list for carts ~ temporary
        var cart = carts.FirstOrDefault(c => c.Id == cartId);
        if (cart == null)
        {
            cart = new Cart { Id = cartId, Tickets = new List<Ticket>(), TotalAmount = 0 };
            carts.Add(cart);
        }
        cart.Tickets.Add(ticket);
        cart.TotalAmount += ticket.Price;

        return Ok(new { Message = "Ticket added to cart successfully", Cart = cart });
    }

    // PUT: api/cart/remove
    [HttpPut("remove")]
    public async Task<ActionResult> RemoveTicketFromCart(int cartId, int ticketId)
    {
        // var cart = await _context.Carts
        //     .Include(c => c.Tickets)
        //     .FirstOrDefaultAsync(c => c.Id == cartId);
        // if (cart == null)
        // {
        //     return NotFound(new { Message = "Cart not found" }); // 404 Not Found
        // }
        // var ticket = cart.Tickets.FirstOrDefault(t => t.Id == ticketId);
        // if (ticket == null)
        // {
        //     return NotFound(new { Message = "Ticket not found in cart" }); // 404 Not Found
        // }
        // cart.Tickets.Remove(ticket);
        // cart.TotalAmount -= ticket.Price;
        // await _context.SaveChangesAsync(); // Save changes to the database
        // return Ok(new { Message = "Ticket removed from cart successfully", Cart = cart });

        // In-memory list for carts ~ temporary
        var cart = carts.FirstOrDefault(c => c.Id == cartId);
        if (cart == null)
        {
            return NotFound(new { Message = "Cart not found" });
        }

        var ticket = cart.Tickets.FirstOrDefault(t => t.Id == ticketId);
        if (ticket == null)
        {
            return NotFound(new { Message = "Ticket not found in cart" });
        }

        cart.Tickets.Remove(ticket);
        cart.TotalAmount -= ticket.Price;

        return Ok(new { Message = "Ticket removed from cart successfully", Cart = cart });
    }
}
