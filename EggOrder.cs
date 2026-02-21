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
        private int Kolichestvo;
        private int Kachestvo;

        private Random random = new Random();

        public EggOrder(int kolichestvo)
        {
            Kolichestvo = kolichestvo;
            Kachestvo = random.Next(1, 101);
        }

        public int GetQuantity()
        {
            return Kolichestvo;
        }

        public int? GetQuality()
        {
            return (random.Next(2) == 0) ? (int?) null : Kachestvo;
        }

        public void Crack()
        {
            int? a = GetQuality();
            if(a.HasValue && a.Value < 25)
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
