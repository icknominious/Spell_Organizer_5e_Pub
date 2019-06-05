using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;


namespace Spell_Organizer_5E.Data
{
    class XMLReader
    {
        XmlReader reader;
        public async System.Threading.Tasks.Task ReadFileAsync()
        {
            var stream = await FileSystem.OpenAppPackageFileAsync("srd_spells.xml");

            reader = new XmlTextReader(stream);

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        Console.Write("<" + reader.Name);
                        Console.WriteLine(">");
                        break;
                    case XmlNodeType.Text: //Display the text in each element.
                        Console.WriteLine(reader.Value);
                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.
                        Console.Write("</" + reader.Name);
                        Console.WriteLine(">");
                        break;
                }
            }
        }
    }
}
