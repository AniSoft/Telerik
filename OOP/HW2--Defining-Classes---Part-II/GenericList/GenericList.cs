namespace GenericList
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

    public class GenericList<T> where T: IComparable
    {
        // Fields
        private T[] arr;
        private int count;
        private static readonly int InitioaCapacity = 4;

        //private int capacity;
        public T this[int index]
        {
            get
            {
                if (index > -1)
                {
                    return this.arr[index];
                }
                else
                {

                    throw new IndexOutOfRangeException(String.Format("Index {0} is invalid!", index));
                }
            }

            set
            {
                if (index < 0)
                {
                    throw new IndexOutOfRangeException(String.Format("Index {0} is invalid!", index));
                }
                else if (index > this.count)
                {
                    throw new ArgumentOutOfRangeException("Too large index",String.Format("Index {0} is larger than max element position!", index));
                }
                else
                {
                    arr[index] = value;
                }
            }
        }

        // Properties
        public int Capacity
        {
            get
            {
                return this.arr.Length;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Negative", "The capacity must be positive");
                }
                else if (value < count)
                {
                    throw new ArgumentOutOfRangeException("Negative", "The capacity must be large than position of last elemenet");
                }
                else
                {
                    T[] newarr = new T[value];
                    if (count > 0)
                    {
                        Array.Copy(this.arr, newarr, this.count);
                    }
                    this.arr = newarr;
                }
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        // Constructor
        public GenericList()
        {
            this.arr = new T[InitioaCapacity]; 
        }

        public GenericList(int capacity)
        {
            this.arr = new T[capacity];
        }

        // Methods
        public void AddItem(T item)
        {
            this.InsertItem(count, item);
        }
	
	public void InsertItem(int index, T item)
        {
            if (index > count || index < 0)
            {
                throw new IndexOutOfRangeException("Invalid index: " + index);
            }
            else
            {
                if (this.count >= this.Capacity)
                {
                    Capacity = 2 * Capacity;
                }
         
                T[] bufferarray = new T[Capacity];
                Array.Copy(arr, bufferarray, index);
                Array.Copy(arr, index, bufferarray, index + 1, count - index);
                bufferarray[index] = item;
                this.arr = bufferarray;
                this.count++;
            }
        }
		public T RemoveItem(int index)
		{
			if (index > count || index < 0)
		    	{
				throw new IndexOutOfRangeException("Invalid index: " + index);
		    	}
			else
			{
				T item = arr[index];
				T[] bufferarray = new T[Capacity];
	                	Array.Copy(arr, bufferarray, index);
				Array.Copy(arr, index+1, bufferarray, index, count - index + 1);
				//arr[count - 1] = null;
				this.arr = bufferarray;
				this.count--;

                	return item;
     		}
			
		}
	public void Clear()
        {
            	arr = new T[InitioaCapacity];
		count = 0;
        }
        
	public int IndexOf(T item)
	{
		for (int i = 0; i < arr.Length; i++)
		{
			if (item.Equals(arr[i]))
			{
				return i;
			}
		}
		return -1;
	}
		
        public T Min()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Sequence contains no elements.");
            }
            else
            {
                T[] bufferarray = new T[count];
                Array.Copy(arr, bufferarray, count);
                return bufferarray.OrderBy(x => x).First();
            }
        }
        
        public T Max()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Sequence contains no elements.");
            }
            else
            {
                T[] bufferarray = new T[count];
                Array.Copy(arr, bufferarray, count);
                return arr.OrderByDescending(x => x).First();
            }
        }
        
	public override string ToString()
        {
		StringBuilder sb = new StringBuilder();
	        
	        for (int i = 0; i < count; i++)
	        {
	        	sb.Append(String.Format("{0}, ", arr[i].ToString()));
	        }
		
		sb.Remove(sb.Length - 2, 2);
		return sb.ToString();
	}

    }
}
