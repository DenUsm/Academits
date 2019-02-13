using System;

namespace VectorTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector vec1 = new Vector(5);
            Vector vec2 = new Vector(vec1);
            Vector vec3 = new Vector(new double[] { 1.2, 5.5, 4.7, 8, 6.4 });
            Vector vec4 = new Vector(5, new double[] { 1, 2, 5, 4, 5 });

            Vector sumTest1 = new Vector(7, new double[] { 1, 2, 3, 4, 5 });
            Vector sumTest2 = new Vector(5, new double[] { 1, 2, 3, 4, 5 });

            Vector vec5 = new Vector(2, new double[] { 1, 2, 5, 4, 5 });
            Vector vec6 = new Vector(7, new double[] { 1, 2, 5, 4, 5 });

            Vector vec7 = new Vector(7, new double[] { 1, 2, 5, 4, 5 });
            Vector vec8 = new Vector(5, new double[] { 1, 2, 3, 4, 5 });
            Vector vec9 = new Vector(7, new double[] { 4, 0, 6, 4, 5 });
            Vector vec10 = new Vector(5, new double[] { 3, 2, 3, 4, 5 });
            Vector vec11 = new Vector(7, new double[] { 1, 2, 3, 4, 5 });
            Vector vec12 = new Vector(5, new double[] { 6, 6, 6, 1, 5 });
            Vector vec13 = new Vector(15, new double[] { 9, 8, 0, 0, 5 });


            sumTest1.Sum(sumTest2);
            vec6.Difference(vec7);
            vec8.Multiplication(10);

            int size = vec13.GetSize();
            bool equals = vec4.Equals(vec5);
            double component = vec3.GetComponent(3);
            vec3.SetComponent(0, 100);

            vec12.Turn();
            double length = vec11.GetLength();

            Vector vector1 = Vector.Sum(vec5, vec7);
            Vector vector2 = Vector.Difference(vec5, vec4);
            double vector3 = Vector.Multiplication(vec4, vec5);
            double vector4 = Vector.Multiplication(vec5, vec4);
            bool equals1 = vector3.Equals(vector4);

            Vector[] vectors = new Vector[] { vec1, vec2, vec3, vec4, vec5, vec6, vec7, vec8, vec9, vec10, vec11, vec12, vec13 };

            foreach (Vector value in vectors)
            {
                Console.WriteLine(value + " " + value.GetSize());
            }
            Console.ReadKey();
        }
    }
}
