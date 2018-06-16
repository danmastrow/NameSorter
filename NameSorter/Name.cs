namespace NameSorter
{
    using System.Collections.Generic;
    
    /// <summary>Represents a Name with a single Surname and potentially multiple Given Names.</summary>
    public class Name : IName
    { 
        
        /// <summary>The Given Names for the Name.</summary>
        public IList<string> GivenNames { get; set; }
        /// <summary>The Surname for the Name.</summary>
        public string Surname { get; set; }

        /// <summary>Returns the Given Names and Surname concatenated by whitespace.</summary>
        /// <returns>The Given Names and Surname.</returns>
        public override string ToString()
        {
            return $"{string.Join(" ", GivenNames)} {Surname}";
        }
    }
}
