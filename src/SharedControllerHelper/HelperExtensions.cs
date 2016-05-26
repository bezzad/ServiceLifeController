using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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
    }
}
