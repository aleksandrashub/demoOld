using demo2811.Context;
using demo2811.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo2811
{
    public static class Helper
    {
        public static readonly User11037Context context = new User11037Context();
        public static User currUser = null;
        public static int role = -1;

    }
}
