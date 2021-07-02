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
    /// Interaction logic for Calendar.xaml
    /// </summary>
    public partial class Calendar : UserControl
    {
        DataTable calendarNotes;
        public Calendar()
        {
            InitializeComponent();
            calendarNotes = new DataTable();
            calendarNotes.Columns.Add("date", typeof(string));
            DataColumn[] keys = new DataColumn[1];
            keys[0] = calendarNotes.Columns[0];
            calendarNotes.PrimaryKey = keys;
            calendarNotes.Columns.Add("title", typeof(string));
            calendarNotes.Columns.Add("notes", typeof(string));
            //foreach (DataRow o in calendarNotes.Select("date = 'calendar.SelectedDate'"))
            //{
            //    textmsg.Text = o["notes"].ToString();

            //}

        }

        private void delete_clicked(object sender, RoutedEventArgs e)
        {
            if (calendarNotes != null)
                foreach (DataRow row in calendarNotes.Rows)
                {
                    if (row["date"].ToString().Equals(calendar.SelectedDate.ToString()))
                    {
                        row["title"] = "";
                        row["notes"] = "";
                        break;
                    }
                }
            textmsg2.Clear();
            titletmsg.Clear();
            textmsg.Clear();
        }

        private void add_clicked(object sender, RoutedEventArgs e)
        {
            //checking if there is note within that date
            bool check = false;
            DataRow theRow=null;
            if (calendarNotes != null)
                foreach (DataRow row in calendarNotes.Rows)
                {
                    if (row["date"].ToString().Equals(calendar.SelectedDate.ToString()))
                    {
                        theRow = row;
                        check = true;
                        break;
                    }
                }
            if (!check)
            {
                calendarNotes.Rows.Add(calendar.SelectedDate.ToString(), titletmsg.Text, textmsg.Text);
                

            }
            else
            {
                theRow["title"] = titletmsg.Text;
                theRow["notes"] = textmsg.Text;
            }
            textmsg2.Text = titletmsg.Text + "\n" + textmsg.Text;
            titletmsg.Clear();
            textmsg.Clear();
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (textmsg!=null)
                if(calendarNotes!=null)
                foreach(DataRow row in calendarNotes.Rows)
            {
                        if (row["date"].ToString().Equals(calendar.SelectedDate.ToString()))
                        {

                            textmsg2.Text = row["title"].ToString()+"\n"+row["notes"].ToString();

                            break;
                        }
                        else
                            textmsg2.Clear();
                    }
        }

        private void edit_clicked(object sender, RoutedEventArgs e)
        {
            if (textmsg2.Text.Equals(""))
            {
                titletmsg.Text = textmsg2.Text;
                textmsg.Text = textmsg2.Text;
            }
            else
            {
                string s = textmsg2.Text;
                string temp = textmsg2.Text;
                string s1 = s.Split(new string[] { "\n ", "\n" }, 2, StringSplitOptions.None)[0];
                string s2 = temp.Split(new string[] { "\n ", "\n" }, 2, StringSplitOptions.None)[1];
                titletmsg.Text = s1;
                textmsg.Text = s2;
            }
            
        }
    }
}
