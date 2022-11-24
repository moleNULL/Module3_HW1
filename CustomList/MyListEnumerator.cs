using System.Collections;

namespace CustomList
{
    internal class MyListEnumerator<T> : IEnumerator<T>
    {
        private readonly T[] _arr;
        private readonly int _size;
        private int _position;

        // _size is mandatory because _arr.Length == MyList<T>().Capacity
        // and _size == MyList<T>().Count
        public MyListEnumerator(T[] arr, int size)
        {
            _arr = arr;
            _size = size;
            _position = -1;
        }

        public T Current
        {
            get
            {
                if (_position == -1 || _position >= _size)
                {
                    throw new IndexOutOfRangeException();
                }

                return _arr[_position];
            }
        }

        // a mandatory plug for IEnumerator<T>
        object IEnumerator.Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            _position++;

            if (_position < _size)
            {
                return true;
            }

            return false;
        }

        public void Reset() => _position = -1;

        public void Dispose()
        {
        }
    }
}
