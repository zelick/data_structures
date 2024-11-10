using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresTest
{
    //decleration doesnt allocate memory
    public class Arrays
    {
        //difrent initialization
        int[] intArray = new int[5]; //allocate the memory for 5 integers, 4 bytes for integer, 5*4 = 20 bytes, FIXED SIZE
        int[] intArray1 = new int[5] { 1, 2, 3, 4, 5 }; //Assigning values to array elements: O(n)


        string[] stringArray = new string[5];
        double[] doubleArray =  new double[5];
        Object[] objectArray = new Object[5];  //some object type, example Student

        //creates a two-dimensional array 
        int[,] twoDimensionalArray = new int[4, 2];

        int[,] intarray = { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
        //creates a three-dimenisonal array
        int[,,] threeDimensionalArray = new int[4, 3, 3];

        //jagged array - "niz nizova"
        int[][] jaggedArray = new int[3][];

        //asign the value 
        public void AssignArray()
        {
            this.intArray[0] = 30;
        }

        public void IterateIntArray()
        {
            foreach(int i in intArray) //O(n)
            {
                Console.WriteLine(i);
            }
        }

        public void IterateTwoDimensionalArray()  //O(m*n) columns * rows
        {
            for (int i = 0; i < intarray.GetLength(0); i++) // Rows
            {
                for (int j = 0; j < intarray.GetLength(1); j++) // Columns
                {
                    Console.WriteLine(intarray[i, j]);
                }
            }
        }

        public void IterateJaggedArray()
        {
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.WriteLine(jaggedArray[i][j]);
                }
            }
        }

        public void CopyResizeArray()
        {
            int[] sourceArray = { 1, 2, 3, 4, 5 };
            int[] destinationArray = new int[5];
            Array.Copy(sourceArray, destinationArray, 5);
            //Resize - Creates a new array with the specified size and copies the elements of the original array to this new array
            Array.Resize(ref destinationArray, 10); 
        }
    }
}
