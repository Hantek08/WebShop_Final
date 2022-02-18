using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop_Final
{
    class UserPage
    {
        public static Models.User mainUser = new Models.User();
        public static void Main_User(Models.User user)
        {
            mainUser = user;
        }
        
        public static void User_Page_Display(out int minVal, out int maxVal)
        {
            DatabaseQuerys.User_List_Menu(out minVal,out maxVal);
        }

        public static void User_Page_Choise(int menuSel, out string ja_Nej)
        {
            DatabaseQuerys.User_List_Choise(menuSel, out ja_Nej);
        }

        public static void User_Admin_Deligation(int menuSel)
        {
            DatabaseQuerys.User_Admin_Deligation(menuSel);
        }


        

    }




}

