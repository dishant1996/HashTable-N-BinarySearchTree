using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash_Table
{

    // created a class MyMapNode
    class MyMapNode<K, V>
    { // const and readonly
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;
        // created a method for mymapnode
        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }
        // created a method for add the key, value
        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);  // |-5| =5 |3|=3 |-3|=3
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };
            linkedList.AddLast(item);
        }
        // created another method for get the key      
        public V Get(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }
        // 5-4345 7-8765456 8-8745
        protected int GetArrayPosition(K key)// 5->-7654323456     5->  7654323456 //78-87654568745 
        { // 100 ->876543456787654  -> 100->876543456787654
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }

        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }
    }
    public struct KeyValue<k, v>
    {
        public k Key { get; set; }
        public v Value { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hash table demo"); //() []
            MyMapNode<string, string> hash = new MyMapNode<string, string>(5);
            hash.Add("0", "To");
            hash.Add("1", "be");
            hash.Add("2", "or");
            hash.Add("3", "not");
            hash.Add("4", "to");
            hash.Add("5", "be");
            string hash5 = hash.Get("5");
            Console.WriteLine("5th index value: " + hash5);
            string hash2 = hash.Get("2");
            Console.WriteLine("2nd index value: " + hash2);
            string hash1 = hash.Get("1");
            Console.WriteLine("0th index value: " + hash1);
            string hash0 = hash.Get("0");
            Console.WriteLine("0th index value: " + hash0);
            string hash4 = hash.Get("4");
            Console.WriteLine("4th index value: " + hash4);
            string hash3 = hash.Get("3");
            Console.WriteLine("3rd index value: " + hash3);
            Console.ReadKey();
        }
    }
}