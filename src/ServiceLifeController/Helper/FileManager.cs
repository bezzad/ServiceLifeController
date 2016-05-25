using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helper
{
    public static class FileManager
    {
        public static string DefaultApplicationDataPath => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
            ServiceLifeController.Properties.Settings.Default.SettingFileName);


        public static async Task<bool> WriteFileSafelyAsync(string path, string data)
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

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message);
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
                MessageBox.Show("Exception: " + e.Message);
            }

            return null;
        }
    }
}
