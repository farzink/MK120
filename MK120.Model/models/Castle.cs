using MK120.Model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK120.Model.models
{
    public class Castle: AbstractPiece
    {
        public Castle()
        {
            this.letterDisplay = 'C';
        }
        public Castle(Colors color): this()
        {
            this.color = color;
        }
    }
}
