namespace NameSorter
{
    using System.Collections.Generic;

    /// <summary>Represents a Name with a single Surname and potentially multiple Given Names.</summary>
    public interface IName
    {
        /// <summary>The Given Names for the Name.</summary>
        IList<string> GivenNames { get; set; }

        /// <summary>The Surname for the Name.</summary>
        string Surname { get; set; }
    }
}
