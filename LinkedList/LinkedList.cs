using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class LinkedList<T>:IEnumerable<T>
    {
        private Node<T> first;
        private Node<T> last;
        private int count;

        public int Count { get => count; }
        public bool IsEmpty { get => first == null; }

        // Додавання нового вузла у кінець списку.
        public void AddLast(T component)
        {
            // Збереження посилання на кінцевий вузол.
            Node<T> oldlast = last;
            // Створення нового кінцевого вузла.
            last = new Node<T>();
            last.item = component;
            last.next = null;
            // Початок і кінець списку вказують на єдиний елемент.
            if (IsEmpty)
            { first = last; }
            else
            // Прив'язка нового вузла до кінця списку.
            { oldlast.next = last; }
            count++;
        }

        // Додавання нового вузла у початок списку.
        public void AddFirst(T component)
        {
            // Збереження посилання на вузол на вершині.
            Node<T> oldfirst = first;
            // Створення нового вузла.
            first = new Node<T>();
            first.item = component;
            if (IsEmpty)
            { last = first; }
            // Прив'язка старої вершини до нової.
            else
            { first.next = oldfirst; }       
            count++;
        }

        // Видалення вузла із початку списку.
        public T RemoveFirst()
        {
            if (IsEmpty)
            { throw new InvalidOperationException("Список порожній."); }
            // Видалення елементу із початку списку.
            T component = first.item;
            first = first.next;
            if (IsEmpty)
            { last = null; }
            count--;
            return component;
        }

        // Перевірка вмісту заданого вузла у списку.
        public bool Contains(T component)
        {
            Node<T> current = first;
            while (current != null && !current.item.Equals(component))
            { current = current.next; }
            return current != null;
        }

        // Видалення елементу (першого входження) component із списку.
        public bool Remove(T component)
        {
            // Вузол перед вузлом, що видаляється.
            Node<T> previous = null;
            // Вузол, що видаляється.
            Node<T> current = first;

            while (current != null && !current.item.Equals(component))
            {
                previous = current;
                current = current.next;
            }

            // Якщо елемент міститься у списку.
            if (current != null)
            {
                // Якщо елемент, що видаляється є першим у списку.
                if (previous == null)
                // Видалення вузла.
                { first = current.next; }
                else
                // Видалення вузла.
                { previous.next = current.next; }

                // Якщо вузол, що видаляється є останнім у списку.
                if (current.next == null)
                // Видалення вузла.
                { last = previous; }

                count--;
                return true;
            }
            return false; 
        }

        // Видалення k-го елементу, якщо він існує.
        public T RemoveAt(int index)
        {
            if (index < 1)
            { throw new ArgumentOutOfRangeException("Індекс має бути більше 0."); }

            int i = 1;
            // Вузол перед вузлом, що видаляється.
            Node<T> previous = null;
            // Вузол, що видаляється.
            Node<T> current = first;

            while (i < index && current != null)
            {
                previous = current;
                current = current.next;
                i++;
            }

            // Якщо k-ий елемент міститься у списку.
            if (current != null)
            {
                // Якщо елемент, що видаляється є першим у списку.
                if (previous == null)
                // Видалення вузла.
                { first = current.next; }
                else
                // Видалення вузла.
                { previous.next = current.next; }

                // Якщо вузол, що видаляється є останнім у списку.
                if (current.next == null)
                // Видалення вузла.
                { last = previous; }

                count--;
                return current.item;
            }
            else
            { throw new ArgumentOutOfRangeException("Елемент із вказаним" +
                "аргументом індексу не міститься у списку."); }
        }



        // Реалізація інтерфейсу IEnumerable<T>.
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = first;
            while (current != null)
            {
                yield return current.item;
                current = current.next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }
}
