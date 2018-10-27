using MK120.Model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MK120.Model.models
{
    public abstract class AbstractPiece
    {
        protected char letterDisplay;
        protected Colors color;
        protected bool hasBeenMoved = false;
        public char DisplayLetter
        {
            get
            {
                return letterDisplay;
            }
        }
        public Colors Color
        {
            get
            {
                return color;
            }
        }
        public void Moved()
        {
            hasBeenMoved = true;
        }
        abstract public bool IsLegalMove(int dx, int dy);
    }
}
