using frProject.BL.Contracts;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frProject.BL.Entities
{
    public class WordFr : Word
    {
        public string Text { get; set; }
    }
}
