using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubixCube
{
    class Program
    {
        static void Main(string[] args)
        {
            Game gm = new Game();
            gm.Run(1.0 / 100.0);
        }
    }
}
