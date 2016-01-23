using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDelegate
{
    class Program
    {
        private delegate string GetAString();
        struct Currency
        {
            public uint Dollars;
            public ushort Cents;
            public Currency(uint dollars, ushort cents)
            {
                this.Dollars = dollars;
                this.Cents = cents;
            }
            public override string ToString()
            {
                return string.Format("${0}.{1,2:00}",Dollars,Cents);
            }
            public static string GetCurrencyUnit() { return "Dolar"; }
            public static explicit operator Currency(float value)
            {
                checked {
                    uint dollars = (uint)value;
                    ushort cents = (ushort)((value - dollars) * 100);
                    return new Currency(dollars, cents);
                }
            }
            public static implicit operator float(Currency value)
            {
                return value.Dollars + (value.Cents / 100.0f);
            }
            public static implicit operator Currency(uint value)
            {
                return new Currency(value, 0);
            }
            public static implicit operator uint(Currency value)
            {
                return value.Dollars;
            }
        }
        class MathOp
        {
            public static void Cheng2(double value)
            {
                Console.WriteLine("Value is {0},result of operation is {1}", value, value * 2);
            }
            public static void Square(double value)
            { 
                Console.WriteLine("Value is {0},result of operation is {1}", value, value * value);
            }

        }
        delegate double doubleop(double x);
        static void ProDisplay(doubleop a, double value)
        {
            Console.WriteLine("Value is {0},result of operation is {1}",value,a(value));
        }
        static void Main(string[] args)
        {
            //int x = 40;
            //GetAString firstStringMethod = new GetAString(x.ToString);
            //Console.WriteLine("String is {0}",firstStringMethod());
            //Console.ReadLine();

            //Currency balance = new Currency(34, 50);
            //firstStringMethod = balance.ToString;
            //Console.WriteLine("string is {0}",firstStringMethod());

            //firstStringMethod = new GetAString(Currency.GetCurrencyUnit);
            //Console.WriteLine("string is {0}", firstStringMethod()); 
            Action<double> ops1 = MathOp.Cheng2;
            Action<double> ops2 = MathOp.Square;
            Action<double> ops3 = ops1 + ops2;
            Action<double> ops4 = delegate(double param)
            {
                Console.WriteLine("Value is {0},result of operation is {1}",param,param+33);
            };
            ops1(7.94);
            ops2(7.94);
            ops3(7.94);
            ops4(7.94);
                //Console.WriteLine("Value is {0},result of operation is {1}", 2.0, ops[i](2.0));
                //Console.WriteLine("Value is {0},result of operation is {1}", 7.94, ops[i](7.94));
                //Console.WriteLine("Value is {0},result of operation is {1}", 1.414, ops[i](1.414));
                Console.ReadLine();

        }
    }
}
