



using System.ComponentModel.DataAnnotations;

namespace CalabashMedia.EmiEurope.Domain.Entities
{
    public class Region
    {
      [Column( "RegionId")]
      public int Id {get;set;}

      [Column("RegionName")]
      public string Name { get; set; }

      public bool Status { get; set; }
    }
}
