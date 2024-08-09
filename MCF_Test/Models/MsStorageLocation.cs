using System.ComponentModel.DataAnnotations;

namespace MCF_Test.Models
{
    public class MsStorageLocation
    {
        [Key]
        public string LocationId { get; set; }
        public string LocationName { get; set; }
    }
}
