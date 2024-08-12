using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ClipboardTest2
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            string imagePath = "C:\\Users\\c\\Downloads\\test.png"; // 복사할 PNG 이미지의 경로를 입력하세요
            try
            {
                // 이미지를 로드하여 클립보드에 복사
                using (Image image = Image.FromFile(imagePath))
                {
                    Clipboard.SetImage(image);
                    Console.WriteLine("이미지가 클립보드에 복사되었습니다.");
                }

                // 클립보드에서 이미지 붙여넣기
                if (Clipboard.ContainsImage())
                {
                    Image imageFromClipboard = Clipboard.GetImage();
                    Console.WriteLine("클립보드에서 이미지를 가져왔습니다.");

                    // 이미지를 PNG 형식으로 저장하여 확인할 수 있습니다.
                    string outputPath = "C:\\Users\\c\\Downloads\\result.png";
                    imageFromClipboard.Save(outputPath, System.Drawing.Imaging.ImageFormat.Png);
                    Console.WriteLine("가져온 이미지를 저장했습니다: " + outputPath);
                }
                else
                {
                    Console.WriteLine("클립보드에 이미지가 없습니다.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("이미지를 처리하는 도중 문제가 발생했습니다:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
