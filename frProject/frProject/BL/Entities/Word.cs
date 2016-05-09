using frProject.BL.Contracts;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frProject.BL.Entities
{
    public class Word : IBusinessEntity
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public WordType type { get; set; }
        public Document Image { get; set; }

    }
}
