using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation
{
    public static class Constant
    {
        public static List<int> GUEST => new List<int> { 6, 9, 10, 13, 14, 18, 19 };
        public static List<int> USER => new List<int> { 6, 9, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 32 };
        public static List<int> ADMIN => new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 13, 14, 18, 19, 29, 30, 31, 34 };
    }
}
