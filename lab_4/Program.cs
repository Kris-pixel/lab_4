using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace lab_4
{
   public class Set
    {
        public List<int> items = new List<int>();
        public int amountItems;
        static int count=0;

        public Set()
        {
        }

        public Set(int[] a)
        {
            Array.Sort(a);
            items.AddRange(a);
            amountItems = a.Length;
            count++;
        }
        public Set(int a)
        {
            items.Add(a);
            amountItems =1;
        }

        public void Info()
        {
            Console.WriteLine($"Количесво множеств в базе:{count}");
            foreach (int item in items)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine(" ");
        }

        public void Print()
        {
            foreach (int item in items)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine(" ");
        }

        public static string operator >>(Set item, int num ) //delete element
        {
            if(item.items.Remove(num))
            {
                return $"{num} удалено из множества";
            }
            else
            {
                return $"{num} не входит в множество";
            }

        }
        public static string operator <<(Set item, int num) //add
        {
            Set num1 = new Set(num);
            if(item>num1)
            {
                return $"{num} уже входит в множество";
            }
            else
            {
                item.items.Add(num);
                item.amountItems++;
                return $"{num} добавлено в множество";
            }
        }
        public static bool operator >(Set item1, Set item2) //проверка на подмножество
        {
            int flag = 0;
            foreach( int x in item2.items)
            {
                foreach( int y in item1.items)
                {
                    if (x == y)
                        flag++;
                }
            }
            return (flag == item2.amountItems);
        }
        public static bool operator <(Set item1, Set item2) //проверка на подмножество
        {
            int flag = 0;
            foreach (int x in item1.items)
            {
                foreach (int y in item2.items)
                {
                    if (x == y)
                        flag++;
                }
            }
            return (flag == item1.amountItems);
        }

        public static string operator !=(Set item1, Set item2)  //неравенство
        {
            int count = 0;
            if(item1.amountItems==item2.amountItems)
            {
                for(int i=0; i<item2.amountItems; i++)
                {
                    if (!(item1.items[i] == item2.items[i]))
                    {
                        return "множества неравны";
                    }
                    else
                    {
                        count++;
                    }
                }
                return "множества равны";
            }
            else
            {
                return "множества неравны";
            }
        }
        public static string operator ==(Set item1, Set item2)
        {
            int count = 0;
            if (item1.amountItems == item2.amountItems)
            {
                for (int i = 0; i < item2.amountItems; i++)
                {
                    if (!(item1.items[i] == item2.items[i]))
                    {
                        return "множества неравны";
                    }
                    else
                    {
                        count++;
                    }
                }
                return "множества равны";
            }
            else
            {
                return "множества неравны";
            }
        }

        public static string operator %(Set item1, Set item2)  //crossover
        {
            Set cross = new Set();
            bool mark=false;
            foreach(int x in item1.items)
            {
                foreach(int y in item2.items)
                {
                    if (x == y)
                    {
                        mark = true;
                        cross.items.Add(x);
                    }
                }
            }
            if (mark)
            {
                cross.Print();
                return "пересечене создано";
            }
            else
            {
                return "пересечени - пустое множество";
            }
        }
        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Set s = (Set)obj;
                return (amountItems == s.amountItems) && (items == s.items);
            }
        }
        public override int GetHashCode()
        {
            return (amountItems * 2) / count;
        }
        public class Owner
        {
            static int ID = 109120;
            static string name = "Alan Walker";
            static string org = "Sibyl";
            public void Info()
            {
                Console.WriteLine($"\n{ID}\n{name}\n{org}");
            }
        }
        public class Date
        {
            public static int count = 1;
            public string createdate;
            public Date()
            {

                createdate = DateTime.Now.ToString();
                Console.WriteLine($"Время создания {count} объекта {createdate}");
                count++;
            }
        }
    }
    public static class StaticOperation
    {
        static int sum=0;
        static int max;
        static int min;
        static int count = 0;

        public static int Sum(Set item)
        {
            foreach (int x in item.items)
            {
                sum += x;
            }
            return sum;
        }

        public static int Diff(Set item)
        {
            min = item.items[0];
            max = item.items[item.amountItems - 1];
            return max - min;
        }
        public static int Count(Set items)
        {
            foreach(int x in items.items)
            {
                count++;
            }
            return count;
        }

        public static string ShortestW(this string st, string str)
        {
            if( st.Length>str.Length)
            {
                return str;
            }
            else
            {
                return st;
            }
        }

        public static void Sort(Set item)
        {
            item.Print();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] a =new int[] { 1, 41, 2, 6, 8, 4, 23, 57 };
            Set set1 = new Set(a);
            set1.Info();
            a = new int[] { 2, 6, 3, 8, 37, 1, 5 };
            Set set2 = new Set(a);
            set2.Info();
            Set set3 = new Set(a);
            set3.Info();            
            var s = set1 % set2;
            set1.Print();
            set2.Print();
            Console.WriteLine(set1 != set2);
            Console.WriteLine($"проверка на подмножество:{set1 < set2}");
            set2.Print();
            set3.Print();
            Console.WriteLine(set2 != set3);
            Console.WriteLine($"проверка на подмножество:{set2<set3}");
            Console.WriteLine($"add: {set1 >> 3}");
            Console.WriteLine($"remove: {set2 << 53}");
            Set.Owner o = new Set.Owner();
            o.Info();
            Set.Date d = new Set.Date();
            set1.Print();
            Console.WriteLine(StaticOperation.Count(set1));
            Console.WriteLine(StaticOperation.Diff(set1));
            Console.WriteLine(StaticOperation.Sum(set1));
            Console.WriteLine(StaticOperation.ShortestW("vfbhdnhi","bjofnbogn"));
            StaticOperation.Sort(set2);

        }
    }
}
