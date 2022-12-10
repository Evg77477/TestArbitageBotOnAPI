using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestArbitageBotOnAPI.Entity
{
    public class MessageBoxService : IMessageBoxService
    {
        public MessageBoxResult ShowMessage(string text, string caption, MessageBoxButton messageButtons, MessageBoxImage messageIcon)
        {
            return System.Windows.MessageBox.Show(text, caption, messageButtons, messageIcon);
        }
    }
}
