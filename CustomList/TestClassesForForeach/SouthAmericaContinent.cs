namespace CustomList.TestClassesForForeach
{
    internal class SouthAmericaContinent : Continent
    {
        private string[] _countries;

        public SouthAmericaContinent()
        {
            _countries = new string[] { "Venezuela", "Colombia", "Ecuador", "Guyana", "Suriname", "Fr. Guiana", "Peru", "Bolivia", "Paraguay", "Uruguay", "Brazil", "Chile", "Argentina" };
        }

        public override string Name => "South America";

        public override IEnumerator<string> GetEnumerator()
        {
            return new ContinentEnumerator(_countries);
        }
    }
}
