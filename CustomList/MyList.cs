namespace MyCollections.Generic
{
    // Count, Capacity
    // Add(), AddRange(), Remove(), RemoveAt()
    // Sort(), Sort(IComparer<T>? comparer), Reverse(), ToArray(), Clear()
    // GetEnumerator()
    internal class MyList<T>
    {
        private T[] _arr;
        private int _size;
        private int _capacity;

        public MyList()
        {
            _arr = Array.Empty<T>();
            _size = 0;
            _capacity = 0;
        }

        public MyList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException($"Capacity: {capacity}");
            }

            _capacity = capacity;
            _arr = new T[_capacity];
        }

        public int Count => _size;
        public int Capacity
        {
            get => _capacity;

            set
            {
                if (value < _capacity)
                {
                    throw new Exception("Provided capacity is less than the current one");
                }
                else if (value > _capacity)
                {
                    _capacity = value;
                    IncreaseArray();
                }
            }
        }

        public void Add(T item)
        {
            if (_capacity == 0)
            {
                _capacity = 2; // if 0 let 2 be the initial capacity
                IncreaseArray();
            }
            else if (_capacity < _size + 1)
            {
                // create 2 times larger array if new element needs extra space
                _capacity *= 2;
                IncreaseArray();
            }

            _arr[_size++] = item;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            int collectionSize = collection.Count();

            if (_capacity == 0)
            {
                _capacity = collectionSize;
                IncreaseArray();
            }
            else if (_capacity < collectionSize + _size)
            {
                _capacity *= 2;
                IncreaseArray();
            }

            foreach (var c in collection)
            {
                _arr[_size++] = c;
            }
        }

        public bool Remove(T item)
        {
            int index = Array.IndexOf<T>(_arr, item);

            if (index == -1)
            {
                return false;
            }

            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _size)
            {
                throw new ArgumentOutOfRangeException($"Provided index ({index}) must be not less than 0 " +
                    $"and not equal or bigger than current size({_size})");
            }

            T[] temp = new T[_size - 1];
            for (int i = 0, j = 0; i < _size; i++)
            {
                if (i == index)
                {
                    continue;
                }

                temp[j++] = _arr[i];
            }

            // rewrite elements and clear the previous last element as now it becomes a duplicate
            Array.Copy(temp, _arr, temp.Length);
            _arr[_size - 1] = default!;
            _size--;
        }

        public void Sort() => Array.Sort(_arr, 0, _size);

        public void Sort(IComparer<T>? comparer) => Array.Sort(_arr, 0, _size, comparer);

        public void Reverse() => Array.Reverse(_arr, 0, _size);

        // enabling foreach
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _size; i++)
            {
                yield return _arr[i];
            }
        }

        public T[] ToArray()
        {
            if (_size == 0)
            {
                return Array.Empty<T>();
            }

            // return ONLY a copy of the array
            T[] temp = new T[_size];
            Array.Copy(_arr, temp, _size);

            return temp;
        }

        public void Clear()
        {
            Array.Clear(_arr);
            _size = 0;
        }

        // Resize the array to provide memory-efficient work
        private void IncreaseArray()
        {
            // prevent overflowing by assigning maximum possible capacity
            if (_capacity > Array.MaxLength)
            {
                _capacity = Array.MaxLength;
            }

            T[] temp = new T[_capacity];
            Array.Copy(_arr, temp, _size);
            _arr = temp;
        }
    }
}
