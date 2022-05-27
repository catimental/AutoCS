using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCS.Client.Script.Conversations
{
    [ConversationAttribute("Common")]
    class Common
    {
        public void ShowMessageBox(string message)
        {
            //example
        }

        public void print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
