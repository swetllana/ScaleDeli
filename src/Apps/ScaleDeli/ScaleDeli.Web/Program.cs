using SIS.MvcFramework;
using System;

namespace ScaleDeli.Web
{
    public static class Program
    {
        public static void Main()
        {
            WebHost.Start(new StartUp());
        }
    }
}
