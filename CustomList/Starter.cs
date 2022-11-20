using CustomList.TestClassesForForeach;
using MyCollections.Generic;

namespace CustomList
{
    // class to execute all the program logic to preserve Main() clean
    internal class Starter
    {
        public static void Run()
        {
            DemonstrateCustomIntList();
            Console.WriteLine("\n\n");
            DemonstrateCustomClassList();
        }

        // Demonstrate work with MyList<int>
        public static void DemonstrateCustomIntList()
        {
            Console.WriteLine("\t\t\t\t\tDemonstrate work with MyList<int>:\n\n");

            int capacity = 3;
            MyList<int> list = new MyList<int>(capacity);
            Console.WriteLine($"Provided initial capacity ({capacity}) for MyList<int>");
            PrintListInfo(list);

            list.AddRange(new int[] { 1, 2, 3, 4, 5 });
            Console.WriteLine($"Added range as int[]: {ListToString(list)}");

            list.Add(7);
            list.Add(66);
            list.Add(-5);
            list.Add(3);
            list.Add(8);
            list.Add(700);
            list.Add(0);
            list.Add(666);
            Console.WriteLine("Added several numbers one by one via Add()");
            Console.WriteLine($"Current MyList<int> elements: {ListToString(list)}");
            PrintListInfo(list);

            int valueToRemove = 4;
            list.Remove(valueToRemove);
            Console.WriteLine($"Remove value: {valueToRemove}");
            Console.WriteLine($"Current MyList<int> elements: {ListToString(list)}\n");

            Console.WriteLine("Sort in ascending order");
            list.Sort();
            Console.WriteLine($"Current MyList<int> elements: {ListToString(list)}\n");

            Console.WriteLine("Sort in descending order");
            list.Reverse();
            Console.WriteLine($"Current MyList<int> elements as an int[]: {PrintArray(list.ToArray())}\n");

            Console.WriteLine("Clear MyList<int>");
            list.Clear();
            Console.WriteLine($"Current MyList<int> elements: {ListToString(list)}");
            PrintListInfo(list);
        }

        // Demonstrate work with MyList<Continent>
        public static void DemonstrateCustomClassList()
        {
            var americaNorth = new NorthAmericaContinent();
            var americaSouth = new SouthAmericaContinent();
            var australia = new AustraliaContinent();

            var continents = new MyList<Continent>();

            continents.AddRange(new Continent[] { americaNorth, americaSouth });
            continents.Add(australia);

            Console.WriteLine("\t\t\tDemonstrate work with MyList<Continent>: " +
                "list of countries in continents\n\n");

            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Name}:");
                foreach (var country in continent)
                {
                    Console.WriteLine("\t" + country);
                }

                Console.WriteLine();
            }

            PrintListInfo(continents);
        }

        // Print information about current values in the properties: Count, Capacity
        private static void PrintListInfo<T>(MyList<T> list)
        {
            Console.WriteLine($"\n\tMyList<T> info: Count: {list.Count} | Capacity: {list.Capacity}\n");
        }

        // convert all values in the MyList<int> into a single string
        private static string ListToString(MyList<int> list)
        {
            string str = string.Empty;

            foreach (var item in list)
            {
                str += $"{item} ";
            }

            return str;
        }

        // the same method as PrintListInfo() but working with only with int[]
        private static string PrintArray(int[] arr)
        {
            string str = string.Empty;

            for (int i = 0; i < arr.Length; i++)
            {
                str += $"{arr[i]} ";
            }

            return str;
        }
    }
}