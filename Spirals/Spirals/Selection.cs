using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spirals
{
    public class Selection
    {
        private int choice = -1;

        public Selection()
        {
        }

        public int Choice
        {
            get { return choice; }
            set { choice = value; }
        }    
    }
}
