namespace CustomList.TestClassesForForeach
{
    internal class AustraliaContinent : Continent
    {
        private string[] _countries;

        public AustraliaContinent()
        {
            _countries = new string[] { "Australia" };
        }

        public override string Name => "Australia";

        public override IEnumerator<string> GetEnumerator()
        {
            return new ContinentEnumerator(_countries);
        }
    }
}
