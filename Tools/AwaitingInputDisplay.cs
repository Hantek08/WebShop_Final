using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop_Final
{
    class AwaitingInputDisplay
    {
        public static string FlashyInput()
        {
            var table = new Table();
            table.SetHeaders(StringExtensions.CenterString("CHOOSE FROM THE MENU", 25));           
            Console.WriteLine(table.ToString());
            return Console.ReadLine();
        }
    }
}
