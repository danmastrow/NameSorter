namespace NameSorter
{
    /// <summary>
    /// The interface for a Name with a single Surname and potentially multiple Given Names.
    /// </summary>
    public interface IName
    {
        /// <summary>The Given Names for the Name.</summary>
        /// <value>The given names.</value>
        string GivenNames { get; set; }

        /// <summary>The Surname for the Name.</summary>
        /// <value>The surname.</value>
        string Surname { get; set; }
    }
}
