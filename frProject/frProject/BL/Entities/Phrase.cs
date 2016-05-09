using frProject.BL.Contracts;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frProject.BL.Entities
{
    public class Phrase : Word
    {
        new public Document Image { get; set; }
    }
}
