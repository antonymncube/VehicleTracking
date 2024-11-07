using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fleet_Management_System.Models
{
    public class VehicleLocationResults
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string VehicleId { get; set; }   
        public decimal Latitude { get; set; }   
        public decimal Longitude { get; set; }   
        public DateTime Timestamp { get; set; }   
    }
}
