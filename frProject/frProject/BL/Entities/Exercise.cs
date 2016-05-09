using frProject.BL.Contracts;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frProject.BL.Entities
{
    public class Exercise : IBusinessEntity
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Label { get; set; }
        public int ThemeId { get; set; }
        public ExerciseType Type { get; set; }
        public List<Word> Words { get; set; }
        public bool Done { get; set; }
        public Document Image { get; set; }
    }
}
