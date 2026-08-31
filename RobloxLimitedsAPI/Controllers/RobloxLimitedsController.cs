using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RobloxLimitedsAPI.Dtos;
using RobloxLimitedsAPI.Models;
using RobloxLimitedsAPI.Services;

namespace RobloxLimitedsAPI.Controllers
{
     // Sets the base URL route to /api/RobloxLimiteds
     [Route("api/[controller]")]
     [ApiController]
     public class RobloxLimitedsController(IRobloxLimitedsService service) : ControllerBase
     {

          // Handles GET requests to fetch all limited items as JSON wrapped in HTTP 200 OK
          [HttpGet]
          public async Task<ActionResult<List<GetItemsResponseDto>>> GetLimiteds()
               => Ok(await service.GetAllItemsAsync());
          
          [HttpGet("{id}")]
          public async Task<ActionResult<Items>> GetItemsById(int id)
          {
               var item = await service.GetItemsByIdAsync(id);
               if (item is null)
                    return NotFound("Item not found");
               return Ok(item);
          }
     }
}
