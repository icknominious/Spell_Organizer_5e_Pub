using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Spell_Organizer_5E.Models;

namespace Spell_Organizer_5E.Data
{
    public class SpellDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public SpellDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Spell>().Wait();
        }

        public Task<List<Spell>> GetSpellsAsync()
        {
            return _database.Table<Spell>().ToListAsync();
        }

        public Task<Spell> GetSpellAsync(int id)
        {
            return _database.Table<Spell>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveSpellAsync(Spell Spell)
        {
            if (Spell.ID != 0)
            {
                return _database.UpdateAsync(Spell);
            }
            else
            {
                return _database.InsertAsync(Spell);
            }
        }

        public Task<int> DeleteSpellAsync(Spell Spell)
        {
            return _database.DeleteAsync(Spell);
        }
    }
}