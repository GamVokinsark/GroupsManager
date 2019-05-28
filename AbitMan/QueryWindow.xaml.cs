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
        MainWindow root;
        public QueryWindow(MainWindow r)
        {
            root = r;
            InitializeComponent();
            HideAllTabs();
            FillComboBoxes();
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

            Result3DG.Items.Clear();
            List<Res3Storage> DataList = new List<Res3Storage>();
            string strQuery = "select FName, Course, GName, COUNT(s.SID) Num " +
                              "from Student s " +
                              "join Stud_Group sg on (s.SID = sg.SID) " +
                              "join Groupz g on (sg.GID = g.GID) " +
                              "join Faculty f on (f.FID = g.FID) " +
                              "where IsTemp = false " +
                              "group by FName, Course, Gname;";
            DBUtils.GetFromDB(DataList, strQuery);
            foreach (Res3Storage res3 in DataList)
                Result3DG.Items.Add(res3);
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

            Result4DG.Items.Clear();
            List<Res4Storage> DataList = new List<Res4Storage>();
            string strQuery = "select SName, Surname, GName, Course " +
                              "from Student s " +
                              "join Groupz g on (s.SID = g.Starosta) " +
                              "where GName = (select GName " +
                                             "from(select GName, COUNT(sg.SID) Num " +
                                                  "from Stud_Group sg " +
                                                  "join Groupz g on (sg.GID = g.GID) " +
                                                  "group by GName " +
                                                  "order by 2 DESC " +
                                                  "Limit 1 " +
                                                  ") tempTable " +
                                            ");";
            DBUtils.GetFromDB(DataList, strQuery);
            foreach (Res4Storage res4 in DataList)
                Result4DG.Items.Add(res4);
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

            Result6DG.Items.Clear();
            List<Res6Storage> DataList = new List<Res6Storage>();
            string strQuery = "select Title, COUNT(sg.SID) Num " +
                              "from Groupz g " +
                              "join Stud_Group sg on (sg.GID = g.GID) " +
                              "join Group_Disc gd on (gd.GID = g.GID) " +
                              "join Disciple d on (d.DID = gd.DID) " +
                              "group by Title " +
                              "order by 2 DESC " +
                              "Limit 3;";
            DBUtils.GetFromDB(DataList, strQuery);
            foreach (Res6Storage res6 in DataList)
                Result6DG.Items.Add(res6);
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
            Result1ComBox.Items.Clear();
            Result2ComBox.Items.Clear();
            Result5ComBox.Items.Clear();
            foreach (string gr in GroupList)
            {
                Result1ComBox.Items.Add(gr);
                Result5ComBox.Items.Add(gr);
            }
            foreach (string fl in FacultyList)
                Result2ComBox.Items.Add(fl);
        }

        private void QueryWindow1_Closed(object sender, System.EventArgs e)
        {
            root.Appear();
        }

        private void Result5ComBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Result5DG.Items.Clear();
            string param = Result5ComBox.SelectedValue.ToString();
            List<Res5Storage> DataList = new List<Res5Storage>();
            string strQuery = "select GName, AVG(HoursCount) AvgHours " +
                              "from Groupz g " +
                              "join Group_Disc gd on (gd.GID = g.GID) " +
                              "join Disciple d on (d.DID = gd.DID) " +
                              "where GName = @Group " +
                              "group by GName;";
            DBUtils.GetFromDB(DataList, strQuery, param);
            foreach (Res5Storage res5 in DataList)
                Result5DG.Items.Add(res5);
        }

        private void Result1ComBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Result1DG.Items.Clear();
            string param = Result1ComBox.SelectedValue.ToString();
            List<Res1Storage> DataList = new List<Res1Storage>();
            string strQuery = "select SName, Surname, GName, Course " +
                              "from Student s " +
                              "join Stud_Group sg on (s.SID = sg.SID) " +
                              "join Groupz g on (sg.GID = g.GID) " +
                              "where GName = @Group;";
            DBUtils.GetFromDB(DataList, strQuery, param);
            foreach (Res1Storage res1 in DataList)
                Result1DG.Items.Add(res1);
        }

        private void Result2ComBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Result2DG.Items.Clear();
            string param = Result2ComBox.SelectedValue.ToString();
            List<Res2Storage> DataList = new List<Res2Storage>();
            string strQuery = "select SName, Surname, GName, FName, Course " +
                              "from Student s " +
                              "join Groupz g on (g.Starosta = s.SID) " +
                              "join Faculty f on (f.FID = g.FID) " +
                              "where FName = @Faculty;";
            DBUtils.GetFromDB(DataList, strQuery, param);
            foreach (Res2Storage res2 in DataList)
                Result2DG.Items.Add(res2);
        }
    }
}
