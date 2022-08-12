using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JENDAMARK_code_assessment.Data
{
   public enum DeviceType
    {
        [Description("Barcode Scanner")]
        BarcodeScanner,
        Printer,
        Camera,
        [Description("Socket Tray")]
        SocketTray
    }
}
