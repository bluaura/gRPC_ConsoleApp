using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

class Program
{
    [STAThread]
    static void Main()
    {
        string imagePath = "path/to/your/image.png"; // 복사할 PNG 이미지의 경로를 입력하세요
        try
        {
            // 이미지를 로드하여 메모리 스트림에 저장
            using (Image image = Image.FromFile(imagePath))
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                byte[] pngBytes = memoryStream.ToArray();

                // 클립보드에 PNG 데이터 복사
                SetClipboardPng(pngBytes);
                Console.WriteLine("이미지가 클립보드에 PNG 형식으로 복사되었습니다.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("이미지를 클립보드에 복사하는 도중 문제가 발생했습니다:");
            Console.WriteLine(e.Message);
        }
    }

    private static void SetClipboardPng(byte[] pngBytes)
    {
        // 클립보드 열기
        if (!OpenClipboard(IntPtr.Zero))
        {
            throw new System.ComponentModel.Win32Exception();
        }

        try
        {
            // 클립보드를 비웁니다.
            if (!EmptyClipboard())
            {
                throw new System.ComponentModel.Win32Exception();
            }

            // 메모리 할당 및 데이터 복사
            IntPtr hGlobal = Marshal.AllocHGlobal(pngBytes.Length);
            Marshal.Copy(pngBytes, 0, hGlobal, pngBytes.Length);

            // PNG 데이터 포맷 설정
            IntPtr pngFormat = RegisterClipboardFormat("PNG");
            if (pngFormat == IntPtr.Zero)
            {
                throw new System.ComponentModel.Win32Exception();
            }

            // 클립보드에 데이터 설정
            if (SetClipboardData(pngFormat, hGlobal) == IntPtr.Zero)
            {
                throw new System.ComponentModel.Win32Exception();
            }
        }
        finally
        {
            CloseClipboard();
        }
    }

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool OpenClipboard(IntPtr hWndNewOwner);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool EmptyClipboard();

    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool CloseClipboard();

    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    private static extern IntPtr RegisterClipboardFormat(string lpszFormat);
}
