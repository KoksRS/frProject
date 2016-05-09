using frProject.BL.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frProject.DL
{
    sealed class Seeder
    {

        private SQLiteConnection db;

        public Seeder(string dbPath)
        {
           db = new SQLiteConnection(dbPath);
           
            //// create the tables
            //db.CreateTable<Document>();
            //db.CreateTable<DocumentType>();
            //db.CreateTable<Phrase>();
            //db.CreateTable<PhraseFr>();
            //db.CreateTable<PhraseRu>();
            //db.CreateTable<Word>();
            //db.CreateTable<WordFr>();
            //db.CreateTable<WordRu>();
            //db.CreateTable<WordType>();
            //db.CreateTable<Exercise>();
            //db.CreateTable<ExerciseType>();
            //db.CreateTable<Theme>();
        }
        public void Seed()
        {
            //seed tables
            Theme();

        }

        private void SeedTable<T>(IEnumerable<T> seeds) where T : new()
        {
            db.CreateTable<T>();
            if (db.Table<T>().Count() == 0)
            {
                db.InsertAll(seeds);
            }
        }

        private void Theme()
        {

            Theme[] themes = {
                new Theme() { Difficulty = 1 , Label = "Знакомство" },
                new Theme() { Difficulty = 1 , Label = "В магазине" },
                new Theme() { Difficulty = 1 , Label = "В транспорте" }
            };

            SeedTable(themes);
                       
        }
        private void Document()
        {
            
            Document[] themes = {
                new Document() { ID = 1, Type = { ID = 1, Label = "Картинка", Type = "Image" },  Path="", Extension="jpg", FileName="test.jpg"  },
        
            };

            SeedTable(themes);
        }

        private void DocumentType()
        {
            DocumentType[] docTypes = {
                new DocumentType() { ID = 1, Label = "Картинка", Type = "Image" },
                new DocumentType() { ID = 2, Label = "Звук", Type = "Звук" },
                new DocumentType() { ID = 3, Label = "Pdf", Type = "PDF" },
            };

            SeedTable(docTypes);
        }
        
    }
}
