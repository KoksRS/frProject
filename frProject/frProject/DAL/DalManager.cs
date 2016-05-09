using frProject.BL.Entities;
using frProject.DL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace frProject.DAL
{
    public class DalManager
    {
        DatabaseAdapter db = null;
        
        public DalManager(string dbLocation)
        {
            Seeder seed = new Seeder(dbLocation);
            seed.Seed();

            db = new DatabaseAdapter(dbLocation);
        }

        public T GetById<T>(int id) where T : BL.Contracts.IBusinessEntity, new()
        {
            return db.GetItems<T>().Where(x => x.ID == id).FirstOrDefault();
        } 

        public List<Theme> GetThemes(int difficulty)
        {
            if (difficulty >=0)
            {
               return db.GetItems<Theme>().Where(x => x.Difficulty == difficulty).ToList();
            }
            else
            {
               return  db.GetItems<Theme>().ToList();
            }
        }
        
    }
}
