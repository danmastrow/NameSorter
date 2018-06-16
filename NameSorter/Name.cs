namespace NameSorter
{
    /// <summary>
    /// Represents a Name with a single Surname and potentially multiple Given Names.
    /// </summary>
    /// <seealso cref="NameSorter.IName" />
    public class Name : IName
    {
        /// <summary>The Given Names for the Name.</summary>
        /// <value>The given names.</value>
        public string GivenNames { get; set; }

        /// <summary>The Surname for the Name.</summary>
        /// <value>The surname.</value>
        public string Surname { get; set; }

        /// <summary>The number of Given Names in this Name.</summary>
        /// <value>The given name count.</value>
        public int GivenNameCount { get { return GivenNames.Split(" ").Length; } }

        /// <summary>
        /// Returns the Given Names and Surname concatenated by whitespace.
        /// </summary>
        /// <returns>The Given Names and Surname.</returns>
        public override string ToString()
        {
            return $"{string.Join(" ", GivenNames)} {Surname}";
        }
    }
}
