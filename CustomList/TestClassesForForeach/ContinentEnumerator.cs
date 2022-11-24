using System.Collections;

namespace TestClassesForForeach
{
    internal class ContinentEnumerator : IEnumerator<string>
    {
        private readonly string[] _countries;
        private int _position;

        public ContinentEnumerator(string[] countries)
        {
            _countries = countries;
            _position = -1;
        }

        public string Current
        {
            get
            {
                if (_position == -1 || _position >= _countries.Length)
                {
                    throw new IndexOutOfRangeException();
                }

                return _countries[_position];
            }
        }

        // a mandatory plug for IEnumerator<T>
        object IEnumerator.Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            _position++;

            if (_position < _countries.Length)
            {
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _position = -1;
        }

        public void Dispose()
        {
        }
    }
}
