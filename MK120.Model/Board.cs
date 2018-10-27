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

        public MovementResult CheckMove(int x1, int y1, int x2, int y2)
        {
            if (!IsOut(x1, y1))
            {
                var currentPiece = Fields[x1, y1];
                var result = CheckAField(x2, y2, currentPiece);
                return result.MovementResult;
            }
            else
            {
                return MovementResult.IllegalMovement;
            }
        }

        MoveResult CheckAField(int x, int y, Field owner)
        {
            if (IsOut(x, y))
                return new MoveResult { MovementResult = MovementResult.TargetOutsideBoard };
            MoveResult mr = new MoveResult();
            var field = Fields[x, y];
            if (field.IsOccupied())
            {
                if (field.Piece.Color == owner.Piece.Color)
                    return new MoveResult
                    {
                        Piece = field.Piece,
                        MovementResult = MovementResult.TargetOccupiedByOwnPiece,
                    };
                else
                    return new MoveResult
                    {
                        Piece = field.Piece,
                        MovementResult = MovementResult.Hit
                    };
            }
            else
            {
                return new MoveResult
                {
                    Piece = null,
                    MovementResult = MovementResult.NoPieceOnSource
                };
            }

        }
        bool IsOut(int x, int y)
        {
            if (x < 0 || x > 7 || y < 0 || y > 7)
            {
                return true;
            }
            return false;
        }
        public bool IsValidMove(int x1, int y1, int x2, int y2)
        {
            var dx = x2 - x1;
            var dy = y2 - y1;
            var piece = Fields[x1, y1].Piece;
            return piece.IsLegalMove(dx, dy);
        }
        public void Move(int x1, int y1, int x2, int y2)
        {
            Fields[x2, y2].OccupyBy(Fields[x1, y1].Kick());
            Fields[x2, y2].Piece.Moved();
        }
        public Field GetFieldAt(int x, int y)
        {
            return Fields[x, y];
        }
        public void SetFieldAt(int x, int y, AbstractPiece piece)
        {
            Fields[x, y].OccupyBy(piece);          
            
        }
        public void EmptyField(int x, int y)
        {
            Fields[x, y].Kick();
        }


    }
}
