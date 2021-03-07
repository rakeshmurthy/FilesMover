using System;
using System.Collections.Generic;
using FilesMover.DomainModels;

namespace FilesMover
{
    public static class Display
    {
        public static void DisplayHeader()
        {
            Console.WriteLine("==================================");
            Console.WriteLine("Welcome to File Mover");
            Console.WriteLine("==================================");
        }

        public static void DisplayError(string error)
        {
            Console.WriteLine($"{error}");
        }

        public static void DisplayReadLocations(List<Location> readLocations)
        {
            Console.WriteLine("Locations information: \n");

            foreach (var location in readLocations)
            {
                Console.WriteLine($"Type:     {location.Type} location \n" +
                                  $"Category: {location.Category} files\n" +
                                  $"Location: {location.Path} \n" );
            }
            Console.WriteLine("==================================");
        }

        public static void DisplayFilesInfo(List<Files> files)
        {
            Console.WriteLine("Files information: \n");

            foreach(var file in files)
            {
                Console.WriteLine($"File Name:     {file.FileName} \n" +
                                  $"File Type:     {file.FileType} \n" +
                                  $"File Size:     {file.FileSize} bytes \n" +
                                  $"File location: {file.FileLocation} \n");
            }
            Console.WriteLine("==================================");
        }

        public static void DisplayConclusion((int totalFilesMoved, int numberOfXmlFilesMoved, int numberOfTextFilesMoved) result)
        {
            Console.WriteLine($"Conclusion: \n" +
                              $"Total number of files moved : {result.totalFilesMoved} (size bigger than 1 bytes)\n" +
                              $"Number of Xml files moved   : {result.numberOfXmlFilesMoved} \n" +
                              $"Number of Text files moved  : {result.numberOfTextFilesMoved} \n");
        }
    }
}
