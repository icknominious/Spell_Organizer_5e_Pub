﻿using System;
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
                        Console.WriteLine(spell.Level = reader.ReadElementContentAsInt());
                        _ = reader.ReadToFollowing("school");
                        Console.WriteLine(spell.School = reader.ReadElementContentAsString("school", ""));
                        await App.Database.SaveSpellAsync(spell);
                    }
                }
                catch(System.Xml.XmlException){ };
            }
        }
    }
}