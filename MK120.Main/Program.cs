using MK120.Model.enums;
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
            var rx = 3;
            var ry = 3;
            Colors turn = Colors.White;
            while (key.Key != ConsoleKey.Escape)
            {                
                IList<String> messages = new List<String>();
                IList<CoordinatationPair> validMoves = null;
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.NumPad8)
                    if (y > 0)
                        y -= 1;
                if (key.Key == ConsoleKey.NumPad7)
                    if (y > 0 && x > 0)
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
                    if (y > 0 && x < 7)
                    {
                        y -= 1;
                        x += 1;
                    }
                if (key.Key == ConsoleKey.NumPad2)
                    if (y < 7)
                        y += 1;
                if (key.Key == ConsoleKey.NumPad3)
                    if (y < 7 && y < 7)
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
                    if (y < 7 && x > 0)
                    {
                        y += 1;
                        x -= 1;
                    }
                if (key.Key == ConsoleKey.NumPad0)
                    f = null;
                if (key.Key == ConsoleKey.Enter)
                {
                    if (f == null)
                    {
                        var field = board.GetFieldAt(y, x);
                        if (field.IsOccupied())
                        {
                            if (field.Piece.Color == turn)
                            {
                                f = field;
                                px = x;
                                py = y;
                                rx = x;
                                ry = y;
                            }
                            else
                            {
                                messages.Add("This is " + turn + " turn");
                            }
                        }
                        else
                        {
                            messages.Add("No piece at target, please select another target");
                        }
                    }
                    else
                    {
                        var field = board.GetFieldAt(y, x);
                        if (field.Piece == f.Piece)
                        {
                            messages.Add("The same target is chosen. please select another target!");
                        }
                        else
                        {
                            var isLegal = false;
                            validMoves = board.CalulateValidMoveForCurrentPiece(ry, rx, f.Piece);
                            foreach (var move in validMoves)
                            {
                                if (move.Y == y && move.X == x)
                                {
                                    isLegal = true;
                                    break;
                                }
                            }
                            if (isLegal)
                            {
                                int dx = Math.Abs(py - y);
                                int dy = Math.Abs(px - x);
                                if (!field.IsOccupied())
                                {
                                    var obstacle = false;
                                    if (dx > 1 || dy > 1)
                                    {
                                        obstacle = board.FindObstacle(x, y, px, py, f.Piece);
                                    }

                                    if (!obstacle)
                                    {
                                        var colorCheck = false;
                                        if (field.IsOccupied())
                                        {
                                            if (field.Piece.Color == f.Piece.Color)
                                                colorCheck = true;
                                        }
                                        if (!colorCheck)
                                        {

                                            board.SetFieldAt(y, x, f.Piece);
                                            board.EmptyField(py, px);
                                            f = null;
                                            rx = x;
                                            ry = y;
                                            validMoves = null;
                                            turn = (turn == Colors.White) ? Colors.Red : Colors.White;
                                        }
                                        else
                                        {
                                            messages.Add("cant attack the same color");
                                        }
                                    }
                                    else
                                    {
                                        messages.Add("cant proceed. there is a piece in between!");
                                    }
                                }
                                else
                                {
                                    switch (f.Piece)
                                    {
                                        case Pawn p:
                                            if (board.IsValidAttackMove(y, x, ry, rx, f.Piece))
                                            {
                                                var colorCheck = false;
                                                if (field.IsOccupied())
                                                {
                                                    if (field.Piece.Color == f.Piece.Color)
                                                        colorCheck = true;
                                                }
                                                if (!colorCheck)
                                                {
                                                    board.SetFieldAt(y, x, f.Piece);
                                                    board.EmptyField(py, px);
                                                    f = null;
                                                    rx = x;
                                                    ry = y;
                                                    validMoves = null;
                                                    turn = (turn == Colors.White) ? Colors.Red : Colors.White;
                                                }
                                                else
                                                {
                                                    messages.Add("cant attack the same color");
                                                }
                                            }
                                            else
                                            {
                                                messages.Add("another piece on the way!");
                                            }
                                            break;
                                        case Queen q:
                                            var obstacle = false;
                                            if (dx > 1 || dy > 1)
                                            {
                                                obstacle = board.FindObstacle(x, y, px, py, f.Piece);
                                            }
                                            if (!obstacle)
                                            {
                                                var colorCheck = false;
                                                if (field.IsOccupied())
                                                {
                                                    if (field.Piece.Color == f.Piece.Color)
                                                        colorCheck = true;
                                                }
                                                if (!colorCheck)
                                                {
                                                    board.SetFieldAt(y, x, f.Piece);
                                                    board.EmptyField(py, px);
                                                    f = null;
                                                    rx = x;
                                                    ry = y;
                                                    validMoves = null;
                                                    turn = (turn == Colors.White) ? Colors.Red : Colors.White;
                                                }
                                                else
                                                {
                                                    messages.Add("cant attack the same color");
                                                }
                                            }
                                            else
                                            {
                                                messages.Add("another piece on the way!");
                                            }
                                            break;
                                        case Castle c:
                                            var _obstacle = false;
                                            if (dx > 1 || dy > 1)
                                            {
                                                _obstacle = board.FindObstacle(x, y, px, py, f.Piece);
                                            }
                                            if (!_obstacle)
                                            {
                                                var colorCheck = false;
                                                if (field.IsOccupied())
                                                {
                                                    if (field.Piece.Color == f.Piece.Color)
                                                        colorCheck = true;
                                                }
                                                if (!colorCheck)
                                                {
                                                    board.SetFieldAt(y, x, f.Piece);
                                                    board.EmptyField(py, px);
                                                    f = null;
                                                    rx = x;
                                                    ry = y;
                                                    validMoves = null;
                                                    turn = (turn == Colors.White) ? Colors.Red : Colors.White;
                                                }
                                                else
                                                {
                                                    messages.Add("cant attack the same color");
                                                }
                                            }
                                            else
                                            {
                                                messages.Add("another piece on the way!");
                                            }
                                            break;
                                        case Bishop b:
                                            var __obstacle = false;
                                            if (dx > 1 || dy > 1)
                                            {
                                                __obstacle = board.FindObstacle(x, y, px, py, f.Piece);
                                            }
                                            if (!__obstacle)
                                            {
                                                var colorCheck = false;
                                                if (field.IsOccupied())
                                                {
                                                    if (field.Piece.Color == f.Piece.Color)
                                                        colorCheck = true;
                                                }
                                                if (!colorCheck)
                                                {
                                                    board.SetFieldAt(y, x, f.Piece);
                                                    board.EmptyField(py, px);
                                                    f = null;
                                                    rx = x;
                                                    ry = y;
                                                    validMoves = null;
                                                    turn = (turn == Colors.White) ? Colors.Red : Colors.White;
                                                }
                                                else
                                                {
                                                    messages.Add("cant attack the same color");
                                                }
                                            }
                                            else
                                            {
                                                messages.Add("another piece on the way!");
                                            }
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                messages.Add("Move is not valied, please choose another one! or press 0 to reset the move");
                            }
                        }
                    }

                }
                if (f != null)
                {
                    if (f.Piece != null)
                    {
                        messages.Add("The selected piece is " + f.Piece.DisplayLetter + " of " + f.Piece.Color);
                    }
                    validMoves = board.CalulateValidMoveForCurrentPiece(ry, rx, f.Piece);
                }
                cbd.ClearScreen();
                cbd.Wl("================ This is " + turn + " turn ================");
                cbd.drawBoard(board, validMoves, x, y);
                cbd.PrintMessages(messages);
            }
        }        
    }
}
