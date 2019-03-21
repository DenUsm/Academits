using System;

namespace LambdaTask
{
    class Person
    {
        public string Name { get; }
        public int Age { get; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return string.Format("Name: {0} Age: {1}", Name, Age);
        }
    }
}
