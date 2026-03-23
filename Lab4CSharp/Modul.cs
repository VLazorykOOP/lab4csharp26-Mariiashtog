using System;
using System.Linq;

namespace Lab4CSharp
{
    // ==========================================
    // ЗАВДАННЯ 1: ПРЯМОКУТНИК
    // ==========================================
    public class Rectangle
    {
        protected int a, b, c;

        public Rectangle(int sideA, int sideB, int color)
        {
            a = sideA; b = sideB; c = color;
        }

        // Індексатор: 0 - a, 1 - b, 2 - колір
        public object this[int index]
        {
            get
            {
                if (index == 0) return a;
                if (index == 1) return b;
                if (index == 2) return c;
                return "Помилка: невірний індекс!";
            }
            set
            {
                if (index == 0) a = (int)value;
                else if (index == 1) b = (int)value;
                else if (index == 2) c = (int)value;
            }
        }

        // Перевантаження операторів
        public static Rectangle operator ++(Rectangle r) { r.a++; r.b++; return r; }
        public static Rectangle operator --(Rectangle r) { r.a--; r.b--; return r; }
        public static bool operator true(Rectangle r) => r.a == r.b;
        public static bool operator false(Rectangle r) => r.a != r.b;
        public static Rectangle operator *(Rectangle r, int scalar) => new Rectangle(r.a * scalar, r.b * scalar, r.c);

        // Перетворення типів
        public override string ToString() => $"{a}, {b}, {c}";
        public static implicit operator string(Rectangle r) => r.ToString();
        public static explicit operator Rectangle(string s)
        {
            var p = s.Split(',');
            return new Rectangle(int.Parse(p[0].Trim()), int.Parse(p[1].Trim()), int.Parse(p[2].Trim()));
        }

        public void Show() => Console.WriteLine($"Прямокутник: a={a}, b={b}, колір={c} | Квадрат: {(this ? "Так" : "Ні")}");
    }

    // ==========================================
    // ЗАВДАННЯ 2: ВЕКТОР (SHORT)
    // ==========================================
    public class VectorShort
    {
        protected short[] ShortArray;
        protected uint n;
        protected uint codeError;
        private static uint num_v = 0;

        public VectorShort(uint size = 1, short init = 0)
        {
            n = size; ShortArray = new short[n];
            for (int i = 0; i < n; i++) ShortArray[i] = init;
            num_v++;
        }

        ~VectorShort() => Console.WriteLine("\n[Система] Пам'ять вектора звільнена.");

        public uint CodeError { get => codeError; set => codeError = value; }
        public static uint CountVectors() => num_v;

        public short this[int index]
        {
            get
            {
                if (index < 0 || index >= n) { codeError = 10; return 0; }
                return ShortArray[index];
            }
            set
            {
                if (index < 0 || index >= n) codeError = 10;
                else ShortArray[index] = value;
            }
        }

        public void Display() => Console.WriteLine("[" + string.Join(", ", ShortArray) + "]");

        // Бінарні операції
        public static VectorShort operator +(VectorShort v1, VectorShort v2) => ApplyOp(v1, v2, (x, y) => (short)(x + y));
        public static VectorShort operator /(VectorShort v1, VectorShort v2) => ApplyOp(v1, v2, (x, y) => y != 0 ? (short)(x / y) : (short)0);
        public static VectorShort operator <<(VectorShort v, int s) => ApplyScalar(v, (short)s, (x, y) => (short)(x << y));

        public static bool operator >(VectorShort v1, VectorShort v2)
        {
            if (v1.n != v2.n) return false;
            for (int i = 0; i < v1.n; i++) if (v1[i] <= v2[i]) return false;
            return true;
        }
        public static bool operator <(VectorShort v1, VectorShort v2) => !(v1 > v2) && v1 != v2;

        private static VectorShort ApplyOp(VectorShort v1, VectorShort v2, Func<short, short, short> op)
        {
            uint maxN = Math.Max(v1.n, v2.n);
            VectorShort res = new VectorShort(maxN);
            for (int i = 0; i < maxN; i++)
            {
                short x = (i < v1.n) ? v1.ShortArray[i] : (short)0;
                short y = (i < v2.n) ? v2.ShortArray[i] : (short)0;
                res.ShortArray[i] = op(x, y);
            }
            return res;
        }

        private static VectorShort ApplyScalar(VectorShort v, short s, Func<short, short, short> op)
        {
            VectorShort res = new VectorShort(v.n);
            for (int i = 0; i < v.n; i++) res.ShortArray[i] = op(v.ShortArray[i], s);
            return res;
        }

        public static bool operator ==(VectorShort v1, VectorShort v2) => v1.n == v2.n && v1.ShortArray.SequenceEqual(v2.ShortArray);
        public static bool operator !=(VectorShort v1, VectorShort v2) => !(v1 == v2);
    }

    // ==========================================
    // ЗАВДАННЯ 3: ПОКУПЦІ (STRUCT & RECORD)
    // ==========================================
    public struct CustomerStruct
    {
        public string Pib, Address, Phone, Card;
        public override string ToString() => $"{Pib} | {Address} | {Phone} | Картка: {Card}";
    }

    public record CustomerRecord(string Pib, string Address, string Phone, string Card);
}