using System;
using Microsoft.Win32;

namespace SharedControllerHelper
{
    /// <summary>
    /// All Registry Entry store in Local Machine Type
    /// Path of Local machine - HEKY_LOCAL_MACHINE
    /// </summary>
    public static class RegistryHelper
    {
        #region Field

        private static RegistryKey _registryKeyObj;
        private static readonly RegistryKey Rkp = Registry.CurrentUser; // Registry.LocalMachine
             
        #endregion

        #region Methods

        /// <summary>
        /// Creates a registry entry at the given path with given key and value
        /// </summary>
        /// <param name="path">Specify the Path to Create Registry Entry</param>
        /// <param name="key">Specify Name of the Key</param>
        /// <param name="value">Specify Value of the Key</param>
        /// <returns>Boolean</returns>
        public static bool Write(string path, string key, object value)
        {
            try
            {
                // Create a New SubKey
                Rkp.CreateSubKey(path);
                // Open a Sub Key for Write Value
                _registryKeyObj = Rkp.OpenSubKey(path, true);
                // Set the Specified Key and Value
                _registryKeyObj?.SetValue(key, value);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Rkp.Dispose();
                _registryKeyObj?.Dispose();
                _registryKeyObj = null;
            }
        }

        /// <summary>
        /// Reads the registry value at the given path with the given key name
        /// </summary>
        /// <typeparam name="T">Specify the Return Type</typeparam>
        /// <param name="path">Specify the Path for Read Value</param>
        /// <param name="key">Specify the Key</param>
        /// <returns>T</returns>
        public static T Read<T>(string path, string key)
        {
            try
            {
                //  Open a Sub Key for Read Value
                _registryKeyObj = Rkp.OpenSubKey(path, false);
                // Get Value by given Key
                return (T)_registryKeyObj?.GetValue(key);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Rkp.Dispose();
                _registryKeyObj?.Dispose();
                _registryKeyObj = null;
            }
        }

        /// <summary>
        /// Deletes the registry entry at the given path
        /// </summary>
        /// <param name="path">Specify the Path</param>
        /// <returns>Boolean</returns>
        public static bool Delete(string path)
        {
            try
            {
                // Delete the Specified Sub Key
                Rkp.DeleteSubKey(path);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Rkp.Dispose();
            }
        }

        /// <summary>
        ///  Deletes the registry entry at the given Key
        /// </summary>
        /// <param name="path">Specify the Path</param>
        /// <param name="key">Specify the Key</param>
        /// <returns>Boolean</returns>
        public static bool Delete(string path, string key)
        {
            try
            {
                //  Open a Sub Key for Delete Value
                _registryKeyObj = Rkp.OpenSubKey(path, true);
                // Delete the Specified Value from this Key
                _registryKeyObj?.DeleteValue(key);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Rkp.Dispose();
                _registryKeyObj?.Dispose();
                _registryKeyObj = null;
            }
        }

        #endregion
    }
}
