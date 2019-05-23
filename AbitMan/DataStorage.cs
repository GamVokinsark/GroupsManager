namespace AbitMan
{
    class Student
    {
        public Student(string id, string name, string surname, string course)
        {
            SID = id;
            SName = name;
            Surname = surname;
            Course = course;
        }

        public string SID { get; set; }
        public string SName { get; set; }
        public string Surname { get; set; }
        public string Course { get; set; }
    }

    class Groups
    {
        public Groups(string gId, string starosta, string fName, string gName, string isTemp)
        {
            GID = gId;
            Starosta = starosta;
            FName = fName;
            GName = gName;
            IsTemp = isTemp;
        }

        public string GID { get; set; }
        public string Starosta { get; set; }
        public string FName { get; set; }
        public string GName { get; set; }
        public string IsTemp { get; set; }
    }

    class Disciple
    {
        public Disciple(string dId, string dName, string zvitForm, string hoursCount)
        {
            DID = dId;
            DName = dName;
            ZvitForm = zvitForm;
            HoursCount = hoursCount;
        }

        public string DID { get; set; }
        public string DName { get; set; }
        public string ZvitForm { get; set; }
        public string HoursCount { get; set; }
    }

    class Faculty
    {
        public Faculty(string fId, string fName)
        {
            FID = fId;
            FName = fName;
        }

        public string FID { get; set; }
        public string FName { get; set; }
    }

    class Stud_Group
    {
        public Stud_Group(string sID, string gID)
        {
            SID = sID;
            GID = gID;
        }

        public string SID { get; set; }
        public string GID { get; set; }
    }

    class Group_Disc
    {
        public Group_Disc(string gID, string dID)
        {
            GID = gID;
            DID = dID;
        }

        public string GID { get; set; }
        public string DID { get; set; }
    }

    class Res1Storage
    {
        public Res1Storage(string sName, string surname, string gName, string course)
        {
            SName = sName;
            Surname = surname;
            GName = gName;
            Course = course;
        }

        public string SName { get; set; }
        public string Surname { get; set; }
        public string GName { get; set; }
        public string Course { get; set; }
    }

    class Res2Storage
    {
        public Res2Storage(string sName, string surname, string gName, string fName, string course)
        {
            SName = sName;
            Surname = surname;
            GName = gName;
            FName = fName;
            Course = course;
        }

        public string SName { get; set; }
        public string Surname { get; set; }
        public string GName { get; set; }
        public string FName { get; set; }
        public string Course { get; set; }
    }

    class Res3Storage
    {
        public Res3Storage(string fName, string course, string gName, string count)
        {
            FName = fName;
            Course = course;
            GName = gName;
            Count = count;
        }

        public string FName { get; set; }
        public string Course { get; set; }
        public string GName { get; set; }
        public string Count { get; set; }
    }

    class Res4Storage
    {
        public Res4Storage(string sName, string surname, string gName, string course)
        {
            SName = sName;
            Surname = surname;
            GName = gName;
            Course = course;
        }

        public string SName { get; set; }
        public string Surname { get; set; }
        public string GName { get; set; }
        public string Course { get; set; }
    }

    class Res5Storage
    {
        public Res5Storage(string gName, string count)
        {
            GName = gName;
            Count = count;
        }

        public string GName { get; set; }
        public string Count { get; set; }
    }

    class Res6Storage
    {
        public Res6Storage(string gName, string count)
        {
            GName = gName;
            Count = count;
        }

        public string GName { get; set; }
        public string Count { get; set; }
    }
}