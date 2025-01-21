using System.Runtime.CompilerServices;

// Mit diesem Attribut koennen wir internals fuer andere Projekte sichtbar machen
[assembly: InternalsVisibleTo("Calculator.xTest")]

namespace Calculator
{
    public class Calc
    {
        internal int Add(int a, int b)
        {
            // checked wirft eine OverflowException wenn ein int zu groß ist
            checked
            {
                return a + b;
            }
        }

        public int Multiply(int a, int b)
        {
            return a * b;

            // Wenn jemand den Operator durch Dividieren ersetzt laueft unser Test 1/1/1 noch immer durch
            // return a / b;
        }
    }
}
