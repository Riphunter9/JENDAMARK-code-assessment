using System.ComponentModel.DataAnnotations;

namespace JENDAMARK_code_assessment.Data
{
    public class Device
    {
        [Key]
        public int DeviceID { get; set; }
        [Required]
        [MinLength(5,ErrorMessage ="Enter atleast 5 letters")]
        public string Name { get; set; }
        [Required]
        public int? DeviceType { get; set; }
    }
}

