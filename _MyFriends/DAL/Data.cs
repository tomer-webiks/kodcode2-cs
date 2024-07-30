namespace My_Friends_Img.DAL
{
    public class Data
    {
        private string ConnectionString = "server = MATANEL_VATKIN\\SQLEXPRESS;initial catalog=friends_img;user id=sa;password=1234;TrustServerCertificate=Yes";
        private static Data _data;
        private DBContext _layer;

        private Data()
        {
            _layer = new DBContext(ConnectionString);
        }

        public static DBContext Get
        {
            get
            {
                if (_data == null)
                {
                    _data = new Data();
                }
                return _data._layer;
            }
        }
    }
}
