using System;

namespace Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector testEx = new Vector(-5);
            Vector testEx1 = new Vector(4, new double[] { 1, 2, 3, 4, 5 });

            Vector vec1 = new Vector(5);
            Vector vec2 = new Vector(vec1);
            Vector vec3 = new Vector(new double[] { 1.2, 5.5, 4.7, 8, 6.4 });
            Vector vec4 = new Vector(5, new double[] { 1, 2, 3, 4, 5 });


            Vector[] mass = new Vector[] { vec1, vec2, vec3, vec4 };

            foreach (Vector val in mass)
            {
                Console.WriteLine(val);
            }

            Console.ReadKey();
        }
    }
}
