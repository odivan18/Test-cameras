using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_cameras
{
    class CameraSorter
    {
        public static int CompareByName(Camera x, Camera y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (y == null)
                {
                    return 1;
                }
                else
                {
                    return x.name.CompareTo(y.name);
                }
            }
        }
    }
}
