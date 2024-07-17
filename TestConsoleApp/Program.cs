using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "C:\\Users\\c\\Downloads\\sample.txt"; // 읽고자 하는 텍스트 파일의 경로를 입력하세요

        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("파일을 읽는 도중 문제가 발생했습니다:");
            Console.WriteLine(e.Message);
        }
    }
}
