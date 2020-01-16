using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ksiazka.Models
{
    public enum AppEnviroment
    {
        Developer=0,
        Testing=1,
        Production=2
    }

    public static class StaticConfig
    {
        public static AppEnviroment AppEnviroment = AppEnviroment.Developer;
    }
}