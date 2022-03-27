using System;
using System.Diagnostics;

namespace dotnet_study.nocvko
{
    abstract class Chessman{
        protected char[] coordinates = new char[2];
        public string name;

        protected static List<string> listOfObjs = new List<string>(); 

        protected void CheckСoord(char firstCord, char secondCord){
            if (!((int)firstCord >= 49 && (int)firstCord <= 56)){
                throw new Exception("Неверная координата (вне поля)");
            }
            if (!((int)Char.ToUpper(secondCord) >= 65 && (int)Char.ToUpper(secondCord) <= 72)){
                throw new Exception("Неверная координата (вне поля)");
            }
            if (listOfObjs.Contains(firstCord.ToString() + secondCord.ToString())){
                throw new Exception($"Неверная координата (клетка {firstCord.ToString()}{secondCord.ToString()} уже занята)\n");
            }
        }

        public Chessman(string name, char firstCord, char secondCord){
            CheckСoord(firstCord, secondCord);
            listOfObjs.Add(firstCord.ToString() + secondCord.ToString());
            this.coordinates[0] = firstCord;
            this.coordinates[1] = Char.ToUpper(secondCord);
            this.name = name;
        }

        public virtual void Step(char newFirstCord, char newFecondCord){
            CheckСoord(newFirstCord, Char.ToUpper(newFecondCord));
            listOfObjs.Add(newFirstCord.ToString() + Char.ToUpper(newFecondCord).ToString());
            listOfObjs.Remove(this.coordinates[0].ToString() + this.coordinates[1].ToString());
            this.coordinates[0] = newFirstCord;
            this.coordinates[1] = Char.ToUpper(newFecondCord);
        }

        public void Where(){
            Console.WriteLine($"Фигура {this.name} находится на клетке {this.coordinates[0]}{this.coordinates[1]}");
        }
    }
    class Pawn : Chessman
    {
        public Pawn(string name, char firstCord, char secondCord) : base(name, firstCord, secondCord)
        {
        }
        private void CheckPawnStep(char firstCord, char secondCord){
            int fc = (int)((int)coordinates[0] - 49);
            int sc = (int)((int)coordinates[1] - 65);
            int newfc = (int)((int)firstCord - 49);
            int newsc = (int)((int)Char.ToUpper(secondCord) - 65);
            if (!(newfc - fc == 1 && Math.Abs(sc - newsc) == 0)){
                throw new Exception("Пешка так не ходит.");
            }
        }

        public override void Step(char newFirstCord, char newFecondCord)
        {   
            this.CheckPawnStep(newFirstCord, newFecondCord);
            base.Step(newFirstCord, newFecondCord);
            Console.WriteLine($"{this.name} пошла на {this.coordinates[0]}{this.coordinates[1]}.");
        }

    }

    class Rook : Chessman
    {
        public Rook(string name, char firstCord, char secondCord) : base(name, firstCord, secondCord)
        {
        }
        private void CheckRookStep(char firstCord, char secondCord){
            int fc = (int)((int)coordinates[0] - 49);
            int sc = (int)((int)coordinates[1] - 65);
            int newfc = (int)((int)firstCord - 49);
            int newsc = (int)((int)Char.ToUpper(secondCord) - 65);
            if (!((Math.Abs(fc - newfc) > 0 && Math.Abs(sc - newsc) == 0) ^ (Math.Abs(fc - newfc) == 0 && Math.Abs(sc - newsc) > 0))){
                throw new Exception("Ладья так не ходит.");
            }
        }

        public override void Step(char newFirstCord, char newFecondCord)
        {   
            this.CheckRookStep(newFirstCord, newFecondCord);
            base.Step(newFirstCord, newFecondCord);
            Console.WriteLine($"{this.name} пошла на {this.coordinates[0]}{this.coordinates[1]}.");
        }

    }

    class Horse : Chessman
    {
        public Horse(string name, char firstCord, char secondCord) : base(name, firstCord, secondCord)
        {
        }
        private void CheckHorseStep(char firstCord, char secondCord){
            int fc = (int)((int)coordinates[0] - 49);
            int sc = (int)((int)coordinates[1] - 65);
            int newfc = (int)((int)firstCord - 49);
            int newsc = (int)((int)Char.ToUpper(secondCord) - 65);
            if ((Math.Abs(fc - newfc) + Math.Abs(sc - newsc)) != 3){
                throw new Exception("Конь так не ходит.");
            }
        }

        public override void Step(char newFirstCord, char newFecondCord)
        {   
            this.CheckHorseStep(newFirstCord, newFecondCord);
            base.Step(newFirstCord, newFecondCord);
            Console.WriteLine($"{this.name} пошёл на {this.coordinates[0]}{this.coordinates[1]}.");
        }

    }

    class Elephant : Chessman
    {
        public Elephant(string name, char firstCord, char secondCord) : base(name, firstCord, secondCord)
        {
        }
        private void CheckElephantStep(char firstCord, char secondCord){
            int fc = (int)((int)coordinates[0] - 49);
            int sc = (int)((int)coordinates[1] - 65);
            int newfc = (int)((int)firstCord - 49);
            int newsc = (int)((int)Char.ToUpper(secondCord) - 65);
            if (Math.Abs(fc - newfc) != Math.Abs(sc - newsc)){
                throw new Exception("Слон так не ходит.");
            }
        }

        public override void Step(char newFirstCord, char newFecondCord)
        {   
            this.CheckElephantStep(newFirstCord, newFecondCord);
            base.Step(newFirstCord, newFecondCord);
            Console.WriteLine($"{this.name} пошёл на {this.coordinates[0]}{this.coordinates[1]}.");
        }

    }

    class Queen : Chessman
    {
        public Queen(string name, char firstCord, char secondCord) : base(name, firstCord, secondCord)
        {
        }
        private void CheckQueenStep(char firstCord, char secondCord){
            int fc = (int)((int)coordinates[0] - 49);
            int sc = (int)((int)coordinates[1] - 65);
            int newfc = (int)((int)firstCord - 49);
            int newsc = (int)((int)Char.ToUpper(secondCord) - 65);
            if (!((Math.Abs(fc - newfc) == Math.Abs(sc - newsc)) ^ (Math.Abs(fc - newfc) > 0 && Math.Abs(sc - newsc) == 0) ^ (Math.Abs(fc - newfc) == 0 && Math.Abs(sc - newsc) > 0))){
                throw new Exception("Ферзь так не ходит.");
            }
        }

        public override void Step(char newFirstCord, char newFecondCord)
        {   
            this.CheckQueenStep(newFirstCord, newFecondCord);
            base.Step(newFirstCord, newFecondCord);
            Console.WriteLine($"{this.name} пошла на {this.coordinates[0]}{this.coordinates[1]}.");
        }

    }

    class King : Chessman
    {
        public King(string name, char firstCord, char secondCord) : base(name, firstCord, secondCord)
        {
        }
        private void CheckKingStep(char firstCord, char secondCord){
            int fc = (int)((int)coordinates[0] - 49);
            int sc = (int)((int)coordinates[1] - 65);
            int newfc = (int)((int)firstCord - 49);
            int newsc = (int)((int)Char.ToUpper(secondCord) - 65);
            if (!(Math.Abs(fc - newfc) <= 1 && Math.Abs(sc - newsc) <= 1)){
                throw new Exception("Король так не ходит.");
            }
        }

        public override void Step(char newFirstCord, char newFecondCord)
        {   
            this.CheckKingStep(newFirstCord, newFecondCord);
            base.Step(newFirstCord, newFecondCord);
            Console.WriteLine($"{this.name} пошёл на {this.coordinates[0]}{this.coordinates[1]}.");
        }

    }


    public class RunChess
    {
        public static void Run(){
            King king = new King("King", '1', 'A');
            King king2 = new King("King2", '2', 'A');
            king.Where();
            try{
                Console.WriteLine("Проврека №1");
                king.Step('2', 'A');
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }   
            king2.Step('2', 'B');
            king2.Where();
            king.Step('2', 'A');
            king.Where();
            try{
                Console.WriteLine("Проврека №2");
                king.Step('2', 'A');
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            } 

            Pawn pawn = new Pawn("Pawn", '3', 'a');
            pawn.Step('4', 'a');
            pawn.Where();
            try{
                Console.WriteLine("\nПроврека №3");
                pawn.Step('4', 'b');
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            } 
            try{
                Console.WriteLine("\nПроврека №4");
                pawn.Step('3', 'A');
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            Queen queen = new Queen("Queen", '5', 'C');
            queen.Step('7', 'C');
            queen.Step('7', 'F');
            queen.Step('5', 'F');
            queen.Step('7', 'D');
            queen.Step('5', 'B');
            try{
                Console.WriteLine("\nПроврека №5");
                queen.Step('4', 'A');
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
            Elephant elephant = new Elephant("Elephant", '6', 'C');
            elephant.Step('8', 'E');
            try{
                Console.WriteLine("\nПроврека №6");
                elephant.Step('8', 'F');
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
            Horse horse = new Horse("Horse", '6', 'C');
            horse.Step('5', 'E');
            try{
                Console.WriteLine("\nПроврека №7");
                elephant.Step('8', 'F');
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
            Rook rook = new Rook("Rook", '8', 'F');
            rook.Step('1', 'F');
            rook.Step('1', 'H');
            try{
                Console.WriteLine("\nПроврека №8");
                rook.Step('8', 'F');
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}