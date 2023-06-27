using System.IO;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using System.Xml;
using System.IO.Compression;
using System.Text;
using WorkingWithFileSystem;
using System.Xml.Serialization;

namespace Packt.Shared
{
    public class Program
    {
        public static string[] callsigns = new string[] {
            "Husker", "Starbuck", "Apollo", "Boomer",
            "Bulldog", "Athena", "Helo", "Racetrack"
        };

        public static void Main(string[] args)
        {
            workingWithJSONSerialization();
        }

        public static List<Person> GetPeople()
        {
            return new List<Person>
            {
                new Person(3000M)
                {
                    FirstName = "Alice",
                    LastName = "Smith",
                    DateOfBirth = new DateTime(1974, 3, 14)
                },
                new Person(4000M)
                {
                    FirstName = "Bob",
                    LastName = "Jones",
                    DateOfBirth = new DateTime(1984, 5, 4)
                },

                new Person(2000M)
                {
                    FirstName = "Charlie",
                    LastName = "Cox",
                    DateOfBirth = new DateTime(1984, 5, 4),
                    Children = new HashSet<Person>
                    {
                        new Person(0M)
                        {
                            FirstName = "Sally",
                            LastName = "Cox",
                            DateOfBirth  = new DateTime(2000, 7, 12)
                        }

                    }
                },
            };
        }

        public static void workingWithJSONSerialization()
        {
            string jsonPath = Combine(CurrentDirectory, "people.json");

            var people = GetPeople();

            using (StreamWriter jsonStream  = new StreamWriter(jsonPath))
            {
                var jss = new Newtonsoft.Json.JsonSerializer();

                jss.Serialize(jsonStream, people);
            }

            WriteLine(File.ReadAllText(jsonPath));
        }

        public static void WorkingWithXMLSerialization()
        {
            var people = GetPeople();

            var xs = new XmlSerializer(typeof(List<Person>));

            // create a file to write to 
            string path = Combine(CurrentDirectory, "people.xml");

            using (FileStream stream = File.Create(path))
            { 
                xs.Serialize(stream, people);
            }

            WriteLine($"Written {new FileInfo(path).Length} of XML to {path}");

            WriteLine();

            WriteLine(File.ReadAllText(path));
        }


        public static void WorkingWithEncoding()
        {
            WriteLine("Encodings: ");
            WriteLine("[1] ASCII");
            WriteLine("[2] UTF-7");
            WriteLine("[3] UTF-8");
            WriteLine("[4] UTF-16 (Unicode)");
            WriteLine("[5] UTF-32");
            WriteLine("[any other key] Default");

            // 
            Write("Press a number to choose the encoding");
            ConsoleKey number = ReadKey(intercept: false).Key;
            WriteLine();
            WriteLine();

            Encoding encoder = number switch
            {
                ConsoleKey.D1 => Encoding.ASCII,
                ConsoleKey.D2 => Encoding.UTF7,
                ConsoleKey.D3 => Encoding.UTF8,
                ConsoleKey.D4 => Encoding.Unicode,
                ConsoleKey.D5 => Encoding.UTF32,
                _ => Encoding.Default
            };

            // Define a string to encode 
            string message = "A pint of milk is $1.99";

            // encode the string to the byte array 
            byte[] encoded = encoder.GetBytes(message);

            // check how many bytes have been encoded 
            WriteLine("{0} uses {1:N0} bytes", encoder.GetType().Name, encoded.Length);

            // enumerate each byte 
            WriteLine("BYTE HEX CHAR");
            foreach (byte b in encoded)
            { 
                WriteLine($"{b, 4} {b.ToString("X"), 4} {(char)b, 5}");
            }
        }

        public static void WorkingWithCompression()
        {
            string gzipFilePath = Combine(CurrentDirectory, "streams.gzip");

            FileStream gzipeFile  = File.Create(gzipFilePath);

            using (GZipStream compressor = new GZipStream(gzipeFile, CompressionMode.Compress)) {
                using (XmlWriter xmlGzip = XmlWriter.Create(compressor))
                {
                    xmlGzip.WriteStartDocument();
                    xmlGzip.WriteStartElement("Call Signs");

                    foreach (string item in callsigns)
                    {
                        xmlGzip.WriteElementString("callsign", item);
                    }
                }
            }
        }

        public static void workingWithXMLStreams()
        {
            // Define a file to which content will be written
            string xmlFile = Combine(CurrentDirectory, "streams.xml");

            // create a file stream 
            FileStream xmlFileStream = File.Create(xmlFile);

            // Wrap the writer stream into the XML stream writer 
            XmlWriter xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings { Indent = true });

            // Write the XML declaration 
            xml.WriteStartDocument();

            // Write a root element 
            xml.WriteStartElement("callsigns");

            // Iterate over each item and add it to the stream 
            foreach (string s in callsigns)
            {
                xml.WriteElementString("callsigns", s);
            }

            // write the close root element
            xml.WriteEndElement();

            xml.Close();
            xmlFileStream.Close();
        }

        public static void workingWithStreams()
        {
            // define the file to write to
            string textFile = Combine(CurrentDirectory, "streams.txt");

            // create a text file and return a helper writer 
            StreamWriter text = new StreamWriter(textFile);

            foreach (string s in callsigns) 
            {
                text.WriteLine(s);
            }
            text.Close();

            WriteLine(File.ReadAllText(textFile));
        }

        public static void WorkingWithXML()
        {
            // define a file to write to 
            string xmlFile = Combine(CurrentDirectory, "streams.xml");

            // create a file stream
            FileStream xmlFileStream = File.Create(xmlFile);

            // 
            XmlWriter xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings { Indent = true });

            //
            xml.WriteStartDocument();

            // 
            xml.WriteStartElement("callsigns");

            foreach (string s in callsigns)
            {
                xml.WriteElementString("callsign", s);
            }

            xml.WriteEndElement();
        }

        public static void WorkingWithFiles()
        {
            var dir = Combine(GetFolderPath(SpecialFolder.Personal), "Code", "Chapter09", "Outputfiles");

            CreateDirectory(dir);

            // define file paths 
            string textFile = Combine(dir, "dummy.txt");
            string backupFile = Combine(dir, "dummy.bak");

            WriteLine($"Working with: {textFile}");

            // check if a file exists
            WriteLine($"Does it exists? {File.Exists(textFile)}");

            // create a new text file and write a line to it
            StreamWriter textWriter = File.CreateText( textFile );
            textWriter.Write("Hello, c#");
            textWriter.Flush();
            textWriter.Close();

            WriteLine($"Does it exists? {File.Exists(textFile)}");

            // copy the file and override if it already exists 
            File.Copy( sourceFileName: textFile, destFileName: backupFile, true );

            WriteLine($"Does it exists? {File.Exists(backupFile)}");

            WriteLine($"Confirm that file exits, then press ENTER");
            ReadLine();

            // delete file 
            File.Delete(textFile);

            WriteLine($"Does it exists? {File.Exists(backupFile)}");

            // read from the text file backup
            WriteLine($"Reading contents of {backupFile}");
            StreamReader textReader = File.OpenText( backupFile );
            WriteLine(textReader.ReadToEnd());
            textReader.Close();

            // Managing paths 
            WriteLine($"Folder name: {GetDirectoryName(textFile)}");
            WriteLine($"File name: {GetFileName(textFile)}");
            WriteLine($"File name without extension: {GetFileNameWithoutExtension(textFile)}");
            WriteLine($"File extension: {GetExtension(textFile)}");
            WriteLine($"Random file name: {GetRandomFileName()}");
            WriteLine($"Temp file name: {GetTempFileName()}");


            var info = new FileInfo( backupFile );
            WriteLine($"{backupFile}");
            WriteLine($"Contains {info.Length} bytes");
            WriteLine($"Last accessed {info.LastAccessTime}");
            WriteLine($"Has readonly set to {info.IsReadOnly}");
        }

        public static void WorkWithDirectories()
        {
            var newFolder = Path.Combine(GetFolderPath(SpecialFolder.Personal), "Code", "Chapter9", "NewFolder");

            WriteLine($"Working with {newFolder}");

            // Check if it exists
            WriteLine($"Does it exists? {Directory.Exists(newFolder)}");

            // create directory 
            WriteLine("Creating it.....");
            CreateDirectory(newFolder);
            WriteLine($"Does it exists? {Directory.Exists(newFolder)}");

            WriteLine("Confirm the directory exists, and then press ENTER: ");

            // delete directory 
            WriteLine("Deleting it.....");
            Delete(newFolder, recursive: true);
            WriteLine($"Does it exists? {Directory.Exists(newFolder)}");
        }

        public static void ManageDevices()
        {
            WriteLine("{0, -30} | {1, -10} | {2, -7} | {3, 18} | {4, 18}", "NAME", "TYPE", "FORMAT", "SIZE(bytes)", "FREE SPACE");

            foreach (DriveInfo drive in DriveInfo.GetDrives()) {
                if (drive.IsReady)
                {
                    WriteLine("{0, -30} | {1, -10} | {2, -7} | {3, 18} | {4, 18}",
                        drive.Name, drive.DriveType, drive.DriveFormat, drive.TotalSize, drive.AvailableFreeSpace);
                }
                else
                {
                    WriteLine("{0, -30} | {1, -10}", drive.Name, drive.DriveType);
                }
            }
             
        }

        public static void OutputFileSystemInfo()
        {
            WriteLine($"Path Seperator : {PathSeparator}");
            WriteLine($"Directory Seperator : {DirectorySeparatorChar}");
            WriteLine($"Current Directory : {CurrentDirectory}");
            WriteLine($"System Directory : {SystemDirectory}");
            WriteLine($"Temp Path : {GetTempPath()}");
            WriteLine($"Special Folder : {GetFolderPath(SpecialFolder.System)}");
            WriteLine($"Application Data : {GetFolderPath(SpecialFolder.ApplicationData)}");
            WriteLine($"My Documents : {GetFolderPath(SpecialFolder.MyDocuments)}");
            WriteLine($"Get personal : {GetFolderPath(SpecialFolder.Personal)}");
        }
    }
}