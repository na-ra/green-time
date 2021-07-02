using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp2.ViewModels;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
 

        public MainWindow()
        {
            InitializeComponent();
      
        }

        private void Calendar_clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new CalendarViewModel();
        }

        private void Notes_clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new NotesViewModel();
        }

        private void Board_clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new BoardViewModel();
        }

        private void GroupBoard_clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new GroupBoardViewModel();
        }
    }
}
