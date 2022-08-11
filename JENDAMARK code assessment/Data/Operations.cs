using System.ComponentModel.DataAnnotations;

namespace JENDAMARK_code_assessment.Data
{
    public class Operations
    {
        [Key]
        public int OperationID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int OrderInWhichToPerform { get; set; }
        public byte[] ImageData { get; set; }

        public int DeviceID { get; set; }
        public Device Device { get; set; }
    }
   
}
