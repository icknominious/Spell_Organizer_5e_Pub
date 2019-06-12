using System;
using System.Xml;
using Xamarin.Essentials;
using Spell_Organizer_5E.Models;


namespace Spell_Organizer_5E.Data
{
    class XMLReader
    {
        XmlReader reader;
        public async System.Threading.Tasks.Task ReadFileAsync()
        {
            var stream = await FileSystem.OpenAppPackageFileAsync("srd_spells.xml");

            XmlReaderSettings settings = new XmlReaderSettings
            {
                Async = true
            };

            reader = XmlReader.Create(stream, settings);

            Spell spell = new Spell();

            while (await reader.ReadAsync())
            {
                try
                {
                    _ = reader.ReadToFollowing("name");
                    Console.WriteLine(spell.Name=reader.ReadElementContentAsString("name", ""));
                    Spell otherSpell = await App.Database.GetSpellAsync(spell.Name);
                    if (otherSpell == null)
                    {
                        _ = reader.ReadToFollowing("level");
                        Console.WriteLine(spell.Level = reader.ReadElementContentAsInt("level", ""));
                        _ = reader.ReadToFollowing("school");
                        Console.WriteLine(spell.School = reader.ReadElementContentAsString("school", ""));
                        _ = reader.ReadToFollowing("time");
                        Console.WriteLine(spell.Time = reader.ReadElementContentAsString("time", ""));
                        _ = reader.ReadToFollowing("range");
                        Console.WriteLine(spell.Range = reader.ReadElementContentAsString("range", ""));
                        _ = reader.ReadToFollowing("components");
                        Console.WriteLine(spell.Components = reader.ReadElementContentAsString("components", ""));
                        _ = reader.ReadToFollowing("duration");
                        Console.WriteLine(spell.Duration = reader.ReadElementContentAsString("duration", ""));
                        _ = reader.ReadToFollowing("classes");
                        Console.WriteLine(spell.Classes = reader.ReadElementContentAsString("classes", ""));
                        while (reader.Read() && reader.Name == "text")
                            spell.Text += reader.ReadElementContentAsString("text", "");
                        await App.Database.SaveSpellAsync(spell);

                    }
                }
                catch (XmlException) { /*Do nothing. Last read operation will find nothing and throw an exception*/};
            }
            Console.WriteLine("Done reading XML files");
        }
    }
}
