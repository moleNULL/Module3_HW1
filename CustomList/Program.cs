/*
                                                      Задача:
                          Необхідно реалізувати свою узагальнену колекцію на основі звичайного масиву.
                                                 По факту свій List<T>

                                                     Критерії:
                                       Мають бути реалізовані наступні методи:

- Add(): додавання нового елементу в список
- AddRange(): додавання в список колекції або масиву
- Remove(): видаляє елемент item із списку, і якщо видалення прошло успішно, то повертає true
- RemoveAt(): видалення елементу по вказаному індексу index
- Sort(): сортування списку

- Reverse()
- ToArray()
- Clear()
- Count; Capacity;

- Звичайно ж має бути реалізований ітератор для цієї колекції

 */

namespace CustomList
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t\tIntroduction to my custom List<T> implementation - MyList<T>\n");

            try
            {
                Starter.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception. {ex.Message}");
            }

            Console.Write("\nPress any key to continue . . .");
            Console.ReadKey();
        }
    }
}