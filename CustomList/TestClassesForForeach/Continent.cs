namespace CustomList.TestClassesForForeach
{
    // Test class for implementing enumerator for a custom class
    // to use it in foreach loop

    // No need to implement IEnumerable<string> as we use duck typing
    internal abstract class Continent
    {
        public abstract string Name { get; }

        public abstract IEnumerator<string> GetEnumerator();
    }
}
