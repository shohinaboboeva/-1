using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Симулятор_простого_рестарана_1
{
    internal class Employee
    {
        private object PosledniZakaz;
        private int ZaprosCount = 0;

        public object NewRequest(string MenuItem, int Quantity)
        {
            ZaprosCount++;
            object zakaz;

            if(ZaprosCount % 3 == 0)
            {
                zakaz = MenuItem == "Chicken"? (object)new EggOrder(Quantity) : new ChickenOrder(Quantity);
            }
            else
            {
                zakaz = MenuItem == "Chicken"? (object)new ChickenOrder(Quantity) : new EggOrder(Quantity);
            }
            PosledniZakaz = zakaz;
            isPrepared = false;
            return zakaz;
        }


        public object CopyRequest()
        {
            if(PosledniZakaz == null)
            {
                throw new Exception("Net predidushego zakaza!");
            }
            if(PosledniZakaz is EggOrder egg)
            {
                return new EggOrder(egg.GetQuantity(), egg.GetQualiti());
            }
            if(PosledniZakaz is ChickenOrder chicken)
            {
                return new ChickenOrder(chicken.GetQuantity());
            }
            throw new Exception("Neizvestniy zakaz");
        
        }

        public string Inspect(object order)
        {
            if(order is ChickenOrder)
            {
                return "Chicken ne trebuet proverki";
            }
            if(order is EggOrder egg)
            {
                int? a = egg.GetQuality();
                if (a == null)
                {
                    return "Sotrudnik zabil proverit egg";
                }
                return $"kachestvo egg: {a}";
            }
            return "Neizvestni zakaz";

        }
        private bool isPrepared = false;
        public string PrepareFood(object order)
        {
            if (isPrepared)
            {
                throw new Exception("Etot zakaz уже приготовлен!");
            }

            if(order is ChickenOrder chicken)
            {
                for(int i = 0; i<chicken.GetQuantity(); i++)
                {
                    chicken.CutUp();
                }
                chicken.Cook();
                isPrepared = true;
                return $"Podgotovleno {chicken.GetQuantity()} chicken.";
            }
            if(order is EggOrder egg)
            {
                int CountGnilieEgg = 0;
                for(int i=0; i<egg.GetQuantity(); i++)
                {
                    try
                    {
                        egg.Crack();
                    }
                    catch
                    {
                        CountGnilieEgg++;
                    }
                    egg.DiscardShell();
                }
                egg.Cook();
                isPrepared = true;
                return $"Podgotovleno {egg.GetQuantity()} egg. Gnilie Egg {CountGnilieEgg}";
            }
            return "Neisvestni zakaz";
        }
    }
}
