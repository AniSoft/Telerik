namespace GenericListTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class NotIComparableClass
    {
        private int number;
        public int Number { get; set; }

        public NotIComparableClass(int num)
        {
            this.Number = num;
        }
    }
}
