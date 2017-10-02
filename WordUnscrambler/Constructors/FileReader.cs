using System;
using System.IO;

namespace WordUnscrambler.Constructors
{
    class FileReader
    {
        public string[] Read(string fileInput)
        {
            string[] fileContent;
            try
            {
                fileContent = File.ReadAllLines(fileInput);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return fileContent;
        }
    }
}
