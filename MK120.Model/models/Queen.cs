using MK120.Model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK120.Model.models
{
    public class Queen : AbstractPiece
    {
        public Queen()
        {
            this.letterDisplay = 'Q';
        }
        public Queen(Colors color) : this()
        {
            this.color = color;
        }

        public override bool IsLegalMove(int dx, int dy)
        {
            dx = Math.Abs(dx);
            dy = Math.Abs(dy);
            return (dx == 0 || dy == 0 || dx == dy);
        }
    }
}
