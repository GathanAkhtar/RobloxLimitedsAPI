using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RobloxLimitedsAPI.Models;

namespace RobloxLimitedsAPI.Controllers
{
     // Sets the base URL route to /api/RobloxLimiteds
     [Route("api/[controller]")]
     [ApiController]
     public class RobloxLimitedsController : ControllerBase
     {
          // Static in-memory mock data source retained across requests
          static List<Items> item = new List<Items> {
               new Items { Id = 1, Name = "Transient Harmonica", AssetType = "Face", Value = 100 },
               new Items { Id = 2, Name = "Domino Crown", AssetType = "Hat", Value = 200 },
               new Items { Id = 3, Name = "Red SQL Bandana", AssetType = "Face", Value = 300 }
          };

          // Handles GET requests to fetch all limited items as JSON wrapped in HTTP 200 OK
          [HttpGet]
          public async Task<ActionResult<List<Items>>> GetLimiteds()
               => await Task.FromResult(Ok(item));
     }
}
