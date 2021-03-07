using System;
namespace FilesMover.DomainModels
{
    public class Location
    {
        public Location()
        {
        }

        public string Path { get; set; }

        public LocationCategory Category { get; set; }

        public LocationType Type { get; set; }

        public bool Valid { get; set; }
    }
}
