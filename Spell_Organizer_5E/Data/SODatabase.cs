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
            _database.CreateTableAsync<Character>().Wait();
            _database.CreateTableAsync<SpellList>().Wait();
        }

        public Task<List<Spell>> GetSpellsAsync()
        {
            return _database.Table<Spell>().ToListAsync();
        }

        public Task<List<Spell>> GetSpellsbyClassAsync(string characterClass)
        {
            return _database.Table<Spell>()
                            .Where(i => i.Classes.Contains(characterClass))
                            .ToListAsync();
        }

        public Task<List<Spell>> GetSpellsbySchoolAsync(string spellSchool)
        {
            return _database.Table<Spell>()
                            .Where(i => i.School.Contains(spellSchool))
                            .ToListAsync();
        }

        public Task<Spell> GetSpellAsync(string name)
        {
            return _database.Table<Spell>()
                            .Where(i => i.Name == name)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveSpellAsync(Spell Spell)
        {
            return _database.InsertAsync(Spell);
        }

        public Task<int> DeleteSpellAsync(Spell Spell)
        {
            return _database.DeleteAsync(Spell);
        }

        public Task<List<Character>> GetCharactersAsync()
        {
            return _database.Table<Character>().ToListAsync();
        }

        public Task<Character> GetCharacterAsync(int id)
        {
            return _database.Table<Character>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveCharacterAsync(Character Character)
        {
            return Character.ID != 0 ? _database.UpdateAsync(Character) : _database.InsertAsync(Character);
        }

        public Task<int> DeleteCharacterAsync(Character Character)
        {
            return _database.DeleteAsync(Character);
        }

        public Task<List<SpellList>> GetSpellListsAsync()
        {
            return _database.Table<SpellList>().ToListAsync();
        }

        public Task<SpellList> GetSpellListAsync(string name)
        {
            return _database.Table<SpellList>()
                            .Where(i => i.Name == name)
                            .FirstOrDefaultAsync();
        }  
     
        public Task<string> SaveSpellListAsync(SpellList SpellList)
        {
            if (App.Database.GetSpellAsync(SpellList.Name).Result == null)
                _database.InsertAsync(SpellList);
            else
                _database.UpdateAsync(SpellList);
            return Task.FromResult(SpellList.Name);
            //return SpellList.ID != 0 ? _database.UpdateAsync(SpellList) : _database.InsertAsync(SpellList);
        }
     
        public Task<int> DeleteSpellListAsync(SpellList SpellList)
        {
            return _database.DeleteAsync(SpellList);
        }
    }
}