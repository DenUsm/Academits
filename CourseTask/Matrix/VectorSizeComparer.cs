using System.Collections.Generic;
using VectorTask;

namespace Matrix 
{
    class VectorSizeComparer : IComparer<Vector>
    {
        public int Compare(Vector firstVector, Vector secondVector)
        {
            if(firstVector.GetSize() > secondVector.GetSize())
            {
                return -1;
            }
            else if(firstVector.GetSize() < secondVector.GetSize())
            {
                return 1;
            }
            return 0;
        }
    }
}
