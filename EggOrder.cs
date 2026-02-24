using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Симулятор_простого_рестарана_1
{
    internal class EggOrder
    {
        
        private int Kachestvo;
        private static int Count = 0;
        private int NomerObject;
        private int Kolichestvo;

        private static Random random = new Random();

        public EggOrder(int kolichestvo, int? kachestvo = null)
        {
            Kolichestvo = kolichestvo;
            Count++;
            NomerObject = Count;
            Kachestvo = kachestvo ?? random.Next(1,101);
        }

        public int GetQuantity()
        {
            return Kolichestvo;
        }

        public int? GetQuality()
        {
            if(NomerObject % 2 == 0)
            {
                return null;
            }
            return Kachestvo;
      
        }
        public int GetQualiti()
        {
            return Kachestvo;
        }

        public void Crack()
        {
            int? a = GetQuality();

            if(a == null)
            {
                throw new Exception("Kachestvo ne provereno!");
            }
            if(a < 25)
            {
                throw new Exception("Яйцо испорченное");
            }
        }

        public void DiscardShell()
        {

        }

        public void Cook()
        {

        }

    }
}
