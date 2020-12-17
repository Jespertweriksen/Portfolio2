namespace DataService
{
    public class PostgresSQL_Connect_String
    {
        // private string host = "localhost";
        // private string db = "imdb";
        // private string UserId = "postgres";
        // private string pwd = "";

        private string host = "rawdata.ruc.dk";
        private string db = "raw5";
        private string UserId = "raw5";
        private string pwd = "Aji2O4oD";
        public override string ToString()
        {
            return $"host={host};db={db};uid={UserId};pwd={pwd}";
        }
    }
}