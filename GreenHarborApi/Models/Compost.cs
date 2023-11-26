using System.ComponentModel.DataAnnotations;

namespace GreenHarborApi.Models
{
  public class Compost
  {
    public int CompostId { get; set; }
    // [Required]
    public string Zip { get; set; }
    public string City { get; set; }
    public string Location { get; set; }
    // [Required]
    public string ContactName { get; set; }
    [DataType(DataType.PhoneNumber)]
    public string ContactPhone { get; set; }
    [DataType(DataType.EmailAddress)]
    public string ContactEmail { get; set; }
    public string Contents { get; set; }
  }
}