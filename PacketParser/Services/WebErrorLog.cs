using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Mime;
using System.Threading;
using System.Windows.Forms;

namespace PacketParser.Services
{
   public class WebErrorLog
    {
        public WebErrorLog()
        {

        }
       
        public void StartErrorLog(Exception ex, string _description = "",
            [System.Runtime.CompilerServices.CallerMemberName]
            string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath]
            string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber]
            int sourceLineNumber = 0)
        {
            var fileInfo = new FileInfo(sourceFilePath);
            var className = fileInfo.Name;
            var funcName = memberName;
            var time = DateTime.Now.ToLongTimeString();
            var exceptionType = ex.GetType().ToString();
            var exceptionMessage = ex.Message;
            var description = _description;


            var msg = $"Version:{System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}" + "\r\n" +
                      $"ClassName:{className}" + "\r\n" +
                      $"FunctionName:{funcName}" + "\r\n" +
                      $"Time:{time}" + "\r\n" +
                      $"Type:{exceptionType}" + "\r\n" +
                      $"Message:{exceptionMessage}" + "\r\n" +
                      $"Description:{description}";

            var fileName = GetScreenShot();
            var th = new Thread(() => SendErrorToTelegram.Send.StartSending(msg, fileName));
            th.Start();
        }
        private class NestedCallInfo
        {
            internal static WebErrorLog _instence = new WebErrorLog();

            public NestedCallInfo()
            {
            }
        }

        public static WebErrorLog ErrorInstence => NestedCallInfo._instence;

        private static string GetScreenShot()
        {
            var address = "";
            try
            {
                var folder = Path.Combine(Application.StartupPath, "ScreenShot");
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
                var printScreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                var graphic = Graphics.FromImage(printScreen as Image);
                graphic.CopyFromScreen(0, 0, 0, 0, printScreen.Size);
                var path = Path.Combine(folder, Guid.NewGuid() + ".png");
                printScreen.Save(path, ImageFormat.Png);
                address = path;
            }
            catch
            {
                address = "";
            }

            return address;
        }
    }
}
