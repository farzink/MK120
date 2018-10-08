using MK120.Model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK120.Model.models
{
    public class Field
    {
        public AbstractPiece Piece { get; set; }
        public Colors Color { get; set; }
        public Field()
        {
            this.Piece = null;            
        }
        public bool IsOccupied()
        {
            return this.Piece != null;
        }
    }
}
