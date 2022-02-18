using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop_Final.Tools
{
    class TextWraping
    {

        public static string WrapIt(string sentence)
        {
            int myLimit = 50;
            
            string[] words = sentence.Split(' ');

            StringBuilder newSentence = new StringBuilder();


            string line = "";
            foreach (string word in words)
            {
                if ((line + word).Length > myLimit)
                {
                    newSentence.AppendLine(line);
                    line = "";
                }

                line += string.Format("{0} ", word);
            }

            if (line.Length > 0)
                newSentence.AppendLine(line);

            return newSentence.ToString();
        }
    }
}
