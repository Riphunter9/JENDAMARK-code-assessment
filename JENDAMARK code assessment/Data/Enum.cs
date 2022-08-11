using System.ComponentModel.DataAnnotations;

namespace JENDAMARK_code_assessment.Data
{
   public enum DeviceType
    {
        [Display(Name ="Barcode Scanner")]
        BarcodeScanner,
        Printer,
        Camera,
        [Display(Name = "Socket Tray")]
        SocketTray
    }
}
