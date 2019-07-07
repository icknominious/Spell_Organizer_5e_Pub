using System;
using System.Xml;
using Xamarin.Essentials;
using Spell_Organizer_5E.Models;


namespace Spell_Organizer_5E.Data
{
    /// <summary>
    /// XMLReader parses an XML file for all Spells and adds them to the DB,
    /// only runs first time app is used or updated
    /// </summary>
    class XMLReader
    {
        XmlReader reader;
        /// <summary>
        /// Continually parses XML fileline by line to build a Spell object and then adds it to the DB
        /// </summary>
        /// <returns>Task</returns>
        public async System.Threading.Tasks.Task ReadFileAsync()
        {
            var stream = await FileSystem.OpenAppPackageFileAsync("srd_spells.xml");

            XmlReaderSettings settings = new XmlReaderSettings
            {
                Async = true
            };

            reader = XmlReader.Create(stream, settings);

            while ( reader.Read())                                                                  
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    Spell spell = new Spell();
                    _ = reader.ReadToFollowing("name");
                    Console.WriteLine(spell.Name = reader.ReadElementContentAsString("name", ""));
                    if (await App.Database.GetSpellAsync(spell.Name) == null)
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            switch (reader.Name)
                            {
                                case "level":
                                    //_ = reader.ReadToFollowing("level");
                                    Console.WriteLine(spell.Level = reader.ReadElementContentAsInt("level", ""));
                                    break;
                                case "school":
                                    //_ = reader.ReadToFollowing("school");
                                    Console.WriteLine(spell.School = reader.ReadElementContentAsString("school", ""));
                                    break;
                                case "ritual":
                                    //_ = reader.ReadToFollowing("ritual");
                                    Console.WriteLine(spell.Ritual = reader.ReadElementContentAsString("ritual", ""));
                                    break;
                                case "time":
                                    //_ = reader.ReadToFollowing("time");
                                    Console.WriteLine(spell.Time = reader.ReadElementContentAsString("time", ""));
                                    break;
                                case "range":
                                    //_ = reader.ReadToFollowing("range");
                                    Console.WriteLine(spell.Range = reader.ReadElementContentAsString("range", ""));
                                    break;
                                case "components":
                                    //_ = reader.ReadToFollowing("components");
                                    Console.WriteLine(spell.Components = reader.ReadElementContentAsString("components", ""));
                                    break;
                                case "duration":
                                    //_ = reader.ReadToFollowing("duration");
                                    Console.WriteLine(spell.Duration = reader.ReadElementContentAsString("duration", ""));
                                    break;
                                case "classes":
                                    //_ = reader.ReadToFollowing("classes");
                                    Console.WriteLine(spell.Classes = reader.ReadElementContentAsString("classes", ""));
                                    break;
                                case "text":
                                    //_ = reader.ReadToFollowing("text");
                                    Console.WriteLine(spell.Text += reader.ReadElementContentAsString("text", ""));
                                    break;
                            }
                            reader.Read();
                        }
                        await App.Database.SaveSpellAsync(spell);
                    }
                    else
                        break;
                }
                
            }
            Console.WriteLine("Done reading XML files");
        }
    }
}
