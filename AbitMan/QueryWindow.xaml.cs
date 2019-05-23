using System;
using System.Collections.Generic;
using System.Windows;

namespace AbitMan
{
    /// <summary>
    /// Логика взаимодействия для QueryWindow.xaml
    /// </summary>
    public partial class QueryWindow : Window
    {
        private List<string> GroupList = new List<string>();
        private List<string> FacultyList = new List<string>();
        public QueryWindow()
        {
            InitializeComponent();
            HideAllTabs();
        }

        private void AllDataMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (!DBUtils.IsAvailable())
            {
                HideAllTabs();
                MessageBox.Show("Для даного действия нужно подключение к серверу MySQL.\nПодключитесь к ссерверу используя \"Подключить к БД\" главного меню.", "Ошибка");
                return;
            }

            HideAllTabs();
            StudentTabItem.Visibility = Visibility.Visible;
            GroupsTabItem.Visibility = Visibility.Visible;
            DiscipleTabItem.Visibility = Visibility.Visible;
            FacultyTabItem.Visibility = Visibility.Visible;
            N_NTabItem.Visibility = Visibility.Visible;
            StudentTabItem.IsSelected = true;

            StudentDG.Items.Clear();
            GroupsDG.Items.Clear();
            DiscipleDG.Items.Clear();
            FacultyDG.Items.Clear();
            Stud_GroupDG.Items.Clear();
            Group_DiscDG.Items.Clear();

            List<Student> DataList1 = new List<Student>();
            string strQuery = "select * from Student";
            DBUtils.GetFromDB(DataList1, strQuery);
            foreach (Student stud in DataList1)
                StudentDG.Items.Add(stud);

            List<Groups> DataList2 = new List<Groups>();
            strQuery = "select * from Groupz";
            DBUtils.GetFromDB(DataList2, strQuery);
            foreach (Groups group in DataList2)
                GroupsDG.Items.Add(group);

            List<Disciple> DataList3 = new List<Disciple>();
            strQuery = "select * from Disciple";
            DBUtils.GetFromDB(DataList3, strQuery);
            foreach (Disciple disc in DataList3)
                DiscipleDG.Items.Add(disc);

            List<Faculty> DataList4 = new List<Faculty>();
            strQuery = "select * from Faculty";
            DBUtils.GetFromDB(DataList4, strQuery);
            foreach (Faculty facult in DataList4)
                FacultyDG.Items.Add(facult);

            List<Stud_Group> DataList5 = new List<Stud_Group>();
            strQuery = "select * from Stud_Group";
            DBUtils.GetFromDB(DataList5, strQuery);
            foreach (Stud_Group s_g in DataList5)
                Stud_GroupDG.Items.Add(s_g);

            List<Group_Disc> DataList6 = new List<Group_Disc>();
            strQuery = "select * from Group_Disc";
            DBUtils.GetFromDB(DataList6, strQuery);
            foreach (Group_Disc g_d in DataList6)
                Group_DiscDG.Items.Add(g_d);

        }

        private void Query1MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (!DBUtils.IsAvailable())
            {
                HideAllTabs();
                MessageBox.Show("Для даного действия нужно подключение к серверу MySQL.\nПодключитесь к ссерверу используя \"Подключить к БД\" главного меню.", "Ошибка");
                return;
            }
            HideAllTabs();
            Result1TabItem.Visibility = Visibility.Visible;
            Result1TabItem.IsSelected = true;

            //Result1ComBox
            List<Student> DataList = new List<Student>();
            string strQuery = "select * from Student";
            DBUtils.GetFromDB(DataList, strQuery);
            foreach (Student stud in DataList)
                StudentDG.Items.Add(stud);
        }

        private void Query2MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (!DBUtils.IsAvailable())
            {
                HideAllTabs();
                MessageBox.Show("Для даного действия нужно подключение к серверу MySQL.\nПодключитесь к ссерверу используя \"Подключить к БД\" главного меню.", "Ошибка");
                return;
            }
            HideAllTabs();
            Result2TabItem.Visibility = Visibility.Visible;
            Result2TabItem.IsSelected = true;
        }

        private void Query3MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (!DBUtils.IsAvailable())
            {
                HideAllTabs();
                MessageBox.Show("Для даного действия нужно подключение к серверу MySQL.\nПодключитесь к ссерверу используя \"Подключить к БД\" главного меню.", "Ошибка");
                return;
            }
            HideAllTabs();
            Result3TabItem.Visibility = Visibility.Visible;
            Result3TabItem.IsSelected = true;
        }

        private void Query4MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (!DBUtils.IsAvailable())
            {
                HideAllTabs();
                MessageBox.Show("Для даного действия нужно подключение к серверу MySQL.\nПодключитесь к ссерверу используя \"Подключить к БД\" главного меню.", "Ошибка");
                return;
            }
            HideAllTabs();
            Result4TabItem.Visibility = Visibility.Visible;
            Result4TabItem.IsSelected = true;
        }

        private void Query5MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (!DBUtils.IsAvailable())
            {
                HideAllTabs();
                MessageBox.Show("Для даного действия нужно подключение к серверу MySQL.\nПодключитесь к ссерверу используя \"Подключить к БД\" главного меню.", "Ошибка");
                return;
            }
            HideAllTabs();
            Result5TabItem.Visibility = Visibility.Visible;
            Result5TabItem.IsSelected = true;
        }

        private void Query6MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (!DBUtils.IsAvailable())
            {
                HideAllTabs();
                MessageBox.Show("Для даного действия нужно подключение к серверу MySQL.\nПодключитесь к ссерверу используя \"Подключить к БД\" главного меню.", "Ошибка");
                return;
            }
            HideAllTabs();
            Result6TabItem.Visibility = Visibility.Visible;
            Result6TabItem.IsSelected = true;
        }

        private void HideAllTabs()
        {
            StudentTabItem.Visibility = Visibility.Collapsed;
            GroupsTabItem.Visibility = Visibility.Collapsed;
            DiscipleTabItem.Visibility = Visibility.Collapsed;
            FacultyTabItem.Visibility = Visibility.Collapsed;
            N_NTabItem.Visibility = Visibility.Collapsed;
            Result1TabItem.Visibility = Visibility.Collapsed;
            Result2TabItem.Visibility = Visibility.Collapsed;
            Result3TabItem.Visibility = Visibility.Collapsed;
            Result4TabItem.Visibility = Visibility.Collapsed;
            Result5TabItem.Visibility = Visibility.Collapsed;
            Result6TabItem.Visibility = Visibility.Collapsed;
        }

        private void FillComboBoxes()
        {
            GroupList.Clear();
            FacultyList.Clear();
            DBUtils.GetGroupList(GroupList);
            DBUtils.GetFacultyList(FacultyList);
        }

        private void QueryWindow1_Closed(object sender, System.EventArgs e)
        {
            new MainWindow().Show();
        }

        private void Result5ComBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void Result1ComBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void Result2ComBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
