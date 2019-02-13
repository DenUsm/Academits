using System;

namespace VectorTask
{
    public class Vector
    {
        private double[] Components { get; set; }

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Size of vector must be > 0", nameof(n));
            }

            Components = new double[n];
        }

        public Vector(Vector vector)
        {
            int length = vector.GetSize();
            Components = new double[length];
            Array.Copy(vector.Components, Components, length);
        }

        public Vector(double[] components)
        {
            int length = components.Length;
            if (length == 0)
            {
                throw new ArgumentException("Size of vector must be > 0", nameof(components));
            }

            Components = new double[length];
            Array.Copy(components, Components, length);
        }

        public Vector(int n, double[] components)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Size of vector must be > 0", nameof(n));
            }

            Components = new double[n];
            Array.Copy(components, Components, components.Length);
        }

        public int GetSize()
        {
            return Components.Length;
        }

        public void VectorAligment(Vector vector)
        {
            if (GetSize() < vector.GetSize())
            {
                double[] copy = Components;
                Components = new double[vector.GetSize()];
                Array.Copy(copy, Components, copy.Length);
            }
        }

        public void Sum(Vector vector)
        {
            VectorAligment(vector);
            for (int i = 0; i < vector.GetSize(); i++)
            {
                Components[i] += vector.Components[i];
            }
        }

        public void Difference(Vector vector)
        {
            VectorAligment(vector);
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
            Multiplication(-1);
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

        public void SetComponent(int index, double value)
        {
            Components[index] = value;
        }

        public static Vector Sum(Vector firstVector, Vector secondVector)
        {
            Vector vector = new Vector(firstVector);
            vector.Sum(secondVector);
            return vector;
        }

        public static Vector Difference(Vector firstVector, Vector secondVector)
        {
            Vector vector = new Vector(firstVector);
            vector.Difference(secondVector);
            return vector;
        }

        public static double Multiplication(Vector firstVector, Vector secondVector)
        {
            if (firstVector.GetSize() < secondVector.GetSize())
            {
                firstVector.Components = new double[secondVector.GetSize()];
                Array.Copy(secondVector.Components, firstVector.Components, secondVector.GetSize());
            }

            double sumMultiplicationComponent = 0;
            for (int i = 0; i < firstVector.GetSize(); i++)
            {
                sumMultiplicationComponent += firstVector.Components[i] * secondVector.Components[i];
            }
            return sumMultiplicationComponent;
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

            if (GetSize() != vector.GetSize())
            {
                return false;
            }

            for (int i = 0; i < GetSize(); i++)
            {
                if (Components[i] != vector.Components[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            foreach (double value in Components)
            {
                hash += prime * hash + value.GetHashCode();
            }
            return hash;
        }
    }
}
