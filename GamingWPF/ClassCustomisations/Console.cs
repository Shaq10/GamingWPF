using System;
using System.Collections.Generic;
using System.Text;

namespace GamingWPF
{
    public partial class Console
    {
        public override string ToString()
        {
            return $"{ConsoleId} - {ConsoleName}";
        }
    }
}
