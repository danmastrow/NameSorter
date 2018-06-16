namespace NameSorter
{
    using System.Collections.Generic;

    public class Name : IName
    {
        public IList<string> GivenNames { get; set; }
        public string Surname { get; set; }

        public override string ToString()
        {
            return $"{string.Join(" ", GivenNames)} {Surname}";
        }
    }
}
