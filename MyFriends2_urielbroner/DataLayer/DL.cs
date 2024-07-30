namespace MyFriends2.DataLayer
{
    // -- SINGLETON --
    public class DL
    {
        static DL GetDL;
        string ConnectionString = "server = DESKTOP-3JPK806\\SQLEXPRESS;initial catalog=MyFriends; user id=sa; password=1234;TrustServerCertificate=Yes";
        private DL()
        {
            Context= new Context(ConnectionString);
        }
        //גישה לברז מבחוץ
        public static Context Get
        {
            get
            {
                //פתיחת הברז בפעם הראשונה
                if (GetDL == null) GetDL = new DL();
                return GetDL.Context;
            }
        }

        public Context Context { get; }
    }
}
