using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadWriteSample
{
    class AppendAllLinesSample
    {
        public static void AppendAllLinesSampleCode()
        {
            string filePath = "output.txt";

            // 파일에 추가할 여러 줄
            string[] linesToAppend = {
            "네 번째 줄입니다.",
            "다섯 번째 줄입니다."
        };

            // 파일에 줄 추가
            File.AppendAllLines(filePath, linesToAppend);

            Console.WriteLine("추가된 내용이 파일에 작성되었습니다.");
        }
    }
}
