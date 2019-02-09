using System;

namespace Vector
{
    class Vector
    {
        public double[] Components { get; set; }

        public Vector(int n)
        {
            try
            {
                if (n <= 0)
                {
                    throw new ArgumentException("Size of vector must be > 0", nameof(n));
                }
                Components = new double[n];
                Components.SetValue(0, Components.Length - 1);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine("{0} do not create {1}", GetType().Name, ex);
            }
        }

        public Vector(Vector vector)
        {
            Components = vector.Components;
        }

        public Vector(double[] components)
        {
            Components = components;
        }

        public Vector(int n, double[] components)
        {
            try
            {
                if (components.Length > n)
                {
                    throw new ArgumentException("Components count must be <= size of vector", nameof(components));
                }
                Components = new double[n];
                Components.SetValue(0, Components.Length - 1);
                for(int i = 0; i < components.Length; i++)
                {
                    Components[i] = components[i];
                }
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine("{0} do not create {1}", GetType().Name, ex);
            }
        }

        public int GetSize()
        {
            return Components.Length;
        }

        public override string ToString()
        {
            return "{" + string.Join(", ", Components) + "}";
        }
    }
}
