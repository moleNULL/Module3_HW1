namespace TestClassesForForeach
{
    internal class NorthAmericaContinent : Continent
    {
        private string[] _countries;

        public NorthAmericaContinent()
        {
            _countries = new string[] { "USA", "Canada", "Mexico" };
        }

        public override string Name => "North America";

        public override IEnumerator<string> GetEnumerator()
        {
            return new ContinentEnumerator(_countries);
        }
    }
}
