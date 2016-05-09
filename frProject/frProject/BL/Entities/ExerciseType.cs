using frProject.BL.Contracts;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frProject.BL.Entities
{
    public class ExerciseType: IBusinessEntity
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Type { get; set; }
        public string Label { get; set; }
    }
}
