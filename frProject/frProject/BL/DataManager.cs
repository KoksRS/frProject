using frProject.BL.Entities;
using frProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frProject.BL
{
    public class DataManager
    {

        DalManager context;
        public DataManager(string dbLocation)
        {
            context = new DalManager(dbLocation);
        }

        public Word GetWordById(int id)
        {
            return context.GetById<Word>(id);
        }

        public List<Theme> GetThemes(int difficulty = -1)
        {
            return context.GetThemes(difficulty);
        }
    }
}
