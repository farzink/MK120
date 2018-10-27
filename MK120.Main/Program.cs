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
            //var result = board.CheckMove(0, 1, 1, 2);
            //Console.WriteLine(result);
            //if (board.IsValidMove(0, 1, 2, 2))
            //{
            //    board.Move(0, 1, 2, 2);
            //}
            ConsoleBoardDrawer cbd = new ConsoleBoardDrawer(new ConsoleColorHelper());

            Console.WriteLine("Press a ket to start");
            int x = 3;
            int y = 3;
            var key = new ConsoleKeyInfo
            {

            };
            Field f = null;
            int px = 3;
            int py = 3;
            while (key.Key != ConsoleKey.Escape)
            {
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.NumPad8)                
                    if (y > 0)
                        y -= 1;
                if (key.Key == ConsoleKey.NumPad7)
                    if (y > 0)
                    {
                        y -= 1;
                        x -= 1;
                    }
                if (key.Key == ConsoleKey.NumPad5)
                    if (y > 0)
                    {
                        y = 3;
                        x = 3;
                    }
                if (key.Key == ConsoleKey.NumPad9)
                    if (y > 0)
                    {
                        y -= 1;
                        x += 1;
                    }
                if (key.Key == ConsoleKey.NumPad2)
                    if (y < 7)
                        y += 1;
                if (key.Key == ConsoleKey.NumPad3)
                    if (y > 0)
                    {
                        y += 1;
                        x += 1;
                    }
                if (key.Key == ConsoleKey.NumPad6)
                    if (x < 7)
                        x += 1;
                if (key.Key == ConsoleKey.NumPad4)
                    if (x > 0)
                        x -= 1;
                if (key.Key == ConsoleKey.NumPad1)
                    if (y > 0)
                    {
                        y += 1;
                        x -= 1;
                    }
                if (key.Key == ConsoleKey.NumPad0)
                    f = null;
                if (key.Key == ConsoleKey.Enter)
                {
                    if(f == null)
                    {
                        var field = board.GetFieldAt(y, x);
                        if (field.IsOccupied())
                        {
                            f = field;
                            px = x;
                            py = y;
                        }
                    }
                    else
                    {
                        var field = board.GetFieldAt(x, y);
                        if (!field.IsOccupied())
                        {
                            board.SetFieldAt(y, x, f.Piece);
                            board.EmptyField(py, px);
                            f = null;
                        }
                    }
                }                            
                cbd.drawBoard(board, x, y);

            }
        }
    }
}
