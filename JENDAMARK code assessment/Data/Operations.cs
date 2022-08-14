using System.ComponentModel.DataAnnotations;

namespace JENDAMARK_code_assessment.Data
{
    public class Operations
    {
        [Key]
        public int OperationID { get; set; }
        [Required(ErrorMessage = "Enter an operation name")]
        public string Name { get; set; }
        [Required]
        [Range(1,9999999, ErrorMessage = "Enter a number")]
        [Display(Name="Operation Order")]
        public int OrderInWhichToPerform { get; set; }
        public byte[] ImageData { get; set; }
        [Required(ErrorMessage ="Select a Device")]
        [Display(Name="Device")]
        public int? DeviceID { get; set; }
        public Device Device { get; set; }
    }
   
}
