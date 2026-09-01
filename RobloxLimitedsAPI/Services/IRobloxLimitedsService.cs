using RobloxLimitedsAPI.Dtos;
using RobloxLimitedsAPI.Models;

namespace RobloxLimitedsAPI.Services
{
     public interface IRobloxLimitedsService
     {
          // Fetches and returns all items asynchronously as a list
          Task<List<GetItemsResponseDto>> GetAllItemsAsync();

          // Fetches a single item by ID, or returns null if not found
          Task<GetItemsResponseDto?> GetItemsByIdAsync(int id);

          // Adds a new item and returns the newly created item
          Task<GetItemsResponseDto> AddItemsAsync(CreateItemRequest item);

          // Updates an existing item by ID and returns true if successful, false if not found
          Task<bool> UpdateItemsAsync(int id, UpdateItemRequest item);

          // Removes an item by ID and returns true if deleted, false if not found
          Task<bool> DeleteItemsAsync(int id);
     }
}
