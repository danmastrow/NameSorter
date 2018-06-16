using System;
using System.Collections.Generic;
using System.Linq;

namespace NameSorter
{
    public class NameSorter : INameSorter
    {
        // TODO: Make this more flexible, not hardcoded rules.
        public IList<IName> SortNames(IList<IName> unsorted)
        {
            if (unsorted == null || !unsorted.Any())
            {
                throw new Exception();
            }

            if (unsorted.Count <= 1)
                return unsorted;

            return unsorted.OrderBy(n => n.Surname, StringComparer.InvariantCultureIgnoreCase)
                           .ThenBy(n => n.GivenNames, StringComparer.InvariantCultureIgnoreCase).ToList();
        }

    }
}
