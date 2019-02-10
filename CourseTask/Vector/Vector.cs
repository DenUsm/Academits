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
            catch (ArgumentException ex)
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
                for (int i = 0; i < components.Length; i++)
                {
                    Components[i] = components[i];
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("{0} do not create {1}", GetType().Name, ex);
            }
        }

        public int GetSize()
        {
            return Components.Length;
        }

        public void Sum(Vector vector)
        {
            if (GetSize() < vector.GetSize())
            {
                double[] copy = Components;
                Components = new double[vector.GetSize()];
                Components.SetValue(0, Components.Length - 1);
                for (int i = 0; i < copy.Length; i++)
                {
                    Components[i] = copy[i];
                }
            }
            for (int i = 0; i < vector.GetSize(); i++)
            {
                Components[i] += vector.Components[i];
            }
        }

        public void Difference(Vector vector)
        {
            if (GetSize() < vector.GetSize())
            {
                double[] copy = Components;
                Components = new double[vector.GetSize()];
                Components.SetValue(0, Components.Length - 1);
                for (int i = 0; i < copy.Length; i++)
                {
                    Components[i] = copy[i];
                }
            }
            for (int i = 0; i < vector.GetSize(); i++)
            {
                Components[i] -= vector.Components[i];
            }
        }

        public void Multiplication(int value)
        {
            for (int i = 0; i < GetSize(); i++)
            {
                Components[i] *= value;
            }
        }

        public void Turn()
        {
            for (int i = 0; i < GetSize(); i++)
            {
                Components[i] *= -1;
            }
        }

        public double GetLength()
        {
            double sumSquare = 0;
            for (int i = 0; i < GetSize(); i++)
            {
                sumSquare += Math.Pow(Components[i], 2);
            }
            return Math.Sqrt(sumSquare);
        }

        public double GetComponent(int index)
        {
            return Components[index];
        }

        public void SetComponent(double value, int index)
        {
            Components[index] = value;
        }

        public static Vector Sum(Vector firstVector, Vector secondVector)
        {
            Vector vector = new Vector(firstVector.Components);
            if (firstVector.GetSize() < secondVector.GetSize())
            {
                double[] copy = firstVector.Components;

                vector = new Vector(secondVector.GetSize());
                vector.Components.SetValue(0, vector.GetSize() - 1);
                for (int i = 0; i < copy.Length; i++)
                {
                    vector.Components[i] = copy[i];
                }
            }
            for (int i = 0; i < secondVector.GetSize(); i++)
            {
                vector.Components[i] += secondVector.Components[i];
            }
            return vector;
        }

        public static Vector Difference(Vector firstVector, Vector secondVector)
        {
            Vector vector = new Vector(firstVector.Components);
            if (firstVector.GetSize() < secondVector.GetSize())
            {
                double[] copy = firstVector.Components;
                vector = new Vector(secondVector.GetSize());
                vector.Components.SetValue(0, vector.GetSize() - 1);
                for (int i = 0; i < copy.Length; i++)
                {
                    vector.Components[i] = copy[i];
                }
            }
            for (int i = 0; i < secondVector.GetSize(); i++)
            {
                vector.Components[i] -= secondVector.Components[i];
            }
            return vector;
        }

        public override string ToString()
        {
            return "{" + string.Join(", ", Components) + "}";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }
            if (ReferenceEquals(obj, null) || GetType() != obj.GetType())
            {
                return false;
            }
            Vector vector = (Vector)obj;
            return Components == vector.Components && GetSize() == vector.GetSize();
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            double sumComponent = 0;
            for (int i = 0; i < GetSize(); i++)
            {
                sumComponent += Components[i];
            }
            hash = prime * hash + (int)sumComponent;
            return hash;
        }
    }
}
