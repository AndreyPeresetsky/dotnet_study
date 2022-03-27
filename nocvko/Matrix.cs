using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dotnet_study.nocvko
{
    public class RunMatrix
    {
        public static void Run(){
            // int[,] m2 = {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}};
            // int[,] m2 = {{1, 2, 3}};
            // Console.WriteLine(m2[0,2]);
            int[,] m1 = {{1, 2, 3}};
            int[,] m3 = {{1, 2, 3}, {4, 5, 6}, {7, 8, 2}};
            // Console.WriteLine(m3[0,2]);
            // int[,] m2 = {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}};
            int[,] m2 = {{1}, {4}, {7}};
            // int[,] m1 = {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}};
            // Console.WriteLine(m2.GetLength(0)); // 0 - колво строк, 1 - столбцов 

            Console.WriteLine("Матрица 1 \n");
            Matrix matrix1 = new Matrix(m1);
            matrix1.ShowMatrix();
            Console.WriteLine("\nМатрица 2 \n");
            Matrix matrix2 = new Matrix(m2);
            matrix2.ShowMatrix();
            Console.WriteLine("\nМатрица 3 и 4 \n");
            Matrix matrix3 = new Matrix(m3);
            Matrix matrix4 = new Matrix(m3);
            matrix3.ShowMatrix();

            try{
                Console.WriteLine("\nСумма матриц 3 и 4: \n");
                Matrix matrix5 = matrix3 + matrix4;
                matrix5.ShowMatrix();
            } catch (Exception ex){
                Console.WriteLine(ex.Message);
            }

            try{
            Console.WriteLine("\nВычитание матрицы 3 из 4 : \n");
            Matrix matrix6 = matrix3 - matrix4;
            matrix6.ShowMatrix();
            } catch (Exception ex){
                Console.WriteLine(ex.Message);
            }

            try{
                Console.WriteLine("\nУмножение матрицы 1 на 2: \n");
                Matrix matrix7 = matrix1 * matrix2;
                matrix7.ShowMatrix();
            } catch (Exception ex){
                Console.WriteLine(ex.Message);
            }

            try{
                Console.WriteLine("\nУмножение матрицы 2 на 1: \n");
                Matrix matrix7 = matrix2 * matrix1;
                matrix7.ShowMatrix();
            } catch (Exception ex){
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nРавенство: \n" );
            int[,] m10 = {{1, 2, 3}, {4, 5, 6}, {7, 8, 2}};
            int[,] m11 = {{1, 2, 3}, {4, 5, 6}, {1, 1, 1}};
            Matrix matrix10 = new Matrix(m10);
            Matrix matrix10_1 = new Matrix(m10);
            Matrix matrix11 = new Matrix(m11);
            Console.WriteLine(matrix10 == matrix10_1);
            Console.WriteLine(matrix10 != matrix10_1);

            Console.WriteLine("\nНеравенство: \n" );
            Console.WriteLine(matrix10 == matrix11);
            Console.WriteLine(matrix10 != matrix11);

            Console.WriteLine("\nТранспонирование матрицы 1");
            matrix1.Transposition();
            matrix1.ShowMatrix();

            Console.WriteLine("\nТранспонирование матрицы 2");
            matrix2.Transposition();
            matrix2.ShowMatrix();

            Console.WriteLine("\nТранспонирование матрицы 3");
            matrix3.Transposition();
            matrix3.ShowMatrix();
        }
    }
    public class Matrix
    {
        private int[,] matrix;
        private int stringLength;
        private int columnHeight;
        Random rand = new Random();

        public Matrix(){
            this.columnHeight = this.rand.Next(1, 5);
            this.stringLength = this.rand.Next(1, 5);
            Console.WriteLine($"The matrix is generated. \nstring length = {this.stringLength} \nColumn height = {this.columnHeight}");
            this.matrix = this.GeneratMatrix(this.columnHeight, this.stringLength, 0, 10);
            // this.ShowMatrix();
        }

        public Matrix(int columnHeight, int stringLength, int minValue, int maxValue){
            Console.WriteLine($"The matrix is generated.");
            this.matrix = this.GeneratMatrix(columnHeight, stringLength, minValue, maxValue);
            // this.ShowMatrix();
        }

        public Matrix(int[,] matrix){
            this.matrix = matrix;
            this.stringLength = matrix.GetLength(1);
            this.columnHeight = matrix.GetLength(0);
        }
        
        public int[,] GeneratMatrix(int columnHeight, int stringLength, int minValue, int maxValue){
            this.columnHeight = columnHeight;
            this.stringLength = stringLength;
            int[,] matrix = new int[this.columnHeight, this.stringLength];
            for (int i = 0; i < this.columnHeight; i++){
                for (int j = 0; j < this.stringLength; j++){
                    matrix[i, j] = this.rand.Next(minValue, maxValue);
                }
            }
            return matrix;
        }

        public void ShowMatrix(){
            for (int i = 0; i < this.columnHeight; i++){
                for (int j = 0; j < this.stringLength; j++){
                    Console.Write(this.matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public int this[int i, int j]{
            get{
                if (i >= 0 && i < this.columnHeight && j >= 0 && j < this.stringLength){
                    return this.matrix[i, j];
                } else {
                    throw new Exception($"Неверный индекс i = {i}, j = {j}, {this.stringLength}, {this.columnHeight}");
                }
            }
            set{
                if (i >= 0 && i < this.stringLength && j >= 0 && j < this.columnHeight){
                    matrix[i, j] = value;
                    Console.Write(matrix[i, j]);
                }
                else
                {
                    Console.WriteLine("Wrong index");
                }
            }
        }

        public void Transposition(){
            int[,] transp = new int[this.stringLength, this.columnHeight];
            for (int i = 0; i < this.stringLength; i++)
            {
                for (int j = 0; j < this.columnHeight; j++)
                    transp[i, j]=this.matrix[j, i];
            }
            
            int new_stringLength = this.columnHeight;
            int new_columnHeight = this.stringLength;

            this.columnHeight = new_columnHeight;
            this.stringLength = new_stringLength;

            this.matrix = transp;
        }

        public static Matrix operator + (Matrix m1, Matrix m2){
            if(m1.columnHeight != m2.columnHeight && m1.stringLength != m2.stringLength) throw new Exception("Матрицы нельзя складывать");
            int[,] matrix3 = new int[m1.columnHeight, m1.stringLength];
            for (int i = 0; i < m1.columnHeight; i++){
                for (int j = 0; j < m1.stringLength; j++){
                    matrix3[i, j] = m1[i, j] + m2[i, j];
                }
            }
            return new Matrix(matrix3);
        }

        public static Matrix operator - (Matrix m1, Matrix m2){
            if(m1.columnHeight != m2.columnHeight && m1.stringLength != m2.stringLength) throw new Exception("Матрицы нельзя вычитать");
            int[,] matrix3 = new int[m1.columnHeight, m1.stringLength];
            for (int i = 0; i < m1.columnHeight; i++){
                for (int j = 0; j < m1.stringLength; j++){
                    matrix3[i, j] = m1[i, j] - m2[i, j];
                }
            }
            return new Matrix(matrix3);
        }

        public static bool operator == (Matrix m1, Matrix m2){
            if(m1.columnHeight != m2.columnHeight){
                return false;
            }
            if(m1.stringLength != m2.stringLength){
                return false;
            }
            for (int i = 0; i < m1.columnHeight; i++){
                for (int j = 0; j < m1.stringLength; j++){
                    if (m1[i, j] != m2[i, j]){
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool operator != (Matrix m1, Matrix m2){
            if(m1.columnHeight != m2.columnHeight){
                return true;
            }
            if(m1.stringLength != m2.stringLength){
                return true;
            }
            for (int i = 0; i < m1.columnHeight; i++){
                for (int j = 0; j < m1.stringLength; j++){
                    if (m1[i, j] != m2[i, j]){
                        return true;
                    }
                }
            }
            return false;
        }
        
        public static Matrix operator * (Matrix m1, Matrix m2){
            if (m1.matrix.GetLength(1) != m2.matrix.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
            int[,] matrix3 = new int[m1.matrix.GetLength(0), m2.matrix.GetLength(1)];
            for (int i = 0; i < m1.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < m2.matrix.GetLength(1); j++)
                {
                    for (int k = 0; k < m2.matrix.GetLength(0); k++)
                    {
                        // Console.Write($"m1[{i},{k}] = ");
                        // Console.WriteLine($"{m1[i,k]}");
                        // Console.Write($"m2[{k},{j}] = ");
                        // Console.WriteLine($"{m2[k,j]}");
                        matrix3[i,j] += m1[i,k] * m2[k,j];
                        // Console.WriteLine($"matrix3[{i},{j}] = {matrix3[i,j]}");
                    }
                }
            }            
            return new Matrix(matrix3);
        }
	}
}
