namespace RobloxLimitedsAPI.Dtos
{
     public class CreateItemRequest
     {
          public string Name { get; set; } = string.Empty;
          public string AssetType { get; set; } = string.Empty;
          
          public int Value { get; set; }
     }
}
