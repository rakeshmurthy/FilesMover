using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FilesMover.DomainModels;
using FilesMover.Services;
using FilesMover.Logic;

namespace FilesMover.Logic
{
    public class FileProcessor
    {
        public FileProcessor()
        {
        }

        /// <summary>
        /// Checks are read all the files from input folder
        /// </summary>
        public List<Files> ReadAllFilesInfo(List<Location> readLocations)
        {
            var readFilesInfos = new List<Files>();
            var inputLocations = readLocations.Where(x => x.Type == LocationType.Input).ToList();
            foreach(var inputLocation in inputLocations)
            {
                if(!Validation.CheckIfPathExists(inputLocation.Path))
                {
                    Display.DisplayError($"Input directory set in app settings not found: {inputLocation.Path}");
                    break;
                }

                foreach(var file in Directory.EnumerateFiles(inputLocation.Path))
                {
                    var f = new FileInfo(file);
                    readFilesInfos.Add(
                        new Files
                        {
                            FileName = f.Name,
                            FileLocation = f.Directory.FullName,
                            FileSize= f.Length,
                            FileType = Enum.TryParse(Path.GetExtension(f.FullName).Substring(1), out FileType val) ? val : FileType.unknown
                        });
                }
            }

            return readFilesInfos;
        }

        /// <summary>
        /// Moves the files that are bigger than 1 bytes
        /// </summary>
        public (int totalFilesMoved, int numberOfXmlFilesMoved, int numberOfTextFilesMoved) MoveAllFiles(List<Files> files, List<Location> locations)
        {
            (int totalFilesMoved, int numberOfXmlFilesMoved, int numberOfTextFilesMoved) = (0, 0, 0);
            foreach(var file in files.Where(x=> (x.FileType == FileType.xml || x.FileType == FileType.txt) && x.FileSize > 1).ToList())
            {
                switch(file.FileType)
                {
                    case FileType.xml:
                        {
                            var outputLocation = locations.FirstOrDefault(x => x.Category == LocationCategory.Xml);
                            File.Move(Path.Combine(file.FileLocation,file.FileName), Path.Combine(CreateDirectory(outputLocation.Path),file.FileName),true);
                            numberOfXmlFilesMoved++;
                        }
                        break;

                    case FileType.txt:
                        {
                            var outputLocation = locations.FirstOrDefault(x => x.Category == LocationCategory.Text);
                            File.Move(Path.Combine(file.FileLocation, file.FileName), Path.Combine(CreateDirectory(outputLocation.Path), file.FileName), true);
                            numberOfTextFilesMoved++;
                        }
                        break;
                }
                totalFilesMoved++;
            }

            return (totalFilesMoved, numberOfXmlFilesMoved, numberOfTextFilesMoved);
        }        

        private static string CreateDirectory(string path) => Validation.CheckIfPathExists(path) == true ? path : Directory.CreateDirectory(path).FullName;
    }
}
