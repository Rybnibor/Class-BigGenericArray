using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigArray
{
    /// <summary>
    /// Array of 2000000000 elements.
    /// </summary>
    /// <typeparam name="TItem">The type of the item.</typeparam>
    class BigArray<TItem>
    {
        private const int _bigSize = 2000000000;
        private const int _smallSize = 1000;
        private int _realSize = -1;
        private List<TItem>[] _tablica = new List<TItem>[_bigSize / _smallSize];

        /// <summary>
        /// Initializes a new instance of the <see cref="BigArray{TItem}"/> class.
        /// </summary>
        public BigArray()
        {
            for (int i = 0; i < _bigSize / _smallSize; i++)
            {
                _tablica[i] = new List<TItem>();
            }
        }

        /// <summary>
        /// Adds the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void Add(TItem value)
        {
            if (_realSize < _bigSize)
            {
                int temp = Convert.ToInt32(++_realSize / _smallSize);
                _tablica[temp].Add(value);

            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Gets the specified position.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public TItem Get(int position)
        {
            if (position <= _realSize && position > -1)
            {
                int temp = Convert.ToInt32(position / _smallSize);
                int temp2 = position % _smallSize;
                return _tablica[temp][temp2];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Replaces the specified position.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="value">The value.</param>
        /// <returns>True if successful, false if not.</returns>
        public bool Replace(int position, TItem value)
        {
            if (position <= _realSize && position > -1)
            {
                int temp = Convert.ToInt32(position / _smallSize);
                int temp2 = position % _smallSize;
                _tablica[temp][temp2] = value;
                return true;
            }
            else
            {
                return false;
                //throw new IndexOutOfRangeException();
            }
        }

    }
}
