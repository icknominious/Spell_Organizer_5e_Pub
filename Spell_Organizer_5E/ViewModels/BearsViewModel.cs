using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Spell_Organizer_5E.Data;
using Spell_Organizer_5E.Models;

namespace Spell_Organizer_5E.ViewModels
{
    public class BearsViewModel
    {
        public ObservableCollection<Animal> SearchResults { get; private set; }

        public ICommand SearchCommand => new Command<string>(SearchItems);

        void SearchItems(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                SearchResults = null;
            }
            else
            {
                var filteredItems = BearData.Bears
                    .Where(bear => bear.Name.ToLower()
                    .Contains(query.ToLower()))
                    .ToList();
                SearchResults = new ObservableCollection<Animal>(filteredItems);
            }
        }
    }
}
