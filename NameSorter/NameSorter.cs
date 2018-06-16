using System;
using System.Collections.Generic;
using System.Linq;

namespace NameSorter
{
    public class NameSorter : INameSorter
    {
        /// <summary>Sorts the list of Names by Surname then by GivenNames.</summary>
        /// <param name="unsortedNames">List of unsorted Names.</param>
        /// <param name="stringComparer">The specific case and string culture comparison rules.</param>
        /// <returns>List of sorted name</returns>
        public IList<IName> SortNames(IList<IName> unsortedNames, StringComparer stringComparer)
        {
            // Validate that the unsorted list is not null and contains elements.
            if (unsortedNames == null || !unsortedNames.Any())
                throw new ArgumentNullException("unsortedNames");
            
            // If there is only one element in the list, no sorting is required.
            if (unsortedNames.Count <= 1)
                return unsortedNames;

            return unsortedNames.OrderBy(n => n.Surname, stringComparer)
                                .ThenBy(n => n.GivenNames, stringComparer).ToList();
        }
    }
}
