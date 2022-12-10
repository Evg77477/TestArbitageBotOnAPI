using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestArbitageBotOnAPI.ViewModel;

namespace TestArbitageBotOnAPI.UserControl
{
    /// <summary>
    /// Логика взаимодействия для ApiSetting.xaml
    /// </summary>
    public partial class ApiSetting : MetroWindow
    {
        public ApiSetting(VM vm)
        {
            InitializeComponent();
            DataContext = vm;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
    }
}
