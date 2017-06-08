using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GitHubUsers.Extensions
{
    public static class ObservableCollectionExtensions
    {
        public static void AddRange<T>(this ObservableCollection<T> observableCollection, IEnumerable<T> items)
        {
            if (items == null || !items.Any()) return;

            foreach (var item in items)
            {
                observableCollection.Add(item);
            }
        }
    }
}