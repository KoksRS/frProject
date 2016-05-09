using frProject.BL.Contracts;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frProject.BL.Entities
{
    public class Document : IBusinessEntity
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public DocumentType Type { get; set; }
    }
}
