using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK120.Model.enums
{
    public enum MovementResult
    {
        Hit,
        LegalMove,
        NoPieceOnSource,
        TargetOccupiedByOwnPiece,
        TargetOutsideBoard,
        Collision,
        IllegalMovement
    }
}
