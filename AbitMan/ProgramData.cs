namespace AbitMan
{
    class ProgramData
    {
        public static string Login = "Гость";
        public static string Host = "127.0.0.1";
        public static string Port = "3306";
        public static string User = "root";
        public static string Pswd = "xrxrxrxrxrxrxrxrxrxr";
        public static string Schema = "abitman";
        public static int Privs = 0;

        public static void SetDataConnection(string host, string port, string user, string pswd, string schema)
        {
            Host = host;
            Port = port;
            User = user;
            Pswd = pswd;
            Schema = schema;
        }

        public static void SetUserData(string login, int privs)
        {
            Login = login;
            Privs = privs;
        }
    }
}
