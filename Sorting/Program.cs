using System.ComponentModel;
using System.Text.Json.Serialization.Metadata;

namespace Sorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter size of array");
            int size = int.Parse(Console.ReadLine());
            Console.WriteLine("Do you want to have randomly generated values in array? (answer with lower case letters)");
            string command = Console.ReadLine();
            int[] array = new int[size];
            if (command == "yes")
            {
                array = CreateRandomArray(size);
                Print(array);
            }
            else
            {
                array = CreateArray(size);
                Print(array);
            }
            Console.WriteLine("Which type of sorting algorithm do you want to use?");
            string type = Console.ReadLine();
            if (type == "insertion")
            {
                array = Insertion_Sort(array);
            }
            if (type == "bubble")
            {
                array = Bubble_Sort(array);
            }
            if (type == "quick")
            {
                array = Quick_Sort(array);
            }

            Print(array);
        }
        public static int[] CreateRandomArray (int size)
        {
            Random random = new Random();
            int[] array = new int[size];
            for (int i =0; i < size; i++)
            {
                array[i] = random.Next(0, 1000);
            }
            return array;
        }
        public static int[] CreateArray(int size)
        {
            Console.WriteLine("Enter a value (1 per string)");
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                string input = Console.ReadLine();
                int element = int.Parse(input);
                array[i] = element;
            }
            return array;
        }
        public static void Print(int[] array)
        {
            for (int i = 0; i< array.Length;i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
        }

        public static int[] Insertion_Sort(int[] array)
        {
            for (int i = 1; i < array.Length;i++)
            {
                int index_of_el = i;
                int j = i - 1;
                int value_to_compare = array[j];
                int swap_value = array[i];
                while(swap_value < value_to_compare & j>=0)
                {
                    (array[index_of_el], array[j]) = (array[j], array[index_of_el]);
                    index_of_el = j;
                    swap_value = array[index_of_el];
                    j--;
                    if (j >= 0)
                    {
                        value_to_compare = array[j];
                    }
                }
            }
            return array;
        }

        public static int[] Bubble_Sort(int[] array)
        {
            for (int i = 0; i< array.Length-1; i++)
            {
                for (int j = 0;  j < array.Length-i-1; j++)
                {
                    if (array[j] > array[j+1])
                    {
                        int temp_el = array[j];
                        array[j] = array[j+1];
                        array[j+1] = temp_el;
                    }
                }
            }
            return array;
        }

        public static int[] Quick_Sort(int[] array)
        {
            if (array.Length == 0)
            {
                return array;
            }
            int pivot = array[array.Length-1];
            int swap_marker = -1;

            if (array.Length == 1)
            {
                return array;
            }

            if (array.Length == 2)
            {
                if (array[0] > array[1])
                {
                    int temp_el = array[0];
                    array[0] = array[1];
                    array[1] = temp_el;
                }
                return array;
            }

            for (int index=0; index< array.Length; index++)
            {
                if (array[index] <= pivot)
                {
                    swap_marker++;
                    if (swap_marker < index)
                    {
                        int temp_el = array[swap_marker];
                        array[swap_marker] = array[index];
                        array[index] = temp_el;
                    }
                }
            }

            int size_big = 0;
            int size_small = 0;

            for (int i=0; i< array.Length; i++)
            {
                if (array[i] > pivot)
                {
                    size_big++;
                }
                if (array[i] < pivot)
                {
                    size_small++;
                }
            }

            int[] small_array = new int[size_small];
            int[] big_array = new int[size_big];

            int index_big = 0;
            int index_small = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > pivot)
                {
                    big_array[index_big] = array[i];
                    index_big++;
                }
                if (array[i] < pivot)
                {
                    small_array[index_small] = array[i];
                    index_small++;
                }
            }
            int[] new_small = Quick_Sort(small_array);

            int[] new_big = Quick_Sort (big_array);

            int[] pivot_element = { pivot };
            int[] result = new_small.Concat(pivot_element.Concat(new_big)).ToArray();
            return result;
        }
    }
}
