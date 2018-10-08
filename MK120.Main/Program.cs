using MK120.Model.models;
using MK120.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK120.Main
{
    class Program
    {
        static void Main(string[] args)
        {

            Board board = new Board();
            ConsoleBoardDrawer cbd = new ConsoleBoardDrawer(new ConsoleColorHelper());
            cbd.drawBoard(board);
        }
    }
}
