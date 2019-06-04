using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Spell_Organizer_5E.Models;

namespace Spell_Organizer_5E.Data
{
    public class SODatabase
    {
        readonly SQLiteAsyncConnection _database;

        public SODatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Spell>().Wait();
        }

        public Task<List<Spell>> GetSpellsAsync()
        {
            return _database.Table<Spell>().ToListAsync();
        }

        public Task<List<Character>> GetCharactersAsync()
        {
            return _database.Table<Character>().ToListAsync();
        }

        public Task<Spell> GetSpellAsync(int id)
        {
            return _database.Table<Spell>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<Character> GetCharacterAsync(int id)
        {
            return _database.Table<Character>()
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

        public Task<int> SaveCharacterAsync(Character Character)
        {
            if (Character.ID != 0)
            {
                return _database.UpdateAsync(Character);
            }
            else
            {
                return _database.InsertAsync(Character);
            }
        }

        public Task<int> DeleteSpellAsync(Spell Spell)
        {
            return _database.DeleteAsync(Spell);
        }

        public Task<int> DeleteCharacterAsync(Character Character)
        {
            return _database.DeleteAsync(Character);
        }
    }
}