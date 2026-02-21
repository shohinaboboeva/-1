using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Симулятор_простого_рестарана_1
{
    internal class ChickenOrder
    {
        private int Kolichestvo;
        public ChickenOrder(int kolichestvo)
        {
            Kolichestvo = kolichestvo;
        }

        public int GetQuantity()
        {
            return Kolichestvo;
        }

        public void CutUp()
        {
            
        }

        public void Cook()
        {

        }
    }
}
