using System;
using System.Collections.Generic;
using FilesMover.DomainModels;

namespace FilesMover.Services
{
    public static class Constants
    {
        public static Dictionary<string, (LocationCategory, LocationType)> Locations = new Dictionary<string, (LocationCategory, LocationType)>()
        {
            { "inputLocation", (LocationCategory.all, LocationType.Input) },
            { "xmlOutputLocation", (LocationCategory.Xml, LocationType.Output) },
            { "textOutputLocation", (LocationCategory.Text, LocationType.Output) }
        };
    }
}
