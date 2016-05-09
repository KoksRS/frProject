using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using frProject.BL.Entities;

namespace frProject.DL
{
    class DatabaseAdapter : SQLiteConnection
    {
        static object locker = new object();

        public DatabaseAdapter(string path) : base(path)
        {
           
        }

        public IEnumerable<T> GetItems<T>() where T : BL.Contracts.IBusinessEntity, new()
        {
            lock (locker)
            {
                return (from i in Table<T>() select i).ToList();
            }
        }

        public T GetItem<T>(int id) where T : BL.Contracts.IBusinessEntity, new()
        {
            lock (locker)
            {
                return Table<T>().FirstOrDefault(x => x.ID == id);
                // Following throws NotSupportedException - thanks aliegeni
                //return (from i in Table<T> ()
                //        where i.ID == id
                //        select i).FirstOrDefault ();
            }
        }

        public int SaveItem<T>(T item) where T : BL.Contracts.IBusinessEntity
        {
            lock (locker)
            {
                if (item.ID != 0)
                {
                    Update(item);
                    return item.ID;
                }
                else {
                    return Insert(item);
                }
            }
        }

        public int DeleteItem<T>(int id) where T : BL.Contracts.IBusinessEntity, new()
        {
            lock (locker)
            {
                return Delete(new T() { ID = id });
            }
        }

    }
}
