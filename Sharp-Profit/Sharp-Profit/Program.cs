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

        public static void Peeper(string path)
        {
            string[] passarray; // Define array for password
            string[] credarray; // Define array for credential
            string[] adminarray; // Define array for Administrator
            string[] Files; // Define Files

            passarray = new string[] { "password", "Password", "PASSWORD", "PASS" }; // Array for passwords
            credarray = new string[] { "credential", "creds", "CREDENTIAL", "CREDS" }; // Array for credential
            adminarray = new string[] { "Admin", "admin", "ADMIN" }; // Array for Administrator
            System.IO.StreamReader file = new System.IO.StreamReader(path); // Read the files in Path
            Files = File.ReadAllLines(path); // Read all lines in the file.

            foreach (string line in Files) // For each line in the file look for the password string. 
            {
                foreach (string s in passarray)
                {
                    if (line.Contains(s))
                    {
                        Console.WriteLine("Possible password found: {0} in {1}", line, path);
                    }
                }
            }

            foreach (string line in Files) // For each line in the file look for the credential string.
            {
                foreach (string s in credarray)
                {
                    if (line.Contains(s))
                    {
                        Console.WriteLine("Possible credentials found: {0} in {1}", line, path);
                    }
                }
            }

            foreach (string line in Files) // For each line in the file look for the administrator string
            {
                foreach (string s in adminarray)
                {
                    if (line.Contains(s))
                    {
                        if (line.Contains("pass"))
                        {
                            Console.WriteLine("Possible Administrator Credentials found: {0} in {1}", line, path);
                        }
                    }
                }
            }
        }

        // Insert logic for processing found files here.
        public static void ProcessFile(string path, string regex_pattern) // Performs search for defined file extensions
        {
            string[] extensionarray; // Define array for common extensions
            string[] ntuserarray; // Define array for ntuser.dat
            string[] samarray; // Define array for sam files
            string[] hostsarray; // Define array for host files
            string[] extensionarray2;

            extensionarray = new string[] { ".txt", ".tex", ".text", ".doc", ".docx", ".pdf", ".rtf", ".wks", ".wps", ".wpd", ".xls", ".ods", ".xlr", ".xlsx" }; // Array for common extensions
            ntuserarray = new string[] { ".DAT" }; // Array for NTUSER.DAT file
            samarray = new string[] { "config", "repair" }; // Array for SAM file
            hostsarray = new string[] { "etc" }; // Array for Hosts file
            extensionarray2 = new string[] { ".kbdx", ".sav", ".sql", ".tar", ".bak", ".pst", ".py", ".yaml" }; // Array for more useful extensions

            try
            {
                // If the file matches regex then print it. If not, do nothing. This will search for specific predefined files and extensions
                Regex rgx = new Regex(regex_pattern);
                if (rgx.IsMatch(path))
                {
                    if (path.Contains("password"))
                    {
                        foreach (string s in extensionarray)
                        {
                            if (path.Contains(s))
                            {
                                using (StreamWriter w = File.AppendText("log.txt"))
                                {
                                    w.WriteLine("Possible PASSWORD file found here: '{0}'", path);
                                }
                                Peeper(path);
                            }
                        }
                    }
                    if (path.Contains("credential"))
                    {
                        foreach (string s in extensionarray)
                        {
                            if (path.Contains(s))
                            {
                                using (StreamWriter w = File.AppendText("log.txt"))
                                {
                                    w.WriteLine("Possible CREDENTIAL file found here: '{0}'", path);
                                }
                                Peeper(path);
                            }
                        }
                    }
                    if (path.Contains("ConsoleHost_history"))
                    {
                        foreach (string s in extensionarray)
                        {
                            if (path.Contains(s))
                            {
                                using (StreamWriter w = File.AppendText("log.txt"))
                                {
                                    w.WriteLine("Possible POWERSHELL LOG file found here: '{0}'", path);
                                }
                                Peeper(path);
                            }
                        }
                    }
                    if (path.Contains("NTUSER"))
                    {
                        foreach (string s in ntuserarray)
                        {
                            if (path.Contains(s))
                            {
                                using (StreamWriter w = File.AppendText("log.txt"))
                                {
                                    w.WriteLine("Possible NTUSER file found here: '{0}'", path);
                                }
                                Peeper(path);
                            }
                        }
                    }
                    if (path.Contains("SAM"))
                    {
                        foreach (string s in samarray)
                        {
                            if (path.Contains(s))
                            {
                                using (StreamWriter w = File.AppendText("log.txt"))
                                {
                                    w.WriteLine("Possible SAM file found here: '{0}'", path);
                                }
                                Peeper(path);
                            }
                        }
                    }
                    if (path.Contains("hosts"))
                    {
                        foreach (string s in hostsarray)
                        {
                            if (path.Contains(s))
                            {
                                using (StreamWriter w = File.AppendText("log.txt"))
                                {
                                    w.WriteLine("Possible HOST file found here: '{0}'", path);
                                }
                                Peeper(path);
                            }
                        }
                    }
                    if (path.Contains("unattend"))
                    {
                        foreach (string s in extensionarray)
                        {
                            if (path.Contains(s))
                            {
                                using (StreamWriter w = File.AppendText("log.txt"))
                                {
                                    w.WriteLine("Possible UNATTEND file found here: '{0}'", path);
                                }
                                Peeper(path);
                            }
                        }
                    }
                    foreach (string s in extensionarray2)
                    {
                        if (path.EndsWith(s))
                        {
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                w.WriteLine("Possible {0} file here '{1}'", s, path);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Fuck nothing
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
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
