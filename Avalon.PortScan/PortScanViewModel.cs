using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AvalonPortScan
{
    class PortScanViewModel
    {
        private static IEnumerable Model;

        public static void Test()
        {
            foreach (var test in Model)
            {
                test.ToString();
            }
        }
    }
}
