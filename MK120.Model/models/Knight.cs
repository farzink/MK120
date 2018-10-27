using MK120.Model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK120.Model.models
{
    public class Knight : AbstractPiece
    {
        public Knight()
        {
            this.letterDisplay = 'k';
        }
        public Knight(Colors color) : this()
        {
            this.color = color;
        }

        public override bool IsLegalMove(int dx, int dy)
        {
            dx = Math.Abs(dx);
            dy = Math.Abs(dy);
            return (dx == 1 && dy == 2) || (dx == 2 && dy == 1);
        }
    }
}
