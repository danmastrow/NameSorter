namespace NameSorter
{
    using System.Collections.Generic;
    using System.Linq;

    public static class Sorter
    {
        public static IList<IName> SortNames(IList<IName> unsorted)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            return unsorted.OrderBy(n => n.Surname)
                .ThenBy(n => n.GivenNames).ToList();
        }
    }
}
