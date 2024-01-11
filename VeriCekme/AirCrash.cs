using System.ComponentModel.DataAnnotations;

namespace VeriCekme
{
    public class AirCrash
    {
        [Key]
        public int AirCrashId { get; set; }
        public DateTime? Date { get; set; }
        public string? AircraftType { get; set; }
        public string? Operator { get; set; }
        public string? Fatalities { get; set; }
        public string? Location { get; set; }
        public string? Country { get; set; }
        public string? Status { get; set; }
    }

}
