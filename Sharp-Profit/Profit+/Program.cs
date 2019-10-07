using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Profit
{
    class Program
    {
        public static void Banner() // Define banner to be printed.
        {
            Console.WriteLine("===========================================================================");
            Console.WriteLine("===========================================================================");
            Console.WriteLine("==       __    ____     ____     ____     ______   ____   ______    __   ==");
            Console.WriteLine("==     _/ /   / __  \\  / __ \\   / __ \\   / ____/  /  _/  /_  __/  _/ /   ==");
            Console.WriteLine("==    / __/  / /_/ /  / /_/ /  / / / /  / /_      / /     / /    / __/   ==");
            Console.WriteLine("==   (_  )  / ____/  / _, _/  / /_/ /  / __/    _/ /     / /    (_  )    ==");
            Console.WriteLine("==  /  _/  /_/      /_/ |_|   \\____/  /_/      /___/    /_/    /  _/     ==");
            Console.WriteLine("==  /_/                                                        /_/       ==");
            Console.WriteLine("==                                                                       ==");
            Console.WriteLine("===========================================================================");
            Console.WriteLine("===========================================================================");
        }

        public static void ProcessDirectory(string targetDirectory, string regex_pattern) // Perform the directory indexing
        {
            try
            {
                // Process the list of files found in the directory.
                string[] fileEntries = Directory.GetFiles(targetDirectory);
                foreach (string fileName in fileEntries)
                    ProcessFile(fileName, regex_pattern);

                // Recursively look into subdirectories of this directory
                string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
                foreach (string subdirectory in subdirectoryEntries)
                    try
                    {
                        ProcessDirectory(subdirectory, regex_pattern);
                    }
                    catch (Exception e)
                    {
                        //Console.WriteLine("Error processing directory - {0} - {1}", targetDirectory, e.Message); // I commented out due to sheer volume of errors
                    }
            }
            catch (Exception e)
            {
                //Console.WriteLine("Error processing directory - {0} - {1}", targetDirectory, e.Message); // I commented out due to sheer volume of errors
            }
        }
        //string line;
        public static void Peeper(string path)
        {
            try
            {
                //int counter = 0;
                System.IO.StreamReader file = new System.IO.StreamReader(path);
                foreach (string line in File.ReadAllLines(path))
                {
                    if (line.Contains("password"))
                        Console.WriteLine("Possible password found: {0}, in {1}", line, path);
                    else if (line.Contains("Password"))
                    {
                        Console.WriteLine("Possible password found: {0}, in {1}", line, path);
                    }
                    else if (line.Contains("PASSWORD"))
                    {
                        Console.WriteLine("Possible password found: {0}, in {1}", line, path);
                    }
                    else if (line.Contains("credential"))
                    {
                        Console.WriteLine("Possible credential found: {0}, in {1}", line, path);
                    }
                    else if (line.Contains("Credential"))
                    {
                        Console.WriteLine("Possible credential found: {0}, in {1}", line, path);
                    }
                    else if (line.Contains("CREDENTIAL"))
                    {
                        Console.WriteLine("Possible credential found: {0}, in {1}", line, path);
                    }
                    else if (line.Contains("creds"))
                    {
                        Console.WriteLine("Possible credential found: {0}, in {1}", line, path);
                    }
                    else if (line.Contains("Creds"))
                    {
                        Console.WriteLine("Possible credential found: {0}, in {1}", line, path);
                    }
                    else if (line.Contains("Admin"))
                    {
                        if (line.Contains("Password"))
                            Console.WriteLine("Possible Admin Password found: {0}, in {1}", line, path);
                    }
                    else if (line.Contains("ADMIN"))
                    {
                        if (line.Contains("Password"))
                            Console.WriteLine("Possible Admin Password found: {0}, in {1}", line, path);
                    }
                    else if (line.Contains("admin"))
                    {
                        if (line.Contains("Password"))
                            Console.WriteLine("Possible Admin Password found: {0}, in {1}", line, path);
                    }
                    else if (line.Contains("Administrator"))
                    {
                        if (line.Contains("Password"))
                            Console.WriteLine("Possible Admin Password found: {0}, in {1}", line, path);
                    }
                    else if (line.Contains("administrator"))
                    {
                        if (line.Contains("Password"))
                            Console.WriteLine("Possible Admin Password found: {0}, in {1}", line, path);
                    }
                    else if (line.Contains("ADMINISTRATOR"))
                    {
                        if (line.Contains("Password"))
                            Console.WriteLine("Possible Admin Password found: {0}, in {1}", line, path);
                    }

                }
                file.Close();
            }
            catch (Exception e)
            {
                //Console.WriteLine("Error processing directory - {0} - {1}", targetDirectory, e.Message); // I commented out due to sheer volume of errors
            }
        }

        // Insert logic for processing found files here.
        public static void ProcessFile(string path, string regex_pattern) // Performs search for defined file extensions
        {
            try
            {
                // If the file matches regex then print it. If not, do nothing. This will search for specific predefined files and extensions
                Regex rgx = new Regex(regex_pattern);
                if (rgx.IsMatch(path))
                {
                    if (path.Contains("password"))
                    {
                        if (path.Contains(".txt")) // Text files
                        {

                            //Console.WriteLine("Possible PASSWORD file found here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible PASSWORD file found here: '{0}'", path);
                                //Peeper(path);
                            }
                            Peeper(path);
                        }
                        else if (path.Contains(".tex")) // Text files
                        {
                            //Console.WriteLine("Possible PASSWORD file found here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("Log.txt"))
                            {
                                w.WriteLine("Possible PASSWORD file found here: '{0}'", path);
                            }
                            Peeper(path);
                        }
                        else if (path.Contains(".text")) // Text files
                        {
                            //Console.WriteLine("Possible PASSWORD file found here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible PASSWORD file found here: '{0}'", path);
                                Peeper(path);
                            }

                        }
                        else if (path.EndsWith(".doc")) // Word Documents
                        {
                            // Console.WriteLine("Possible PASSWORD file found here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible PASSWORD file found here: '{0}'", path);
                                Peeper(path);
                            }

                        }
                        else if (path.EndsWith(".docx")) // Word Documents
                        {
                            //Console.WriteLine("Possible PASSWORD file found here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible PASSWORD file found here: '{0}'", path);
                                Peeper(path);
                            }

                        }
                        else if (path.EndsWith(".pdf")) // PDF's
                        {
                            //Console.WriteLine("Possible PASSWORD file found here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible PASSWORD file found here: '{0}'", path);
                                Peeper(path);
                            }
                        }
                        else if (path.EndsWith(".rtf")) // Rich text format
                        {
                            //Console.WriteLine("Possible PASSWORD file found here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible PASSWORD file found here: '{0}'", path);
                                Peeper(path);
                            }
                        }
                        else if (path.EndsWith(".wks")) // Microsoft works file
                        {
                            //Console.WriteLine("Possible PASSWORD file found here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible PASSWORD file found here: '{0}'", path);
                                Peeper(path);
                            }
                        }
                        else if (path.EndsWith(".wps")) // Microsoft works file
                        {
                            //Console.WriteLine("Possible PASSWORD file found here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible PASSWORD file found here: '{0}'", path);
                                Peeper(path);
                            }
                        }
                        else if (path.EndsWith(".wpd")) // Microsoft works file
                        {
                            //Console.WriteLine("Possible PASSWORD file found here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible PASSWORD file found here: '{0}'", path);
                                Peeper(path);
                            }
                        }
                        else if (path.EndsWith(".xls")) // Microsoft Excel file
                        {
                            //Console.WriteLine("Possible PASSWORD file found here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible PASSWORD file found here: '{0}'", path);
                                Peeper(path);
                            }
                        }
                        else if (path.EndsWith(".ods")) // OpenOffice calc spreadsheet file
                        {
                            //Console.WriteLine("Possible PASSWORD file found here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible PASSWORD file found here: '{0}'", path);
                                Peeper(path);
                            }
                        }
                        else if (path.EndsWith(".xlr")) // Microsoft works spreadsheet file
                        {
                            //Console.WriteLine("Possible PASSWORD file found here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible PASSWORD file found here: '{0}'", path);
                                Peeper(path);
                            }
                        }
                        else if (path.EndsWith(".xlsx")) // Microsoft Excel open XML spreadsheet file
                        {
                            //Console.WriteLine("Possible PASSWORD file found here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible PASSWORD file found here: '{0}'", path);
                                Peeper(path);
                            }
                        }
                    }
                    if (path.Contains("credential"))
                    {
                        if (path.Contains(".txt")) // Text files
                        {
                            //Console.WriteLine("Possible CREDENTIAL file found here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible CREDENTIAL file found here: '{0}'", path);
                                Peeper(path);
                            }
                        }
                        else if (path.Contains(".tex")) // Text files
                        {
                            //Console.WriteLine("Possible CREDENTIAL file found here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("Log.txt"))
                            {
                                w.WriteLine("Possible CREDENTIAL file found here: '{0}'", path);
                                Peeper(path);
                            }
                        }
                        else if (path.Contains(".text")) // Text files
                        {
                            //Console.WriteLine("Possible CREDENTIAL file found here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible CREDENTIAL file found here: '{0}'", path);
                                Peeper(path);
                            }

                        }
                        else if (path.EndsWith(".doc")) // Word Documents
                        {
                            // Console.WriteLine("Possible CREDENTIAL file found here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible CREDENTIAL file found here: '{0}'", path);
                                Peeper(path);
                            }

                        }
                        else if (path.EndsWith(".docx")) // Word Documents
                        {
                            //Console.WriteLine("Possible CREDENTIAL file found here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible CREDENTIAL file found here: '{0}'", path);
                                Peeper(path);
                            }

                        }
                        else if (path.EndsWith(".pdf")) // PDF's
                        {
                            //Console.WriteLine("Possible CREDENTIAL file found here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible CREDENTIAL file found here: '{0}'", path);
                                Peeper(path);
                            }
                        }
                        else if (path.EndsWith(".rtf")) // Rich text format
                        {
                            //Console.WriteLine("Possible CREDENTIAL file found here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible CREDENTIAL file found here: '{0}'", path);
                                Peeper(path);
                            }
                        }
                        else if (path.EndsWith(".wks")) // Microsoft works file
                        {
                            //Console.WriteLine("Possible CREDENTIAL file found here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible CREDENTIAL file found here: '{0}'", path);
                                Peeper(path);
                            }
                        }
                        else if (path.EndsWith(".wps")) // Microsoft works file
                        {
                            //Console.WriteLine("Possible CREDENTIAL file found here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible CREDENTIAL file found here: '{0}'", path);
                                Peeper(path);
                            }
                        }
                        else if (path.EndsWith(".wpd")) // Microsoft works file
                        {
                            //Console.WriteLine("Possible CREDENTIAL file found here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible CREDENTIAL file found here: '{0}'", path);
                                Peeper(path);
                            }
                        }
                        else if (path.EndsWith(".xls")) // Microsoft Excel file
                        {
                            //Console.WriteLine("Possible CREDENTIAL file found here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible CREDENTIAL file found here: '{0}'", path);
                                Peeper(path);
                            }
                        }
                        else if (path.EndsWith(".ods")) // OpenOffice calc spreadsheet file
                        {
                            //Console.WriteLine("Possible CREDENTIAL file found here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible CREDENTIAL file found here: '{0}'", path);
                                Peeper(path);
                            }
                        }
                        else if (path.EndsWith(".xlr")) // Microsoft works spreadsheet file
                        {
                            //Console.WriteLine("Possible CREDENTIAL file found here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible CREDENTIAL file found here: '{0}'", path);
                                Peeper(path);
                            }
                        }
                        else if (path.EndsWith(".xlsx")) // Microsoft Excel open XML spreadsheet file
                        {
                            //Console.WriteLine("Possible CREDENTIAL file found here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible CREDENTIAL file found here: '{0}'", path);
                                Peeper(path);
                            }
                        }
                    }
                    if (path.Contains("NTUSER")) // Search for NTUSER.DAT files.
                    {
                        if (path.EndsWith(".DAT"))
                        {
                            //Console.WriteLine("Possible NTUSER file here '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible NTUSER file found here: '{0}'", path);
                            }
                        }
                    }
                    else if (path.Contains("SAM")) // Search for SAM file.
                    {
                        if (path.Contains("config"))
                        {
                            //Console.WriteLine("Possible SAM file here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible SAM file found here: '{0}'", path);
                            }
                        }
                        else if (path.Contains("repair"))
                        {
                            //Console.WriteLine("Possible SAM file here: '{0}'");
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible SAM file found here: '{0}'", path);
                            }
                        }
                    }
                    else if (path.Contains("hosts"))
                    {
                        if (path.Contains("etc"))
                        {
                            //Console.WriteLine("Possible HOSTS file here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible HOSTS file found here: '{0}'", path);
                            }
                        }
                    }
                    else if (path.Contains("unattend"))
                    {
                        if (path.EndsWith(".txt"))
                        {
                            //Console.WriteLine("Possible UNATTEND file here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible UNATTEND file found here: '{0}'", path);
                                Peeper(path);
                            }
                        }
                        else if (path.EndsWith(".tex"))
                        {
                            //Console.WriteLine("Possible UNATTEND file here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible UNATTEND file found here: '{0}'", path);
                                Peeper(path);
                            }
                        }
                        else if (path.EndsWith(".text"))
                        {
                            //Console.WriteLine("Possible UNATTEND file here: '{0}'", path);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible UNATTEND file found here: '{0}'", path);
                                Peeper(path);
                            }
                        }
                    }
                    else if (path.EndsWith(".kbdx"))
                    {
                        //Console.WriteLine("Possible KEEPASS file here '{0}'", path);
                        using (StreamWriter w = File.AppendText("log.txt"))
                        {
                            w.WriteLine("Possible KEEPASS file found here: '{0}'", path);
                        }
                    }
                    //else if (path.EndsWith(".db")) // I took out due to large number of db files
                    //{
                    //    Console.WriteLine("Possible DATABASE file here '{0}'", path);
                    //}
                    //else if (path.EndsWith(".dbf")) // I took out due to large number of db files
                    //{
                    //    Console.WriteLine("Possible DATABASE file here '{0}'", path);
                    //}
                    //else if (path.EndsWith(".mdb")) // I took out due to large number of db files
                    //{
                    //    Console.WriteLine("Possible MICROSOFT ACCESS DATABASE file here '{0}'", path);
                    //}
                    else if (path.EndsWith(".sav"))
                    {
                        //Console.WriteLine("Possible SAVE file here '{0}'", path);
                        using (StreamWriter w = File.AppendText("log.txt"))
                        {
                            w.WriteLine("Possible SAVE file found here: '{0}'", path);
                        }
                    }
                    else if (path.EndsWith(".sql)"))
                    {
                        //Console.WriteLine("Possible SQL file here '{0}'", path);
                        using (StreamWriter w = File.AppendText("log.txt"))
                        {
                            w.WriteLine("Possible SQL file found here: '{0}'", path);
                        }
                    }
                    else if (path.EndsWith(".tar"))
                    {
                        //Console.WriteLine("Possible TAR file here '{0}'", path);
                        using (StreamWriter w = File.AppendText("log.txt"))
                        {
                            w.WriteLine("Possible TAR file found here: '{0}'", path);
                        }
                    }
                    else if (path.EndsWith(".bak"))
                    {
                        //Console.WriteLine("Possible BACKUP file here '{0}'", path);
                        using (StreamWriter w = File.AppendText("log.txt"))
                        {
                            w.WriteLine("Possible BACKUP file found here: '{0}'", path);
                        }
                    }
                    else if (path.EndsWith(".pst"))
                    {
                        //Console.WriteLine("Possible OUTLOOK PERSONAL FILE here '{0}'", path);
                        using (StreamWriter w = File.AppendText("log.txt"))
                        {
                            w.WriteLine("Possible OUTLOOK PERSONAL FILE found here: '{0}'", path);
                        }
                    }
                    else if (path.EndsWith(".py"))
                    {
                        //Console.WriteLine("Possible OUTLOOK PERSONAL FILE here '{0}'", path);
                        using (StreamWriter w = File.AppendText("log.txt"))
                        {
                            w.WriteLine("Possible Python Script found here: '{0}'", path);
                        }
                    }
                    else if (path.EndsWith(".yaml"))
                    {
                        //Console.WriteLine("Possible OUTLOOK PERSONAL FILE here '{0}'", path);
                        using (StreamWriter w = File.AppendText("log.txt"))
                        {
                            w.WriteLine("Possible YAML file found here: '{0}'", path);
                        }
                    }
                    else if (path.EndsWith(".settingcontent-ms"))
                    {
                        //Console.WriteLine("Possible SETTINGCONTENT-MS file here '{0}'", path);
                        using (StreamWriter w = File.AppendText("log.txt"))
                        {
                            w.WriteLine("Possible SETTINGCONTENT-MS file found here: '{0}'", path);
                        }
                    }
                    else
                    {
                        // Do nothing. This is done to suppress the amount of files shown.
                    }
                    // Can also do other processing stuff here.
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine("Error processing directory - {0} - {1}", targetDirectory, e.Message); // I commented out due to sheer volume of errors
            }
        }

        public static void LogDate(string logmessage, TextWriter w) // Write the date to the log file
        {
            w.Write("And here are your Profit results as of: ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
        }

        static void Main(string[] args) //Performs all of the functions.
        {
            using (StreamWriter w = File.AppendText("log.txt")) // Run the LogDate function
            {
                LogDate("ZZZ", w);
            }
            Banner(); // Print the banner 
            Console.WriteLine("\r\n\r\nStarting Sharp-Profit"); // Starting text
            var watch = System.Diagnostics.Stopwatch.StartNew(); // Start the stopwatch
            DriveInfo[] allDrives = DriveInfo.GetDrives(); // Get list of all drives on FileSystem
            foreach (DriveInfo d in allDrives) //For loop for drives on FileSystem
            {
                string targetDirectory = d.Name; // Declare targetDirectory as the drive names
                string regex_pattern = "."; // Specifies the file extensions to look for. May need to trim down, lots of files are found.
                ProcessDirectory(targetDirectory, regex_pattern); // Search for files
            }
            watch.Stop(); // Stop the watch.
            string inFile = "log.txt"; // Initial file we wrote to
            string outFile = "Profit_Results.txt"; // File that is going to be sorted based off of results
            var contents = File.ReadAllLines(inFile); // Read the inFile
            Array.Sort(contents); // Sort the contents of inFile
            File.WriteAllLines(outFile, contents); // Write the sorted lines to outFile
            File.Delete("log.txt"); // Get rid of inFile
            Console.WriteLine("\r\n\r\nSharp-Profit finished running in {0} seconds. The results are in Profit_Results.txt", (watch.ElapsedMilliseconds / 1000)); // Print how many seconds have passed since the start of the program.
        }
    }
}