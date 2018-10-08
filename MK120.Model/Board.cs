using MK120.Model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK120.Model.models
{
    public class Board
    {
        public Field[,] Fields { get; set; }
        
        public Board()
        {            
            this.Init();
        }
        private void Init()
        {
            this.Fields = new Field[8, 8];
            this.ColorTheBoard();
            this.FillTheBorad(Colors.Red, Colors.White);
        }
        private void ColorTheBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    Fields[i, k] = new Field();
                    if ((k + i) % 2 == 0)
                    {
                        Fields[i, k].Color = Colors.Gray;
                    }
                    else
                    {
                        Fields[i, k].Color = Colors.Black;
                    }
                }
            }
        }
        private void FillTheBorad(Colors upColor, Colors downColor)
        {            
                for (int k = 0; k < 8; k++)
                {
                Fields[0, k].Piece = this.GetPieceByPositionForInitialization(k, upColor);
                Fields[7, k].Piece = this.GetPieceByPositionForInitialization(k, downColor);

                Fields[1, k].Piece = this.GetPieceByPositionForInitialization(10, upColor);
                Fields[6, k].Piece = this.GetPieceByPositionForInitialization(10, downColor);
            }
            
        }
        private AbstractPiece GetPieceByPositionForInitialization(int position, Colors color)
        {
            switch (position)
            {
                case 0:
                    return new Castle(color);
                case 1:
                    return new Knight(color);
                case 2:
                    return new Bishop(color);
                case 3:
                    return new Queen(color);
                case 4:
                    return new King(color);
                case 5:
                    return new Bishop(color);
                case 6:
                    return new Knight(color);
                case 7:
                    return new Castle(color);                
                default:
                    return new Pawn(color);
            }
        }


    }
}
