using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SharedControllerHelper
{
    public static class FileManager
    {
        public static string DefaultApplicationDataPath => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
            SharedControllerHelper.SharedLinks.SettingFileName);


        public static bool WriteFileSafely(string path, string data)
        {
            try
            {
                var pathDir = Path.GetDirectoryName(path);

                if (!Directory.Exists(pathDir))
                    Directory.CreateDirectory(pathDir);

                //Open the File
                File.WriteAllText(path, data, Encoding.UTF8);

                return true;
            }
            catch (Exception e)
            {
                WindowsEventLog.WriteErrorLog("Exception in FileManager: " + e.Message);
            }

            return false;
        }


        public static string ReadFileSafely(string path)
        {
            try
            {
                if (!File.Exists(path)) return null;

                return File.ReadAllText(path, Encoding.UTF8);
            }
            catch (Exception e)
            {
                WindowsEventLog.WriteErrorLog("Exception in FileManager: " + e.Message);
            }

            return null;
        }

        public static string ReadResourceFile(string path)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"{assembly.GetName().Name}.{path}";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string result = reader.ReadToEnd();
                    return result;
                }
            }
        }
    }
}
