using RobloxLimitedsAPI.Models;

namespace RobloxLimitedsAPI.Services
{
     public class RobloxLimitedsService : IRobloxLimitedsService
     {
          static List<Items> item = new List<Items> {
               new Items { Id = 1, Name = "Transient Harmonica", AssetType = "Face", Value = 100 },
               new Items { Id = 2, Name = "Domino Crown", AssetType = "Hat", Value = 200 },
               new Items { Id = 3, Name = "Red SQL Bandana", AssetType = "Face", Value = 300 },
               new Items { Id = 4, Name = "Bighead", AssetType = "Hat", Value = 100 }
          };
          public Task<Items> AddItemsAsync(Items item)
          {
               throw new NotImplementedException();
          }

          public Task<bool> DeleteItemsAsync(int id)
          {
               throw new NotImplementedException();
          }

          public async Task<List<Items>> GetAllItemsAsync()
               => await Task.FromResult(item);

          public async Task<Items?> GetItemsByIdAsync(int id)
          {
               var result = item.FirstOrDefault(i => i.Id == id);
               return await Task.FromResult(result);
          }

          public Task<bool> UpdateItemsAsync(int id, Items item)
          {
               throw new NotImplementedException();
          }
     }
}
