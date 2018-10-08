using MK120.Model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MK120.Model.models
{
    public class AbstractPiece
    {
        protected char letterDisplay;
        protected Colors color;
        protected bool hasBeenMoved = false;
        public char DisplayLetter {
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
    }
}
