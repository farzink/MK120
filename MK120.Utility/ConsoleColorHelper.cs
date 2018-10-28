using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK120.Utility
{
    public class ConsoleColorHelper
    {
        public void ForeRed()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        public void ForeWhite()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ResetFore()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        

        public void BackGray()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
        }
        public void BackGreen()
        {
            Console.BackgroundColor = ConsoleColor.Green;
        }
        public void BackYellow()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
        }
        public void BackBlue()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
        }
        public void BackReset()
        {
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
