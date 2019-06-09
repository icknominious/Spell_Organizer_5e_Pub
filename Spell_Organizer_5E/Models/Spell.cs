using SQLite;

namespace Spell_Organizer_5E.Models
{
    public class Spell
    {
        [PrimaryKey]
        public string Name { get; set; }
        public int Level { get; set; }
        public string School { get; set; }
        public string Time { get; set; }
        public string Range { get; set; }
        public string Components { get; set; }
        public string Duration { get; set; }
        public string Classes { get; set; }
        public string Text { get; set; }
    }
}
