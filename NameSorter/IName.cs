namespace NameSorter
{
    using System.Collections.Generic;

    public interface IName
    {
        IList<string> GivenNames { get; set; }
        string Surname { get; set; }
    }
}
