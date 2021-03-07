using System;
using System.IO;
using System.Linq;
using FilesMover.Logic;

namespace FilesMover
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Display.DisplayHeader();

            var (set, readLocations) = Validation.CheckConfigurationSettings();

            var fm = new FileProcessor();
            var files = fm.ReadAllFilesInfo(readLocations);

            Display.DisplayReadLocations(readLocations);

            if (!set)
            {
                Display.DisplayError("Set valid source and destination locations");
                return;
            }

            if (files.Count <= 0)
            {
                Display.DisplayError("There are no files to move from the source location set");
                return;
            }

            Display.DisplayFilesInfo(files);
            var result = fm.MoveAllFiles(files, readLocations);

            Display.DisplayConclusion(result);
        }
    }
}
