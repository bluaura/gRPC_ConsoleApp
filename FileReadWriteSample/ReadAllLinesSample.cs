using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadWriteSample
{
    class ReadAllLinesSample
    {
        public static void ReadAllLineSampleCode()
        {
            string filePath = "output.txt";

            // 파일의 모든 줄을 읽기
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                Console.WriteLine("파일에서 읽은 내용:");
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("파일이 존재하지 않습니다.");
            }
        }
    }
}
