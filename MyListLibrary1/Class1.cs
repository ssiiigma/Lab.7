using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MyListLibrary
{
    /// <summary>
    /// Власна реалізація списку символів.
    /// </summary>
    public class MyCharList : IEnumerable<char>
    {
        private List<char> _items = new List<char>();

        /// <summary>
        /// Додає елемент у кінець списку.
        /// </summary>
        public void Add(char item) => _items.Add(item);

        /// <summary>
        /// Видаляє елемент за індексом.
        /// </summary>
        public void RemoveAt(int index)
        {
            if (index >= 0 && index < _items.Count)
                _items.RemoveAt(index);
            else
                throw new ArgumentOutOfRangeException(nameof(index));
        }

        /// <summary>
        /// Повертає індекс першого входження символу.
        /// </summary>
        public int IndexOf(char target) => _items.IndexOf(target);

        /// <summary>
        /// Обчислює суму ASCII кодів символів на непарних позиціях.
        /// </summary>
        public int SumOddPositions()
        {
            int sum = 0;
            for (int i = 1; i < _items.Count; i += 2)
                sum += _items[i];
            return sum;
        }

        /// <summary>
        /// Повертає новий список з елементами, що більші за threshold.
        /// </summary>
        public MyCharList GetElementsGreaterThan(char threshold)
        {
            var result = new MyCharList();
            foreach (var c in _items)
                if (c > threshold)
                    result.Add(c);
            return result;
        }

        /// <summary>
        /// Видаляє елементи, ASCII яких більші за середнє значення.
        /// </summary>
        public void RemoveGreaterThanAverage()
        {
            double avg = _items.Average(c => (int)c);
            _items = _items.Where(c => c <= avg).ToList();
        }

        /// <summary>
        /// Дозволяє доступ до елементів за індексом.
        /// </summary>
        public char this[int index] => _items[index];

        /// <summary>
        /// Дозволяє перебір колекції через foreach.
        /// </summary>
        public IEnumerator<char> GetEnumerator() => _items.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Повертає кількість елементів у списку.
        /// </summary>
        public int Count => _items.Count;
    }
}
