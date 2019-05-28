using MySql.Data.MySqlClient;
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

namespace AbitMan
{
    /// <summary>
    /// Логика взаимодействия для ManipulationsWindow.xaml
    /// </summary>
    public partial class ManipulationsWindow : Window
    {
        private List<Student> SList = new List<Student>();
        private List<Groups> GList = new List<Groups>();
        private List<Disciple> DList = new List<Disciple>();
        private List<Faculty> FList = new List<Faculty>();
        private List<Stud_Group> SGList = new List<Stud_Group>();
        private List<Group_Disc> GDList = new List<Group_Disc>();
        private string[] ZvitFormsList =  { "Zalik", "Examen"};
        MainWindow root;
        public ManipulationsWindow(MainWindow r)
        {
            root = r;
            InitializeComponent();
            FillStudentList();
            StudChangeIdComBox.SelectedIndex = 0;
            StudDelComBox.SelectedIndex = 0;
            for(int i = 0; i < 100; i++)
            {
                DiscAddHCountComBox.Items.Add(i);
                DiscChangeHCountComBox.Items.Add(i);
            }
            DiscAddHCountComBox.SelectedIndex = 0;
            DiscChangeHCountComBox.SelectedIndex = 0;
            foreach (Student stud in SList)
            {
                StudentDG.Items.Add(stud);
                StudChangeIdComBox.Items.Add(stud.SID+": "+stud.SName+" "+stud.Surname);
                StudDelComBox.Items.Add(stud.SID + ": " + stud.SName + " " + stud.Surname);
            }
        }

        private void FillStudentList()
        {
            SList.Clear();
            SList.Add(new Student("NULL", "Не выбрано", "", ""));
            DBUtils.GetFromDB(SList, "select * from Student;");
        }

        private void FillGoupList()
        {
            GList.Clear();
            GList.Add(new Groups("NULL", "", "", "Не выбрано", ""));
            DBUtils.GetFromDB(GList, "select * from Groupz;");
        }

        private void FillDiscipleList()
        {
            DList.Clear();
            DList.Add(new Disciple("NULL", "Не выбрано", "", ""));
            DBUtils.GetFromDB(DList, "select * from Disciple;");
        }

        private void FillFacultyList()
        {
            FList.Clear();
            FList.Add(new Faculty("NULL", "Не выбрано"));
            DBUtils.GetFromDB(FList, "select * from Faculty;");
        }

        private void FillStudGroupList()
        {
            SGList.Clear();
            SGList.Add(new Stud_Group("NULL", "Не выбрано"));
            DBUtils.GetFromDB(SGList, "select * from Stud_Group");
        }

        private void FillGroupDiscList()
        {
            GDList.Clear();
            GDList.Add(new Group_Disc("NULL", "Не выбрано"));
            DBUtils.GetFromDB(GDList, "select * from Group_Disc");
        }

        private void ManipWindos_Closed(object sender, EventArgs e)
        {
            root.Appear();
        }

        private void StudentInitialisation()
        {
            StudAddNameText.Text = "";
            StudAddSurnText.Text = "";
            StudChangeNameText.Text = "";
            StudChangeSurnText.Text = "";
            StudentDG.Items.Clear();
            StudChangeIdComBox.Items.Clear();
            StudDelComBox.Items.Clear();
            FillStudentList();
            StudChangeIdComBox.SelectedIndex = 0;
            StudDelComBox.SelectedIndex = 0;
            foreach (Student stud in SList)
            {
                if(stud.SID!="NULL")
                    StudentDG.Items.Add(stud);
                StudChangeIdComBox.Items.Add(stud.SID + ": " + stud.SName + " " + stud.Surname);
                StudDelComBox.Items.Add(stud.SID + ": " + stud.SName + " " + stud.Surname);
            }

        }

        private void GroupsInitialisation()
        {
            GroupAddTitleText.Text = "";
            GroupChangeTitleText.Text = "";
            GroupsDG.Items.Clear();
            GroupChangeIdComBox.Items.Clear();
            GroupDelComBox.Items.Clear();
            GroupAddStarostaComBox.Items.Clear();
            GroupChangeStarostaComBox.Items.Clear();
            GroupAddFacultyComBox.Items.Clear();
            GroupChangeFacultyComBox.Items.Clear();
            FillGoupList();
            FillStudentList();
            FillFacultyList();
            GroupChangeIdComBox.SelectedIndex = 0;
            GroupDelComBox.SelectedIndex = 0;
            GroupAddStarostaComBox.SelectedIndex = 0;
            GroupChangeStarostaComBox.SelectedIndex = 0;
            GroupAddFacultyComBox.SelectedIndex = 0;
            GroupChangeFacultyComBox.SelectedIndex = 0;
            foreach (Groups gr in GList)
            {
                if(gr.GID!="NULL")
                    GroupsDG.Items.Add(gr);
                GroupChangeIdComBox.Items.Add(gr.GID+": "+gr.GName);
                GroupDelComBox.Items.Add(gr.GID +": "+gr.GName);
            }
            foreach(Student stud in SList)
            {
                GroupAddStarostaComBox.Items.Add(stud.SName+" "+stud.Surname);
                GroupChangeStarostaComBox.Items.Add(stud.SName+" "+stud.Surname);
            }
            foreach(Faculty fa in FList)
            {
                GroupAddFacultyComBox.Items.Add(fa.FName);
                GroupChangeFacultyComBox.Items.Add(fa.FName);
            }
        }

        private void DiscipleInitialisation()
        {
            DiscAddTitleText.Text = "";
            DiscChangeTitleText.Text = "";
            DiscipleDG.Items.Clear();
            DiscChangeIdComBox.Items.Clear();
            DiscDelComBox.Items.Clear();
            FillDiscipleList();
            DiscAddHCountComBox.SelectedIndex = 0;
            DiscAddZvitFormComBox.SelectedIndex = 0;
            DiscChangeIdComBox.SelectedIndex = 0;
            DiscChangeZvitFormComBox.SelectedIndex = 0;
            DiscChangeHCountComBox.SelectedIndex = 0;
            DiscDelComBox.SelectedIndex = 0;
            foreach(Disciple disc in DList)
            {
                if(disc.DID!="NULL")
                    DiscipleDG.Items.Add(disc);
                DiscChangeIdComBox.Items.Add(disc.DID +": "+disc.DName);
                DiscDelComBox.Items.Add(disc.DID + ": " + disc.DName);
            }
        }

        private void FacultyInitialisation()
        {
            FacultAddTitleText.Text = "";
            FacultChangeTitleText.Text = "";
            FacultyDG.Items.Clear();
            FacultChangeIdComBox.Items.Clear();
            FacultDelComBox.Items.Clear();
            FillFacultyList();
            FacultChangeIdComBox.SelectedIndex = 0;
            FacultDelComBox.SelectedIndex = 0;
            foreach(Faculty fa in FList)
            {
                if(fa.FID!="NULL")
                    FacultyDG.Items.Add(fa);
                FacultChangeIdComBox.Items.Add(fa.FID+": "+fa.FName);
                FacultDelComBox.Items.Add(fa.FID +": "+fa.FName);
            }
        }

        private void N_NInitialisation()
        {
            Stud_GroupDG.Items.Clear();
            N_NSGAddStudComBox.Items.Clear();
            N_NSGAddGroupComBox.Items.Clear();
            N_NSGChangeIdComBox.Items.Clear();
            N_NSGChangeStudComBox.Items.Clear();
            N_NSGChangeGroupComBox.Items.Clear();
            N_NSGDelIdComBox.Items.Clear();
            Group_DiscDG.Items.Clear();
            N_NGDAddGroupComBox.Items.Clear();
            N_NGDAddDiscComBox.Items.Clear();
            N_NGDChangeIdComBox.Items.Clear();
            N_NGDChangeGroupComBox.Items.Clear();
            N_NGDChangeDiscComBox.Items.Clear();
            N_NGDDelIdComBox.Items.Clear();
            FillStudGroupList();
            FillGroupDiscList();
            FillStudentList();
            FillGoupList();
            FillDiscipleList();
            N_NSGAddStudComBox.SelectedIndex = 0;
            N_NSGAddGroupComBox.SelectedIndex = 0;
            N_NSGChangeIdComBox.SelectedIndex = 0;
            N_NSGChangeStudComBox.SelectedIndex = 0;
            N_NSGChangeGroupComBox.SelectedIndex = 0;
            N_NSGDelIdComBox.SelectedIndex = 0;
            N_NGDAddGroupComBox.SelectedIndex = 0;
            N_NGDAddDiscComBox.SelectedIndex = 0;
            N_NGDChangeIdComBox.SelectedIndex = 0;
            N_NGDChangeGroupComBox.SelectedIndex = 0;
            N_NGDChangeDiscComBox.SelectedIndex = 0;
            N_NGDDelIdComBox.SelectedIndex = 0;
            foreach (Stud_Group sg in SGList)
            {
                if(sg.SID!="NULL")
                    Stud_GroupDG.Items.Add(sg);
                if(sg.SID=="NULL")
                {
                    N_NSGChangeIdComBox.Items.Add("NULL: Не выбрано - NULL: Не выбрано");
                    N_NSGDelIdComBox.Items.Add("NULL: Не выбрано - NULL: Не выбрано");
                    continue;
                }
                N_NSGChangeIdComBox.Items.Add(sg.SID+": "+
                    SList.Where(t=>t.SID==sg.SID).First().SName+" "+
                    SList.Where(t=>t.SID==sg.SID).First().Surname+" - "+
                    sg.GID+": "+
                    GList.Where(t=>t.GID==sg.GID).First().GName);
                N_NSGDelIdComBox.Items.Add(sg.SID +": "+
                    SList.Where(t=>t.SID==sg.SID).First().SName+" "+
                    SList.Where(t=>t.SID==sg.SID).First().Surname+" - "+
                    sg.GID + ": "+
                    GList.Where(t=>t.GID==sg.GID).First().GName);
            }
            foreach(Student stud in SList)
            {
                N_NSGAddStudComBox.Items.Add(stud.SName+" "+stud.Surname);
                N_NSGChangeStudComBox.Items.Add(stud.SName+" "+stud.Surname);
            }
            foreach(Groups gr in GList)
            {
                N_NSGAddGroupComBox.Items.Add(gr.GName);
                N_NSGChangeGroupComBox.Items.Add(gr.GName);
                N_NGDAddGroupComBox.Items.Add(gr.GName);
                N_NGDChangeGroupComBox.Items.Add(gr.GName);
            }
            foreach(Disciple disc in DList)
            {
                N_NGDAddDiscComBox.Items.Add(disc.DName);
                N_NGDChangeDiscComBox.Items.Add(disc.DName);
            }
            foreach(Group_Disc gd in GDList)
            {
                if(gd.GID!="NULL")
                    Group_DiscDG.Items.Add(gd);
                if (gd.GID == "NULL")
                {
                    N_NGDChangeIdComBox.Items.Add("NULL: Не выбрано - NULL: Не выбрано");
                    N_NGDDelIdComBox.Items.Add("NULL: Не выбрано - NULL: Не выбрано");
                    continue;
                }
                N_NGDChangeIdComBox.Items.Add(gd.GID +": "+
                    GList.Where(t=>t.GID==gd.GID).First().GName +" - "+
                    gd.DID +": "+
                    DList.Where(t=>t.DID==gd.DID).First().DName);
                N_NGDDelIdComBox.Items.Add(gd.GID +": "+
                    GList.Where(t=>t.GID==gd.GID).First().GName+" - "+
                    gd.DID +": "+
                    DList.Where(t=>t.DID==gd.DID).First().DName);
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(e.Source is TabControl))
                return;

            if (((TabControl)sender).SelectedIndex < 0)
                return;
            switch(((TabControl)sender).SelectedIndex)
            {
                case 0:
                    StudentInitialisation();
                    break;
                case 1:
                    GroupsInitialisation();
                    break;
                case 2:
                    DiscipleInitialisation();
                    break;
                case 3:
                    FacultyInitialisation();
                    break;
                case 4:
                    N_NInitialisation();
                    break;
                default:
                    break;
            }
        }

        private void StudAddButton_Click(object sender, RoutedEventArgs e)
        {
            if(StudAddNameText.Text == "" || StudAddSurnText.Text == "")
            {
                MessageBox.Show("Не задано имя и/или фамилия!", "Ошибка");
                return;
            }
            MySqlCommand msc = new MySqlCommand("insert into Student(SName,Surname,Course) values(@nm,@srnm,@crs);");
            msc.Parameters.Add("@nm", StudAddNameText.Text);
            msc.Parameters.Add("@srnm", StudAddSurnText.Text);
            msc.Parameters.Add("@crs", StudAddComBox.SelectedIndex+1);
            DBUtils.DataManipulate(msc);
            StudentInitialisation();
        }

        private void StudChangeIdComBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int cur = StudChangeIdComBox.SelectedIndex;
            if (cur < 0)
                return;
            if(cur == 0)
            {
                StudChangeCoursComBox.SelectedIndex = 0;
                StudChangeNameText.Text = "";
                StudChangeSurnText.Text = "";
                return;
            }
            StudChangeCoursComBox.SelectedIndex = int.Parse(SList[cur].Course)-1;
            StudChangeNameText.Text = SList[cur].SName;
            StudChangeSurnText.Text = SList[cur].Surname;
        }

        private void StudChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (StudChangeIdComBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Не выбран студент для изменения!", "Ошибка");
                return;
            }
            if (StudChangeNameText.Text == "" || StudChangeSurnText.Text == "")
            {
                MessageBox.Show("Не задано имя и/или фамилия!", "Ошибка");
                return;
            }
            MySqlCommand msc = new MySqlCommand("update Student set SName=@nm, Surname=@srnm, Course=@crs where SID=@Id;");
            msc.Parameters.Add("@nm", StudChangeNameText.Text);
            msc.Parameters.Add("@srnm", StudChangeSurnText.Text);
            msc.Parameters.Add("@crs", StudChangeCoursComBox.SelectedIndex + 1);
            msc.Parameters.Add("@Id", int.Parse(SList.ElementAt(StudChangeIdComBox.SelectedIndex).SID));
            DBUtils.DataManipulate(msc);
            StudentInitialisation();
        }

        private void StudDelButton_Click(object sender, RoutedEventArgs e)
        {
            if (StudDelComBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Не выбран студент для удаления!", "Ошибка");
                return;
            }
            MySqlCommand msc = new MySqlCommand("delete from Student where SID=@Id");
            msc.Parameters.Add("@Id", int.Parse(SList.ElementAt(StudDelComBox.SelectedIndex).SID));
            DBUtils.DataManipulate(msc);
            StudentInitialisation();
        }

        private void GroupAddButton_Click(object sender, RoutedEventArgs e)
        {
            if(GroupAddTitleText.Text == "")
            {
                MessageBox.Show("Не задано название группы!", "Ошибка");
                return;
            }
            if (GroupAddStarostaComBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Не выбран староста!", "Ошибка");
                return;
            }
            if (GroupAddFacultyComBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Не выбран факультет!", "Ошибка");
                return;
            }
            MySqlCommand msc = new MySqlCommand("insert into Groupz(Starosta,FID,GName,IsTemp) values(@str,@fid,@gnm,@ist);");
            msc.Parameters.Add("@str", int.Parse(SList.ElementAt(GroupAddStarostaComBox.SelectedIndex).SID));
            msc.Parameters.Add("@fid", int.Parse(FList.ElementAt(GroupAddFacultyComBox.SelectedIndex).FID));
            msc.Parameters.Add("@gnm", GroupAddTitleText.Text);
            msc.Parameters.Add("@ist", GroupAddIsTempChB.IsChecked.Value);
            DBUtils.DataManipulate(msc);
            GroupsInitialisation();
        }

        private void GroupChangeIdComBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int cur = GroupChangeIdComBox.SelectedIndex;
            if (cur < 0)
                return;
            if(cur == 0)
            {
                GroupChangeTitleText.Text = "";
                GroupChangeStarostaComBox.SelectedIndex = 0;
                GroupChangeFacultyComBox.SelectedIndex = 0;
                GroupChangeIsTempChB.IsChecked = false;
                return;
            }
            GroupChangeTitleText.Text = GList[cur].GName;
            for(int i = 0; i < SList.Count; i++)
                if(SList[i].SID==GList[cur].Starosta)
                {
                    GroupChangeStarostaComBox.SelectedIndex = i;
                    break;
                }
            for(int i = 0; i < FList.Count; i++)
                if(FList[i].FID==GList[cur].FID)
                {
                    GroupChangeFacultyComBox.SelectedIndex = i;
                    break;
                }
            if (GList[cur].IsTemp == "True")
                GroupChangeIsTempChB.IsChecked = true;
            else
                GroupChangeIsTempChB.IsChecked = false;
        }

        private void GroupChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if(GroupChangeIdComBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Не выбрано группу для изменения!", "Ошибка");
                return;
            }
            if(GroupChangeTitleText.Text == "")
            {
                MessageBox.Show("Не задано название группы!", "Ошибка");
                return;
            }
            if(GroupChangeStarostaComBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Не выбрано старосту!", "Ошибка");
                return;
            }
            if (GroupChangeFacultyComBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Не выбрано факультет!", "Ошибка");
                return;
            }
            MySqlCommand msc = new MySqlCommand("update Groupz set Starosta=@str, FID=@fid, GName=@gnm, IsTemp=@ist where GID=@gid;");
            msc.Parameters.Add("@gid", int.Parse(GList.ElementAt(GroupChangeIdComBox.SelectedIndex).GID));
            msc.Parameters.Add("@str", int.Parse(SList.ElementAt(GroupChangeStarostaComBox.SelectedIndex).SID));
            msc.Parameters.Add("@fid", int.Parse(FList.ElementAt(GroupChangeFacultyComBox.SelectedIndex).FID));
            msc.Parameters.Add("@gnm", GroupChangeTitleText.Text);
            msc.Parameters.Add("@ist", GroupChangeIsTempChB.IsChecked.Value);
            DBUtils.DataManipulate(msc);
            GroupsInitialisation();
        }

        private void GroupDelButton_Click(object sender, RoutedEventArgs e)
        {
            if (GroupDelComBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Не выбрана группа для удаления!", "Ошибка");
                return;
            }
            MySqlCommand msc = new MySqlCommand("delete from Groupz where GID=@gid");
            msc.Parameters.Add("@gid", int.Parse(GList.ElementAt(GroupDelComBox.SelectedIndex).GID));
            DBUtils.DataManipulate(msc);
            GroupsInitialisation();
        }

        private void DiscAddButton_Click(object sender, RoutedEventArgs e)
        {
            if(DiscAddTitleText.Text == "")
            {
                MessageBox.Show("Не выбрано название для дисциплины!", "Ошибка");
                return;
            }
            if(DiscAddHCountComBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Не выбрано количество часов!", "Ошибка");
                return;
            }
            if(DiscAddZvitFormComBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Не выбрано форму отчетности!", "Ошибка");
                return;
            }
            MySqlCommand msc = new MySqlCommand("insert into Disciple(Title,ZvitForm,HoursCount) values(@title,@zvitf,@hcount);");
            msc.Parameters.Add("@title", DiscAddTitleText.Text);
            msc.Parameters.Add("@zvitf", ZvitFormsList[DiscAddZvitFormComBox.SelectedIndex-1]);
            msc.Parameters.Add("@hcount", DiscAddHCountComBox.SelectedValue);
            DBUtils.DataManipulate(msc);
            DiscipleInitialisation();
        }

        private void DiscChangeIdComBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int cur = DiscChangeIdComBox.SelectedIndex;
            if (cur < 0)
                return;
            if(cur == 0)
            {
                DiscChangeTitleText.Text = "";
                DiscChangeZvitFormComBox.SelectedIndex = 0;
                DiscChangeHCountComBox.SelectedIndex = 0;
                return;
            }
            DiscChangeTitleText.Text = DList[cur].DName;
            DiscChangeHCountComBox.SelectedIndex = int.Parse(DList[cur].HoursCount);
            for (int i = 0; i < ZvitFormsList.Length; i++)
                if (ZvitFormsList[i] == DList[cur].ZvitForm)
                    DiscChangeZvitFormComBox.SelectedIndex = i+1;
        }

        private void DiscChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if(DiscChangeIdComBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Не выбрана дисциплина для изменения!", "Ошибка");
                return;
            }
            if(DiscChangeTitleText.Text == "")
            {
                MessageBox.Show("Не задано название!", "Ошибка");
                return;
            }
            if(DiscChangeHCountComBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Не выбрано количество часов!", "Ошибка");
                return;
            }
            if(DiscChangeZvitFormComBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Не выбрано форму отчетности!", "Ошибка");
                return;
            }
            MySqlCommand msc = new MySqlCommand("update Disciple set Title=@title, ZvitForm=@zvitf, HoursCount=@hcount where DID=@did;");
            msc.Parameters.Add("@did", int.Parse(DList.ElementAt(DiscChangeIdComBox.SelectedIndex).DID));
            msc.Parameters.Add("@title", DiscChangeTitleText.Text);
            msc.Parameters.Add("@zvitf", ZvitFormsList[DiscChangeZvitFormComBox.SelectedIndex - 1]);
            msc.Parameters.Add("@hcount", DiscChangeHCountComBox.SelectedValue);
            DBUtils.DataManipulate(msc);
            DiscipleInitialisation();
        }

        private void DiscDelButton_Click(object sender, RoutedEventArgs e)
        {
            if (DiscDelComBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Не выбрана дисциплина для удаления!", "Ошибка");
                return;
            }
            MySqlCommand msc = new MySqlCommand("delete from Disciple where DID=@did");
            msc.Parameters.Add("@did", int.Parse(DList.ElementAt(DiscDelComBox.SelectedIndex).DID));
            DBUtils.DataManipulate(msc);
            DiscipleInitialisation();
        }

        private void FacultAddButton_Click(object sender, RoutedEventArgs e)
        {
            if(FacultAddTitleText.Text == "")
            {
                MessageBox.Show("Не задано название факультета!", "Ошибка");
                return;
            }
            MySqlCommand msc = new MySqlCommand("insert into Faculty(FName) values(@fnm);");
            msc.Parameters.Add("@fnm", FacultAddTitleText.Text);
            DBUtils.DataManipulate(msc);
            FacultyInitialisation();
        }

        private void FacultChangeIdComBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int cur = FacultChangeIdComBox.SelectedIndex;
            if (cur < 0)
                return;
            if(cur == 0)
            {
                FacultChangeTitleText.Text = "";
                return;
            }
            FacultChangeTitleText.Text = FList[cur].FName;
        }

        private void FacultChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (FacultChangeIdComBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Не выбрана дисциплина для изменения!", "Ошибка");
                return;
            }
            if (FacultChangeTitleText.Text == "")
            {
                MessageBox.Show("Не задано название дисциплины!", "Ошибка");
                return;
            }
            MySqlCommand msc = new MySqlCommand("update Faculty set FName=@fnm where FID=@fid;");
            msc.Parameters.Add("@fid", int.Parse(FList.ElementAt(FacultChangeIdComBox.SelectedIndex).FID));
            msc.Parameters.Add("@fnm", FacultChangeTitleText.Text);
            DBUtils.DataManipulate(msc);
            FacultyInitialisation();
        }

        private void FacultDelButton_Click(object sender, RoutedEventArgs e)
        {
            if(FacultDelComBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Не выбран факультет для удаления!", "Ошибка");
                return;
            }
            MySqlCommand msc = new MySqlCommand("delete from Faculty where FID=@fid");
            msc.Parameters.Add("@fid", int.Parse(FList.ElementAt(FacultDelComBox.SelectedIndex).FID));
            DBUtils.DataManipulate(msc);
            FacultyInitialisation();
        }

        private void N_NSGAddButton_Click(object sender, RoutedEventArgs e)
        {
            if(N_NSGAddStudComBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Не выбрано студента!", "Ошибка");
                return;
            }
            if (N_NSGAddGroupComBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Не выбрано группу!", "Ошибка");
                return;
            }
            MySqlCommand msc = new MySqlCommand("insert into Stud_Group(SID,GID) values(@sid,@gid);");
            msc.Parameters.Add("@sid", int.Parse(SList[N_NSGAddStudComBox.SelectedIndex].SID));
            msc.Parameters.Add("@gid", int.Parse(GList[N_NSGAddGroupComBox.SelectedIndex].GID));
            DBUtils.DataManipulate(msc);
            N_NInitialisation();
        }

        private void N_NSGChangeIdComBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int cur = N_NSGChangeIdComBox.SelectedIndex;
            if (cur < 0)
                return;
            if(cur == 0)
            {
                N_NSGChangeStudComBox.SelectedIndex = 0;
                N_NSGChangeGroupComBox.SelectedIndex = 0;
                return;
            }
            for (int i = 0; i < SList.Count; i++)
                if (SList[i].SID == SGList[cur].SID)
                {
                    N_NSGChangeStudComBox.SelectedIndex = i;
                    break;
                }
            for (int i = 0; i < GList.Count; i++)
                if (GList[i].GID == SGList[cur].GID)
                {
                    N_NSGChangeGroupComBox.SelectedIndex = i;
                    break;
                }
        }

        private void N_NSGChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if(N_NSGChangeIdComBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Не выбрано зависимость!", "Ошибка");
                return;
            }
            if (N_NSGChangeStudComBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Не выбрано студента!", "Ошибка");
                return;
            }
            if (N_NSGChangeGroupComBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Не выбрано группу!", "Ошибка");
                return;
            }
            MySqlCommand msc = new MySqlCommand("update Stud_Group set SID=@sid, GID=@gid where SID=@sid2 and GID=@gid2;");
            msc.Parameters.Add("@sid", int.Parse(SList.ElementAt(N_NSGChangeStudComBox.SelectedIndex).SID));
            msc.Parameters.Add("@gid", int.Parse(GList.ElementAt(N_NSGChangeGroupComBox.SelectedIndex).GID));
            msc.Parameters.Add("@sid2", int.Parse(SGList.ElementAt(N_NSGChangeIdComBox.SelectedIndex).SID));
            msc.Parameters.Add("@gid2", int.Parse(SGList.ElementAt(N_NSGChangeIdComBox.SelectedIndex).GID));
            DBUtils.DataManipulate(msc);
            N_NInitialisation();
        }

        private void N_NSGDelButton_Click(object sender, RoutedEventArgs e)
        {
            if(N_NSGDelIdComBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Не выбрано зависимость для удаления!", "Ошибка");
                return;
            }
            MySqlCommand msc = new MySqlCommand("delete from Stud_Group where SID=@sid and GID=@gid;");
            msc.Parameters.Add("@sid", int.Parse(SGList.ElementAt(N_NSGDelIdComBox.SelectedIndex).SID));
            msc.Parameters.Add("@gid", int.Parse(SGList.ElementAt(N_NSGDelIdComBox.SelectedIndex).GID));
            DBUtils.DataManipulate(msc);
            N_NInitialisation();
        }

        private void N_NGDAddButton_Click(object sender, RoutedEventArgs e)
        {
            if (N_NGDAddGroupComBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Не выбрано группу!", "Ошибка");
                return;
            }
            if (N_NGDAddDiscComBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Не выбрано дисциплину!", "Ошибка");
                return;
            }
            MySqlCommand msc = new MySqlCommand("insert into Group_Disc(GID,DID) values(@gid,@did);");
            msc.Parameters.Add("@gid", int.Parse(GList[N_NGDAddGroupComBox.SelectedIndex].GID));
            msc.Parameters.Add("@did", int.Parse(DList[N_NGDAddDiscComBox.SelectedIndex].DID));
            DBUtils.DataManipulate(msc);
            N_NInitialisation();
        }

        private void N_NGDChangeIdComBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int cur = N_NGDChangeIdComBox.SelectedIndex;
            if (cur < 0)
                return;
            if (cur == 0)
            {
                N_NGDChangeGroupComBox.SelectedIndex = 0;
                N_NGDChangeDiscComBox.SelectedIndex = 0;
                return;
            }
            for (int i = 0; i < GList.Count; i++)
                if (GList[i].GID == GDList[cur].GID)
                {
                    N_NGDChangeGroupComBox.SelectedIndex = i;
                    break;
                }
            for (int i = 0; i < DList.Count; i++)
                if (DList[i].DID == GDList[cur].DID)
                {
                    N_NGDChangeDiscComBox.SelectedIndex = i;
                    break;
                }
        }

        private void N_NGDChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (N_NGDChangeIdComBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Не выбрано зависимость!", "Ошибка");
                return;
            }
            if (N_NGDChangeGroupComBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Не выбрано группу!", "Ошибка");
                return;
            }
            if (N_NGDChangeDiscComBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Не выбрано дисциплину!", "Ошибка");
                return;
            }
            MySqlCommand msc = new MySqlCommand("update Group_Disc set GID=@gid, DID=@did where GID=@gid2 and DID=@did2;");
            msc.Parameters.Add("@gid", int.Parse(GList.ElementAt(N_NGDChangeGroupComBox.SelectedIndex).GID));
            msc.Parameters.Add("@did", int.Parse(DList.ElementAt(N_NGDChangeDiscComBox.SelectedIndex).DID));
            msc.Parameters.Add("@gid2", int.Parse(GDList.ElementAt(N_NGDChangeIdComBox.SelectedIndex).GID));
            msc.Parameters.Add("@did2", int.Parse(GDList.ElementAt(N_NGDChangeIdComBox.SelectedIndex).DID));
            DBUtils.DataManipulate(msc);
            N_NInitialisation();
        }

        private void N_NGDDelButton_Click(object sender, RoutedEventArgs e)
        {
            if (N_NGDDelIdComBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Не выбрано зависимость для удаления!", "Ошибка");
                return;
            }
            MySqlCommand msc = new MySqlCommand("delete from Group_Disc where GID=@gid and DID=@did;");
            msc.Parameters.Add("@gid", int.Parse(GDList.ElementAt(N_NGDDelIdComBox.SelectedIndex).GID));
            msc.Parameters.Add("@did", int.Parse(GDList.ElementAt(N_NGDDelIdComBox.SelectedIndex).DID));
            DBUtils.DataManipulate(msc);
            N_NInitialisation();
        }
    }
}
