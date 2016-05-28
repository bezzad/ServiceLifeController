using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SharedControllerHelper
{
    public static class HelperExtensions
    {
        public static DataTable ToDataTable(this object[] data)
        {
            var dt = new DataTable();

            if (!data.Any()) return dt;

            // Get header
            var dapperRowProperties = (data[0] as IDictionary<string, object>).Keys;
            foreach (string col in dapperRowProperties)
            {
                dt.Columns.Add(col);
            }
            //
            // Get details
            foreach (IDictionary<string, object> item in data)
            {
                var row = dt.Rows.Add();
                foreach (string prop in dapperRowProperties)
                {
                    row[prop] = item[prop].ToString();
                }
            }

            return dt;
        }

        public static DataTable ToDataTable(this IEnumerable<dynamic> data)
        {
            return data.ToArray().ToDataTable();
        }

        public static DataTable ToDataTable<T>(this IEnumerable<T> data)
        {
            var dt = new DataTable();

            var srcAry = data as T[] ?? data.ToArray();

            if (!srcAry.Any()) return dt;

            // Get header

            foreach (var col in typeof(T).GetProperties())
            {
                dt.Columns.Add(col.Name, col.PropertyType);
            }
            //
            // Get details
            foreach (var item in srcAry)
            {
                var row = dt.Rows.Add();
                foreach (var prop in typeof(T).GetProperties())
                {
                    row[prop.Name] = prop.GetValue(item);
                }
            }

            return dt;
        }

        public static T ToObject<T>(this DataRow row) where T : new()
        {
            var res = new T();

            foreach (var prop in typeof(T).GetProperties())
            {
                prop.SetValue(res, row[prop.Name]);
            }

            return res;
        }


        public static T ToObject<T>(this DataGridViewRow row) where T : new()
        {
            var res = new T();

            foreach (var prop in typeof(T).GetProperties())
            {
                prop.SetValue(res, row.Cells[prop.Name].Value == DBNull.Value ? null : row.Cells[prop.Name].Value);
            }

            return res;
        }
    }
}
