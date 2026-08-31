using Microsoft.EntityFrameworkCore;
using RobloxLimitedsAPI.Data;
using RobloxLimitedsAPI.Dtos;
using RobloxLimitedsAPI.Models;

namespace RobloxLimitedsAPI.Services
{
     public class RobloxLimitedsService(AppDbContext context) : IRobloxLimitedsService
     {

          public Task<GetItemsResponseDto> AddItemsAsync(Items item)
          {
               throw new NotImplementedException();
          }

          public Task<bool> DeleteItemsAsync(int id)
          {
               throw new NotImplementedException();
          }

          public async Task<List<GetItemsResponseDto>> GetAllItemsAsync()
               => await context.Items.Select(c => new GetItemsResponseDto
               {
                    Name = c.Name,
                    AssetType = c.AssetType,
                    Value = c.Value
               }).ToListAsync();

          public async Task<GetItemsResponseDto?> GetItemsByIdAsync(int id)
          {
               var result = await context.Items
                    .Where(c => c.Id == id)
                    .Select(c => new GetItemsResponseDto
                    {
                         Name = c.Name,
                         AssetType = c.AssetType,
                         Value = c.Value
                    })
                    .FirstOrDefaultAsync();
               
               return result;
          }

          public Task<bool> UpdateItemsAsync(int id, Items item)
          {
               throw new NotImplementedException();
          }
     }
}
