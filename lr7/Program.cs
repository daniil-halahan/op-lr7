using System.Text;

namespace lr7
{
    class Program
    {
        public class Node
        {
            public int Data;
            public Node Next;

            public Node(int data)
            {
                Data = data;
                Next = null;
            }
        }

        public class SinglLinkedList
        {
            private Node head;

            public SinglLinkedList()
            {
                head = null;
            }

            public void Add(int data)
            {
                Node newNode = new Node(data);
                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    newNode.Next = head.Next;
                    head.Next = newNode;
                }
            }

            public void AddLast(int data)
            {
                Node newNode = new Node(data);
                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    Node current = head;
                    while (current.Next != null)
                    {
                        current = current.Next;
                    }
                    current.Next = newNode;
                }
            }

            /*public int this[int index]
            {
                get
                {
                    Node current = head;
                    int curIndex = 0;
                    while (current != null)
                    {
                        if (curIndex == index)
                        {
                            return current.Data;
                        }
                        curIndex++;
                        current = current.Next;
                    }
                    throw new IndexOutOfRangeException("Index out of range");
                }
                set
                {
                    Node current = head;
                    int curIndex = 0;
                    while (current != null)
                    {
                        if (curIndex == index)
                        {
                            current.Data = value;
                            return;
                        }
                        curIndex++;
                        current = current.Next;
                    }
                    throw new IndexOutOfRangeException("Index out of range");
                }
            }*/

            public int FindFirstOccurrence(int value)
            {
                Node current = head;
                int position = 1;
                while (current != null)
                {
                    if (current.Data == value)
                        return position;
                    current = current.Next;
                    position++;
                }
                return 0;
            }

            public int CountEvenMultiplesAtEvenPositions()
            {
                Node current = head;
                int position = 1;
                int count = 0;
                while (current != null)
                {
                    if (position % 2 == 0 && current.Data % 2 == 0)
                    {
                        count++;
                    }
                    current = current.Next;
                    position++;
                }
                return count;
            }

            public SinglLinkedList GetListUpToMinElement()
            {
                SinglLinkedList result = new SinglLinkedList();
                Node current = head;
                Node minNode = head;
                int minValue = head.Data;

                while (current != null)
                {
                    if (current.Data < minValue)
                    {
                        minValue = current.Data;
                        minNode = current;
                    }
                    current = current.Next;
                }

                current = head;
                while (current != null && current != minNode)
                {
                    result.AddLast(current.Data);
                    current = current.Next;
                }
                return result;
            }

            public void RemoveAfterMinElement()
            {
                if (head == null) return;

                Node current = head;
                Node minNode = head;
                int minValue = head.Data;

                while (current != null)
                {
                    if (current.Data < minValue)
                    {
                        minValue = current.Data;
                        minNode = current;
                    }
                    current = current.Next;
                }

                if (minNode != null)
                    minNode.Next = null;
            }

            public void Print()
            {
                Node current = head;
                while (current != null)
                {
                    Console.Write(current.Data + " ");
                    current = current.Next;
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Введіть елементи для додавання у список: ");
            string[] elements = Console.ReadLine().Split();
            SinglLinkedList list = new SinglLinkedList();
            foreach (string element in elements)
                list.Add(int.Parse(element));

            Console.Write("Введений список: ");
            list.Print();

            Console.WriteLine("Операції зі списком:\n" +
                              "1. Знайти перше входження заданого значення.\n" +
                              "2. Знайти кількість елементів, кратних 2, які розташовані на парних позиціях.\n" +
                              "3. Отримати новий список зі значень елементів, які розташовані до мінімального елементу.\n" +
                              "4. Видалити елементи, які розташовані після мінімального елементу.");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.Write("Введіть значення: ");
                    int n = int.Parse(Console.ReadLine());
                    Console.Write("Позиція першого входження заданого значення: " + list.FindFirstOccurrence(n));
                    break;
                case 2:
                    Console.Write("Кількість елементів, кратних 2, які розташовані на парних позиціях: " + list.CountEvenMultiplesAtEvenPositions());
                    break;
                case 3:
                    Console.Write("Cписок зі значень елементів, які розташовані до мінімального елементу: ");
                    SinglLinkedList upToMin = list.GetListUpToMinElement();
                    upToMin.Print();
                    break;
                case 4:
                    list.RemoveAfterMinElement();
                    Console.Write("Список з видаленими елементами, які розташовані після мінімального елементу: ");
                    list.Print();
                    break;
                default:
                    break;
            }
        }
    }
}