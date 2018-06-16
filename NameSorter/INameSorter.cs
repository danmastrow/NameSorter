namespace NameSorter
{
    using System;
    using System.Collections.Generic;

    /// <summary>The interface for a sorter of Names.</summary>
    public interface INameSorter
    {
        /// <summary>Sorts the list of names.</summary>
        /// <param name="unsorted">The list of unsorted names.</param>
        /// <param name="stringComparer">The specific case and string culture comparison rules.</param>
        /// <returns></returns>
        IList<IName> SortNames(IList<IName> unsorted, StringComparer stringComparer);
    }
}   