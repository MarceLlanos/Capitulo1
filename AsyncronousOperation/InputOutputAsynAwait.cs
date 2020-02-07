using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitulo1
{
    class InputOutputAsynAwait
    {
        string Text;

        private async void button1_Click(object sender, EventArgs e)
        {
            this.Text = "Searching...";
            string outputFileName = @"c:\Test\FoundFiles.txt";
            await SearchDirectory(@"c:\Chapter9Samples", "A", outputFileName);
            this.Text = "Finished";
            Process.Start(outputFileName);
        }
        private static async Task SearchDirectory(string searchPath, string searchString, string outputFileName)
        {
            StreamWriter streamWriter = File.CreateText(outputFileName);
            string[] fileNames = Directory.GetFiles(searchPath);
            await FindTextInFilesAsync(fileNames, searchString, streamWriter);
            streamWriter.Close();
        }

        private static async Task FindTextInFilesAsync(string[] fileNames, string searchString, StreamWriter outputFile)
        {
            foreach (string fileName in fileNames)
            {
                if (fileName.ToLower().EndsWith(".txt"))
                {
                    StreamReader streamReader = new StreamReader(fileName);
                    string textOfFile = await streamReader.ReadToEndAsync();
                    streamReader.Close();

                    if (textOfFile.Contains(searchString))
                    {
                        await outputFile.WriteLineAsync(fileName);
                    }
                }
            }
        }
    }
}
