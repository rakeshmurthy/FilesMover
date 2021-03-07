using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using FilesMover.DomainModels;
using FilesMover.Services;

namespace FilesMover.Logic
{
    public static class Validation
    {
        public static bool CheckIfPathExists(string path) => Directory.Exists(path);

        /// <summary>
        /// Checks and validates input and output locations set in the app.config
        /// </summary>
        public static (bool set, List<Location> readLocations) CheckConfigurationSettings()
        {
            var readLocations = new List<Location>();

            if (ConfigurationManager.AppSettings.Count <= 0)
            {
                return (false, readLocations);
            }
            foreach(KeyValuePair<string, (LocationCategory, LocationType)> appSetting in Constants.Locations)
            {
                readLocations.Add(GetLocation(ConfigurationManager.AppSettings[appSetting.Key],
                                          appSetting.Value.Item1,
                                          appSetting.Value.Item2));
            }

            return (!readLocations.Any(x => !x.Valid), readLocations);
        }

        private static Location GetLocation(string path, LocationCategory category, LocationType type)
        {
            return new Location
            {
                Path = path,
                Category = category,
                Type = type,
                Valid = (Directory.Exists(path) && !string.IsNullOrEmpty(path))
            };
        }

    }
}
