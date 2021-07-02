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


namespace WpfApp2.Views
{
    /// <summary>
    /// Interaction logic for Notes.xaml
    /// </summary>
    public partial class Notes : UserControl
    {
        DataTable notes; 
        public Notes()
        {
            InitializeComponent();
            notes = new DataTable();
            notes.Columns.Add("title",typeof(string));
            notes.Columns.Add("text", typeof(string));
            dataGrid1.ItemsSource = notes.DefaultView;
            //dataGrid1.Columns["title"].Width = 140;

        }

        private void add_clicked(object sender, RoutedEventArgs e)
        {

            notes.Rows.Add(titletmsg.Text, textmsg.Text);
            titletmsg.Clear();
            textmsg.Clear();
        }

        private void delete_clicked(object sender, RoutedEventArgs e)
        {
            int index = dataGrid1.SelectedIndex;
            if (index > -1)
            {
                notes.Rows[index].Delete();
                textmsg3.Clear();
            }
        }

        private void dataGrid1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            int index = dataGrid1.SelectedIndex;
            if (index > -1)
            {
                textmsg3.Text = notes.Rows[index].ItemArray[0].ToString()+"\n"+ notes.Rows[index].ItemArray[1].ToString();
            }
        }

        private void edit_clicked(object sender, RoutedEventArgs e)
        {
            int index = dataGrid1.SelectedIndex;
            if (textmsg3.Text.Equals(""))
            {
                titletmsg.Text = textmsg3.Text;
                textmsg.Text = textmsg3.Text;
            }
            else
            {
                string s = textmsg3.Text;
                string temp = textmsg3.Text;
                string s1 = s.Split(new string[] { "\n ", "\n" }, 2, StringSplitOptions.None)[0];
                string s2 = temp.Split(new string[] { "\n ", "\n" }, 2, StringSplitOptions.None)[1];
                titletmsg.Text = s1;
                textmsg.Text = s2;
                notes.Rows[index].ItemArray[0] = titletmsg.Text;
                notes.Rows[index].ItemArray[1] = textmsg.Text;
            }
 
        }

        private void makeChanges_clickes(object sender, RoutedEventArgs e)
        {
            int index1 = dataGrid1.SelectedIndex;
            if (index1 > -1)
            {
                DataRow theRow = notes.Rows[index1];
                theRow["title"] = titletmsg.Text;
                theRow["text"] = textmsg.Text;
            }

        }
    }
}
