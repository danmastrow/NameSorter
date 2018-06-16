namespace NameSorter
{
    using System.Collections.Generic;

    /// <summary>The interface for a sorter of Names.</summary>
    public interface INameSorter
    {
        IList<IName> SortNames(IList<IName> unsorted);
    }
}