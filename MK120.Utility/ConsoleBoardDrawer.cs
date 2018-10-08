using MK120.Model.enums;
using MK120.Model.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK120.Utility
{
    public class ConsoleBoardDrawer
    {
        ConsoleColorHelper cch;
        public ConsoleBoardDrawer(ConsoleColorHelper cch)
        {
            this.cch = cch;
        }

        void drawTopLine()
        {
            W("┌");
            for (int i = 0; i < 7; i++)
            {
                W("─");
                W("─");
                W("─");
                W("┬");
            }
            W("─");
            W("─");
            W("─");
            W("┐");
            br();

        }

        void drawButtomLine()
        {
            W("└");
            for (int i = 0; i < 7; i++)
            {
                W("─");
                W("─");
                W("─");
                W("┴");
            }
            W("─");
            W("─");
            W("─");
            W("┘");
            br();
        }

        void drawMidLine()
        {
            W("│");
        }
        void drawLine()
        {
            W("├");
            for (int i = 0; i < 7; i++)
            {
                W("─");
                W("─");
                W("─");
                W("┼");
            }
            W("─");
            W("─");
            W("─");
            W("┤");
            br();
        }



        public void drawBoard(Board board)
        {
            drawTopLine();
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    cch.BackReset();

                    drawMidLine();
                    var field = board.Fields[i, k];
                    if (field.Piece != null)
                    {
                        if (field.Color == Colors.Gray)
                            cch.BackGray();
                        if (field.Piece.Color == Colors.Red)
                            cch.ForeRed();
                        W(" ");
                        W(field.Piece.DisplayLetter.ToString(), 1);
                        cch.ResetFore();
                        cch.BackReset();

                    }
                    else
                    {
                        if (field.Color == Colors.Gray)
                            cch.BackGray();
                        W(" ", 2);
                        cch.BackReset();

                    }
                    if (k == 7)
                    {
                        drawMidLine();
                    }
                }
                br();
                if (i < 7)
                    drawLine();
            }
            drawButtomLine();
        }


        void W(string message, int spaces = 0)
        {
            Console.Write(message);
            for(int i = 0; i < spaces; i++)
            {
                Console.Write(" ");
            }
        }
        void Wl(string message)
        {
            Console.WriteLine(message);
        }
        void br()
        {
            Console.WriteLine();
        }

    }
}
