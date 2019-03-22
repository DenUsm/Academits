using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaTask
{
    class LambdaTask
    {
        static void Main(string[] args)
        {
            List<Person> peaple = new List<Person>() {
            new Person("Ivan", 25),
            new Person("Denis", 40),
            new Person("Oleg", 20),
            new Person("Ivan", 56),
            new Person("Aleksey", 9),
            new Person("Roman", 10),
            new Person("Oleg", 17),
            new Person("Mikhail", 32),
            new Person("Petr", 45),
            new Person("Genadiy", 4),
            new Person("Egor", 78) };

            //Получить список уникальных имен
            List<string> uniqueList = peaple.Select(p => p.Name).ToList().Distinct().ToList();

            foreach (string val in uniqueList)
            {
                Console.WriteLine(val);
            }

            //вывести список уникальных имен в формате: Имена: Иван, Сергей, Петр
            Console.WriteLine();
            Console.WriteLine("Имена: " + string.Join(", ", uniqueList));

            //получить список людей младше 18, посчитать для них средний возраст
            Console.WriteLine();
            List<Person> personUnder = peaple.Where(p => p.Age < 18).ToList();

            foreach (Person person in personUnder)
            {
                Console.WriteLine(person.ToString());
            }

            int averageOld = personUnder.Sum(p => p.Age) / personUnder.Count;
            Console.WriteLine("Average old peaple under 18 is {0}", averageOld);

            //при помощи группировки получить Map, в котором ключи – имена, а значения – средний возраст
            Console.WriteLine();
            Dictionary<string, int> map = peaple.GroupBy(p => p.Name).ToDictionary(p => p.Key, p => p.Sum(x => x.Age) / p.ToList().Count);

            foreach (var pair in map)
            {
                Console.WriteLine("Key: {0} Value: {1}", pair.Key, pair.Value);
            }

            //получить людей, возраст которых от 20 до 45, вывести в консоль их имена в порядке убывания возраста
            Console.WriteLine();
            var result = peaple.Where(p => ((p.Age >= 20) && (p.Age <= 45)))
                               .OrderBy(p => p.Age, new MyComparer())
                               .Select(p =>
                               {
                                   Console.WriteLine("Name: {0}", p.Name);
                                   return p;
                               }).ToList();


            Console.ReadKey();
        }

        class MyComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                if (x > y)
                {
                    return -1;
                }
                else if (x < y)
                {
                    return 1;
                }
                return 0;
            }
        }
    }
}
