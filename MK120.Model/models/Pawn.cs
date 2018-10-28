using MK120.Model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK120.Model.models
{
    public class Pawn : AbstractPiece
    {
        public Pawn()
        {
            this.letterDisplay = 'P';
        }
        public Pawn(Colors color) : this()
        {
            this.color = color;
        }
        public bool IsLegalAttackMove(int dx, int dy, bool upward = false)
        {
            dy = Math.Abs(dy);
            if (!upward)
            {
                dx = Math.Abs(dx);
            }
            return (dx == 1 && dy == 1);
        }

        public override bool IsLegalMove(int dx, int dy)
        {
            return ((dx == 1 && dy == 0) || (dx == 2 && !hasBeenMoved && dy == 0));
        }
    }
}
