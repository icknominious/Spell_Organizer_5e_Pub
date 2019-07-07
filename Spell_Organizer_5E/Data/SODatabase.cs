using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Spell_Organizer_5E.Models;

namespace Spell_Organizer_5E.Data
{
    /// <summary>
    /// Interface-like class for the App DB, provides abstraction of SQL queries to calling classes
    /// </summary>
    public class SODatabase
    {
        readonly SQLiteAsyncConnection _database;
        /// <summary>
        /// Class constructor, creates tables within DB for every data model
        /// </summary>
        /// <param name="dbPath"></param>
        public SODatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Spell>().Wait();
            _database.CreateTableAsync<Character>().Wait();
            _database.CreateTableAsync<SpellList>().Wait();
        }

        /// <summary>
        /// Asynchronous query for entire spell list, 
        /// used to popeulate spell view pages 
        /// </summary>
        /// <returns>Task</returns>
        public Task<List<Spell>> GetSpellsAsync()
        {
            return _database.Table<Spell>().ToListAsync();
        }
        /// <summary>
        /// Gets a list of spells for a single class
        /// </summary>
        /// <param name="characterClass"></param>
        /// <returns>Task</returns>
        public Task<List<Spell>> GetSpellsbyClassAsync(string characterClass)
        {
            return _database.Table<Spell>()
                            .Where(i => i.Classes.Contains(characterClass))
                            .ToListAsync();
        }
        /// <summary>
        /// Gets a list of spells for a single school
        /// </summary>
        /// <param name="spellSchool"></param>
        /// <returns>Task</returns>
        public Task<List<Spell>> GetSpellsbySchoolAsync(string spellSchool)
        {
            return _database.Table<Spell>()
                            .Where(i => i.School.Contains(spellSchool))
                            .ToListAsync();
        }

        /// <summary>
        /// Gets a single spell
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Task</returns>
        public Task<Spell> GetSpellAsync(string name)
        {
            return _database.Table<Spell>()
                            .Where(i => i.Name == name)
                            .FirstOrDefaultAsync();
        }
        /// <summary>
        /// Saves a new spell to DB, only used first time app is used or an update is made
        /// </summary>
        /// <param name="Spell"></param>
        /// <returns></returns>
        public Task<int> SaveSpellAsync(Spell Spell)
        {
            return _database.InsertAsync(Spell);
        }
        /// <summary>
        /// Removes a spell from the DB, no planned uses
        /// </summary>
        /// <param name="Spell"></param>
        /// <returns></returns>
        public Task<int> DeleteSpellAsync(Spell Spell)
        {
            return _database.DeleteAsync(Spell);
        }
        /// <summary>
        /// Characters not yet implemented, no uses
        /// </summary>
        /// <returns></returns>
        public Task<List<Character>> GetCharactersAsync()
        {
            return _database.Table<Character>().ToListAsync();
        }
        /// <summary>
        /// Characters not yet implemented, no uses
        /// </summary>
        /// <returns></returns>
        public Task<Character> GetCharacterAsync(int id)
        {
            return _database.Table<Character>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }
        /// <summary>
        /// Characters not yet implemented, no uses
        /// </summary>
        /// <returns></returns>
        public Task<int> SaveCharacterAsync(Character Character)
        {
            return Character.ID != 0 ? _database.UpdateAsync(Character) : _database.InsertAsync(Character);
        }
        /// <summary>
        /// Characters not yet implemented, no uses
        /// </summary>
        /// <returns></returns>
        public Task<int> DeleteCharacterAsync(Character Character)
        {
            return _database.DeleteAsync(Character);
        }
        /// <summary>
        /// Gets a list of all Spell Lists
        /// </summary>
        /// <returns>Task</returns>
        public Task<List<SpellList>> GetSpellListsAsync()
        {
            return _database.Table<SpellList>().ToListAsync();
        }
        /// <summary>
        /// Gets a single Spell List by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Task</returns>
        public Task<SpellList> GetSpellListAsync(string name)
        {
            return _database.Table<SpellList>()
                            .Where(i => i.Name == name)
                            .FirstOrDefaultAsync();
        }
        /// <summary>
        /// Saves a single Spell List
        /// </summary>
        /// <param name="SpellList"></param>
        /// <returns>Task</returns>
        public Task<string> SaveSpellListAsync(SpellList SpellList)
        {
            if (App.Database.GetSpellListAsync(SpellList.Name).Result == null)
                _database.InsertAsync(SpellList);
            else
                _database.UpdateAsync(SpellList);
            return Task.FromResult(SpellList.Name);
            //return SpellList.ID != 0 ? _database.UpdateAsync(SpellList) : _database.InsertAsync(SpellList);
        }
        /// <summary>
        /// Deletes a single spell list, no current uses
        /// </summary>
        /// <param name="SpellList"></param>
        /// <returns>Task</returns>
        public Task<int> DeleteSpellListAsync(SpellList SpellList)
        {
            return _database.DeleteAsync(SpellList);
        }
    }
}