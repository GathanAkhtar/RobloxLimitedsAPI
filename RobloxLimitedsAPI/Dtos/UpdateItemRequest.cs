namespace RobloxLimitedsAPI.Dtos
{
     public class UpdateItemRequest
     {
          public int Id { get; set; }
          public string Name { get; set; } = string.Empty;
          public string AssetType { get; set; } = string.Empty;
          public int Value { get; set; }
     }
}
