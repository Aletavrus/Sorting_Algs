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
    }
}
