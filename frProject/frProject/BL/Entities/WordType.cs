using frProject.BL.Contracts;
using SQLite;

namespace frProject.BL.Entities
{
    public class WordType : IBusinessEntity
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Type { get; set; }
        public string Label { get; set; }
    }
}