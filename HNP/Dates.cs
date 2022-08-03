using SQLite;

namespace HNP
{
    [Table("Dates")]
    public class Dates
    {
        [PrimaryKey, AutoIncrement, Column("Id_date")]
        public int Id_date { get; set; }
        public string Date_name { get; set; }
        public string Date { get; set; }
        public string Discription { get; set; }
    }
}