using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System;
using System.Linq;

namespace WinS7Library.Helper.Exporter
{
    /// <summary>
    /// Using Reflection to create a DataTable from a Class
    /// https://stackoverflow.com/questions/18746064/using-reflection-to-create-a-datatable-from-a-class
    /// </summary>
    public class DataTableConverter
    {
        public static DataTable CreateDataTable<T>(IEnumerable<T> list)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();

            properties = properties
                .Where(x => x.CustomAttributes
                .All(y => y.AttributeType.Name != "IgnoreAttribute"))
                .ToArray();

            DataTable dataTable = new DataTable();
            dataTable.TableName = typeof(T).FullName;
            foreach (PropertyInfo info in properties)
            {
                //var columnName = info.Name    // original code

                var columnName = (info.CustomAttributes
                    .FirstOrDefault(x => x.AttributeType.Name == "NameAttribute")?.ConstructorArguments
                    .FirstOrDefault().Value?
                    .ToString()) 
                    ?? info.Name;

                dataTable.Columns.Add(new DataColumn(columnName, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }

            foreach (T entity in list)
            {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(entity);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }
}
