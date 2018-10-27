using MK120.Model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK120.Model.models
{

    public class MoveResult
    {
        public MovementResult MovementResult { get; set; }
        public AbstractPiece Piece { get; set; }
        public MoveResult()
        {
            this.Piece = null;
        }
    }

}
