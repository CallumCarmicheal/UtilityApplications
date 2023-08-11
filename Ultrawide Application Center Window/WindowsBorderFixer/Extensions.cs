using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsBorderFixer {
    public static class Extensions {

        public static int ToInt32(this string value, int @default = 0) {
            int @out;

            if (Int32.TryParse(value, out @out)) 
                return @out;

            return @default;
        }

        public static bool ToInt32(this string value, out int @out) {
            return (Int32.TryParse(value, out @out));
        }
    }
}
