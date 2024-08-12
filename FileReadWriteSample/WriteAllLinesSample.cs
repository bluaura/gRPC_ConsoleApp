using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadWriteSample
{
    class WriteAllLinesSample
    {
        public static void WriteAllLinesSampleCode()
        {
            string filePath = "output.txt";

            // 파일에 쓸 여러 줄
            string[] linesToWrite = {
            "첫 번째 줄입니다.",
            "두 번째 줄입니다.",
            "세 번째 줄입니다."
        };

            // 파일에 쓰기
            File.WriteAllLines(filePath, linesToWrite);

            Console.WriteLine("내용이 파일에 작성되었습니다.");
        }
    }
}
