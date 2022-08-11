using System.ComponentModel.DataAnnotations;

namespace JENDAMARK_code_assessment.Data
{
    public class Device
    {
        [Key]
        public int DeviceID { get; set; }
        [Required]
        public string Name { get; set; }
        public int DeviceType { get; set; }
    }
}

