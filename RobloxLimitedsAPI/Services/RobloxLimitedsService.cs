using Microsoft.EntityFrameworkCore;
using RobloxLimitedsAPI.Data;
using RobloxLimitedsAPI.Dtos;
using RobloxLimitedsAPI.Models;

namespace RobloxLimitedsAPI.Services
{
     public class RobloxLimitedsService(AppDbContext context) : IRobloxLimitedsService
     {
          // Converts the incoming DTO into a database entity, saves it to SQL Server, and returns the saved item as a DTO
          public async Task<GetItemsResponseDto> AddItemsAsync(CreateItemRequest item)
          {
               var newItems = new Items
               {
                    Name = item.Name,
                    AssetType = item.AssetType,
                    Value = item.Value
               };
               
               context.Items.Add(newItems);
               await context.SaveChangesAsync();

               return new GetItemsResponseDto
               {
                    Id = newItems.Id,
                    Name = newItems.Name,
                    AssetType = newItems.AssetType,
                    Value = newItems.Value
               };
          }

          public async Task<bool> DeleteItemsAsync(int id)
          {
               var ItemtoDelete = await context.Items.FindAsync(id);
               if (ItemtoDelete is null) 
               return false;
               
               context.Items.Remove(ItemtoDelete);
               await context.SaveChangesAsync();
               return true;
          }

          public async Task<List<GetItemsResponseDto>> GetAllItemsAsync()
               => await context.Items.Select(c => new GetItemsResponseDto
               {
                    Id = c.Id,
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

          public async Task<bool> UpdateItemsAsync(int id, UpdateItemRequest item)
          {
               var existingItem = await context.Items.FindAsync(id);
               if (existingItem is null) return false;

               existingItem.Name = item.Name;
               existingItem.AssetType = item.AssetType;
               existingItem.Value = item.Value;

               await context.SaveChangesAsync();
               return true;
          }
     }
}
