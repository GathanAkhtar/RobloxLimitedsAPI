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

          [HttpPost]
          public async Task<ActionResult<GetItemsResponseDto>> AddItems(CreateItemRequest item)
          {
               var createdItems = await service.AddItemsAsync(item);
               return CreatedAtAction(nameof(GetLimiteds), new { id = createdItems.Id }, createdItems);
          }

          [HttpPut("{id}")]
          public async Task<ActionResult> UpdateItems(int id, UpdateItemRequest updateItem)
          {
               var updated = await service.UpdateItemsAsync(id, updateItem);
               return updated ? NoContent() : NotFound("Item with the following id is not found");
               // If update success, return no content (204), else print that
          }

          [HttpDelete("{id}")]
          public async Task<ActionResult> DeleteItems(int id)
          {
               {
                    var deleted = await service.DeleteItemsAsync(id);
                    return deleted ? NoContent() : NotFound("Item with the following id is not found");
                    // If delete success, return no content (204), else print that
               }
          }
     }
}
