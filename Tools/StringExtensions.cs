namespace WebShop_Final
{
    public static class StringExtensions
    {
        //this centers string inputs
        public static string CenterString(this string stringToCenter, int totalLength)
        {
            return stringToCenter.PadLeft(((totalLength - stringToCenter.Length) / 2)
                                + stringToCenter.Length)
                       .PadRight(totalLength);
        }
    }
}
//        private const int TableWidth = 90;

//        public static void PrintSeperatorLine()
//        {
//            Console.WriteLine(new string('-', TableWidth));
//        }

//        public static void PrintRow(params string[] columns)
//        {
//            int columnWidth = (TableWidth - columns.Length) / columns.Length;
//            const string seed = "|";
//            string row = columns.Aggregate(seed, (seperator, columnText) => seperator + GetCenterAllignedText(columnText, columnWidth) + seed);
//            Console.WriteLine(row);
//        }

//        private static string GetCenterAllignedText(String columnText, int columnWidth)
//        {
//            columnText = columnText.Length > columnWidth ? columnText.Substring(0, columnWidth - 3) + "..." : columnText;
//            return string.IsNullOrEmpty(columnText) ? new string(' ', columnWidth) : columnText.PadRight(columnWidth - ((columnWidth - columnText.Length) / 2)).PadLeft(columnWidth);
//        }


//        /*public static class MyExtension
//        {
//            public static void PrintToConsole(this DataTable dt)
//            {
//                int columnWidth = 25; //must be >5
//                int tableWidth = (columnWidth * dt.Columns.Count) + dt.Columns.Count;

//                ResizeTheWindow(tableWidth);

//                Console.WriteLine("");
//                Console.WriteLine("Table name : " + dt.TableName + "\n");

//                #region PRINT THE TABLE HEADER

//                DrawHorizontalSeperator(tableWidth, '=');
//                Console.Write("|");

//                foreach (DataColumn column in dt.Columns)
//                {
//                    string name = (" " + column.ColumnName + " ").PadRight(columnWidth);
//                    Console.Write(name + "|");
//                }
//                Console.WriteLine("");
//                DrawHorizontalSeperator(tableWidth, '=');

//                #endregion

//                #region PRINTING DATA ROWS

//                foreach (DataRow row in dt.Rows)
//                {
//                    Console.Write("|");
//                    foreach (DataColumn column in dt.Columns)
//                    {
//                        string value = (" " + GetShortString(row[column.ColumnName].ToString(), columnWidth) + " ").PadRight(columnWidth);
//                        Console.Write(value + "|");
//                    }
//                    Console.WriteLine("");
//                    DrawHorizontalSeperator(tableWidth, '-');
//                }

//                #endregion

//                Console.WriteLine("");
//            }

//            private static void ResizeTheWindow(int tableWidth)
//            {
//                if (tableWidth > Console.LargestWindowWidth)
//                {
//                    Console.WindowWidth = Console.LargestWindowWidth;
//                    Console.SetWindowPosition(0, 0);
//                }
//                else if (tableWidth > Console.WindowWidth)
//                {
//                    Console.WindowWidth = tableWidth;
//                }
//                else
//                {
//                    // let it be as it is.
//                }
//            }

//            private static void DrawHorizontalSeperator(int width, char seperator)
//            {
//                for (int counter = 0; counter <= width; counter++)
//                {
//                    Console.Write(seperator);
//                }
//                Console.WriteLine("");
//            }

//            private static string GetShortString(string text, int length)
//            {
//                if (text.Length >= length - 1)
//                {
//                    string shortText = text.Substring(0, length - 5) + "...";
//                    return shortText;
//                }
//                else
//                {
//                    return text;
//                }
//            }
//        }*/
//    }
//}
