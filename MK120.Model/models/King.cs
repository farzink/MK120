using MK120.Model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK120.Model.models
{
    public class King : AbstractPiece
    {
        public King()
        {
            this.letterDisplay = 'K';
        }
        public King(Colors color) : this()
        {
            this.color = color;
        }

        public override bool IsLegalMove(int dx, int dy)
        {
            if ((Math.Abs(dx) <= 1) && (Math.Abs(dy) <= 1))
            {
                hasBeenMoved = true;
                return true;
            }
            return false;
        }
    }
}
