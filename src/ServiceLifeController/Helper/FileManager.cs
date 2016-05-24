using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public static class FileManager
    {
        public static async Task WriteFileSafelyAsync(string path, string data)
        {
            try
            {
                var pathDir = Path.GetDirectoryName(path);

                if (!Directory.Exists(pathDir))
                    Directory.CreateDirectory(pathDir);

                //Open the File
                using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
                {
                    await sw.WriteAsync(data);

                    //close the file
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}
