using System;
using System.Diagnostics;

namespace dotnet_study.nocvko
{
    abstract class Figure{
        public string name;
        public string type;
        protected double p;
        protected double s;

        public double Per{
            get{
                return p;
            }
            set{
                Console.WriteLine("Error");
            }
        }

        public double Sq{
            get{
                return s;
            }
            set{
                Console.WriteLine("Error");
                }
        }


        public Figure(string name, string type){
            this.name = name;
            if ((type == "2d" ^ type == "3d") != true){
                throw new MyException("Неверный тип", 0);
            }
            this.type = type;
            ShowNameNType();
        }

        public void ShowNameNType(){
            // Вывод в консоль имени и типа фигуры.
            Console.WriteLine($"Name: {this.name}\nType: {this.type}");
        }

        public abstract void S();
        public abstract void P();
    }

    //Square, Rectangle, Triangle, Circle, Cube, Ball
    class Square : Figure
    {
        // Длина стороны квадрата.
        protected int a; // Длина стороны квадрата.
        public Square(string name, string type, int a) : base(name, type)
        {
            this.a = a;
            this.P();
            this.S();
        }

        public override void P()
        {
            this.p = 4 * this.a;
            Console.WriteLine($"Периметр = {this.p}");
        }

        public override void S()
        {
            this.s = (int)System.Math.Pow(this.a, 2);
            Console.WriteLine($"Площадь = {this.s}");
        }

    }

    class Rectangle : Figure
    {
        public int a;  // Длина прямоугольника.
        public int b;  // Ширина прямоугольника.

        public Rectangle(string name, string type, int a, int b) : base(name, type)
        {
            if (a <= 0 && b <= 0){
                throw new ZeroValueException("Параметр болжен быть больше 0", 0);
            }
            this.a = a;
            this.b = b;
            this.P();
            this.S();
        }

        public override void P()
        {
            this.p = 2 * this.a + 2 * this.b;
            Console.WriteLine($"Периметр = {this.p}");
        }

        public override void S()
        {
            this.s = this.a * this.b;
            Console.WriteLine($"Площадь = {this.s}");
        }
    }

    class Triangle : Figure
    {
        protected int a;  // Длина левой стороны треугольника.
        protected int b;  // Длина правой стороны треугольника.
        protected int c;  // Длина основания треугольника.
        public Triangle(string name, string type, int a, int b, int c) : base(name, type)
        {
            if (a <= 0 && b <= 0 && c <= 0){
                throw new ZeroValueException("Параметр болжен быть больше 0", 0);
            }
            this.a = a;
            this.b = b;
            this.c = c;
            this.P();
            this.S();
        }
        public override void P()
        {
            this.p = this.a + this.b + this.c;
            Console.WriteLine($"Периметр = {this.p}");
        }

        public override void S()
        {
            double p_2 = (double)this.p / 2; // Полупериметр треугольника.
            this.s = Math.Sqrt(p_2 * (p_2 - this.a) * (p_2 - this.b) * (p_2 - this.c));
            Console.WriteLine($"Площадь = {this.s}");
        }
    }

    class Circle : Figure
    {
        protected int r; // Радиус круга.
        public Circle(string name, string type, int r) : base(name, type)
        {
            if (r <= 0 ){
                throw new ZeroValueException("Параметр болжен быть больше 0", 0);
            }
            this.r = r;
            this.P();
            this.S();
        }

        public override void P()
        {
            this.p = 2 * Math.PI * this.r;
            Console.WriteLine($"Периметр = {this.p}");
        }

        public void V(){
            this.P();
        }

        public override void S()
        {
            this.s = Math.PI * Math.Pow(this.r, 2);
            Console.WriteLine($"Площадь = {this.s}");
        }
    }

    class Cube : Square
    {
        public Cube(string name, string type, int a) : base(name, type, a)
        {
            if (a <= 0){
                throw new ZeroValueException("Параметр болжен быть больше 0", 0);
            }
        }

        public override void P()
        {
            this.p = Math.Pow(this.a, 3);
            Console.WriteLine($"Объем = {this.p}");
        }

        public void V() => this.P();

        public override void S()
        {
            this.s = Math.Pow(this.a, 2) * 6;
            Console.WriteLine($"Площадь = {this.s}");
        }
    }

    class Ball : Circle
    {
        public Ball(string name, string type, int r) : base(name, type, r)
        {
            if (r <= 0){
                throw new ZeroValueException("Параметр болжен быть больше 0", 0);
            }
        }

        public override void P()
        {
            this.p = 4 * Math.PI * Math.Pow(this.r, 3) / 3;
            Console.WriteLine($"Объем = {this.p}");
        }

        public new void V() => this.P();

        public override void S()
        {
            this.s = 4 * Math.PI * Math.Pow(this.r, 2);
            Console.WriteLine($"Площадь = {this.s}");
        }
    }

    class RunFigure
    {
        public static void Run(){
            int n = 5; 
            Figure[] arr = new Figure[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++){
                arr[i] = Get(rand.Next(0, 6));
            }

            double maxS = 0;
            foreach(Figure obj in arr){
                if (obj.Sq >= maxS){
                    maxS = obj.Sq;
                }
            }
            Console.WriteLine("\nФигуры с самой большой площадью:");
            using(StreamWriter sw = new StreamWriter("Figures.txt", true)){
                sw.WriteLine("Фигуры с самой большой площадью:");
                foreach(Figure obj in arr)
                {
                    if (obj.Sq == maxS){
                        Console.WriteLine($"{obj.name}: {obj.Sq}");
                        sw.WriteLine($"{obj.name}: {obj.Sq}");
                    }
                }
            }
        }

        public static Figure Get(int n){
            string[] nameList = {"Square", "Rectangle", "Triangle", "Circle", "Cube", "Ball"};
            string[] type = {"2d", "3d"};
            string name;
            // string type;
            Random rand = new Random();
            if (n == 0){
                int a = rand.Next(1, 10);
                name = nameList[n] + n.ToString();
                return new Square(name, type[0], a);
            } else if (n == 1){
                int a = rand.Next(1, 10);
                int b = rand.Next(1, 10);
                name = nameList[n] + n.ToString();
                return new Rectangle(name, type[0], a, b);
            } else if (n == 2){
                int a = rand.Next(1, 10);
                int b = rand.Next(1, 10);
                int c = rand.Next(1, 10);
                name = nameList[n] + n.ToString();
                return new Triangle(name, type[0], a, b, c);
            } else if (n == 3){
                int r = rand.Next(1, 10);
                name = nameList[n] + n.ToString();
                return new Circle(name, type[0], r);
            } else if (n == 4){
                int a = rand.Next(1, 10);
                name = nameList[n] + n.ToString();
                return new Cube(name, type[0], a);
            } else if (n == 5){
                int a = rand.Next(1, 10);
                name = nameList[n] + n.ToString();
                return new Cube(name, type[0], a);
            } else if (n == 6){
                int r = rand.Next(1, 10);
                name = nameList[n] + n.ToString();
                return new Ball(name, type[0], r);
            }
            int r1 = rand.Next(1, 10);
            name = nameList[n] + n.ToString();
            return new Ball(name, type[0], r1);

        }
    }

    class MyException: Exception{
    public int code;
    public MyException(string message, int code) : base(message)
        {
          this.code = code;
        }
    }

    class ZeroValueException: Exception{
    public int code;
    public ZeroValueException(string message, int code) : base(message)
        {
          this.code = code;
        }
    }

}