﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvReader
{
    public class Writer
    {
        public static string CreateCSVTextFile<T>(List<T> data)
        {
            var properties = typeof(T).GetProperties();
            var result = new StringBuilder();

            foreach (var item in properties)
            {
                result.Append(item.Name+",");               
            }
            result = result.Remove(result.Length - 1, 1);
            result.AppendLine();
            foreach (var row in data)
            {
                var values = properties.Select(p => p.GetValue(row, null))
                                       .Select(v => StringToCSVCell(Convert.ToString(v)));
                var line = string.Join(",", values);
                result.AppendLine(line);
            }

            return result.ToString();
        }

        private static string StringToCSVCell(string str)
        {
            bool mustQuote = (str.Contains(",") || str.Contains("\"") || str.Contains("\r") || str.Contains("\n"));
            if (mustQuote)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("\"");
                foreach (char nextChar in str)
                {
                    sb.Append(nextChar);
                    if (nextChar == '"')
                        sb.Append("\"");
                }
                sb.Append("\"");
                return sb.ToString();
            }

            return str;
        }
    }
}
