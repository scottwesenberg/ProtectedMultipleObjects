using System;


namespace Inheritance
{
    //Base Class
    class Pokemon
    {
        protected int _Id;
        protected string _Name;
        protected string _Type;

        // default constructor
        public Pokemon()
        {
            _Id = 0;
            _Name = string.Empty;
            _Type = string.Empty;
        }
        //parameterized constructor
        public Pokemon(int id, string name, string type)
        {
            _Id = id;
            _Name = name;
            _Type = type;
        }
        // Get and Set methods for id, name and type
        public int getID() { return _Id; }
        public string getName() { return _Name; }
        public string getType() { return _Type; }
        public void setID(int id) { _Id = id; }
        public void setName(string name) { _Name = name; }
        public void setType(string type) { _Type = type; }

        public virtual void addChange()
        {
            

            Console.Write("Name of Pokemon=");
            _Name = Console.ReadLine();
            Console.Write("Element Type(s)=");
            _Type = Console.ReadLine();
            Console.Write("ID=");
            _Id= int.Parse(Console.ReadLine());
        }
        public virtual void print()
        {
            Console.WriteLine("********** Pokemon *************");
            Console.WriteLine();
            Console.WriteLine($"        ID: {_Id}");
            Console.WriteLine($"      Name: {_Name} ");
            Console.WriteLine($"      Type: {_Type}");
        }
    }
    class Moves : Pokemon
    {

        protected string _MoveOne;
        protected string _MoveType;

        public Moves()
            : base()
        {
            _MoveOne = string.Empty;
            _MoveType = string.Empty;
        }
        public Moves(int id, string name, string type, string moveOne, string moveType)
            : base(id, name, type)
        {
            _MoveOne = moveOne;
            _MoveType = moveType;
        }
        public void setMoveOne(string moveOne) { _MoveOne = moveOne; }
        public void setMoveType(string moveType) { _MoveType = moveType; }
        public string getMoveType() { return _MoveType; }
        public string getMoveOne() { return _MoveOne; }
        public override void addChange()
        {
            base.addChange();
            Console.Write("Move name=");
            _MoveOne = Console.ReadLine();
            Console.Write("Move type=");
            _MoveType = Console.ReadLine();
        }
        public override void print()
        {
            base.print();
            Console.WriteLine("********** Special Attack *************");
            Console.WriteLine(); 
            Console.WriteLine($"      Move: {_MoveOne}");
            Console.WriteLine($" Move type: {_MoveType}");
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("How many Pokemon do you want to enter?");
            int amtPoke;
            while (!int.TryParse(Console.ReadLine(), out amtPoke))
                Console.WriteLine("Please enter a whole number");
            // array of Pokemon only objects
            Pokemon[] poke = new Pokemon[amtPoke];
            Console.WriteLine("How many Pokemon with Attacks do you want to enter?");
            int amtMoves;
            while (!int.TryParse(Console.ReadLine(), out amtMoves))
                Console.WriteLine("Please enter a whole number");
            // array of Pokemon with Moves objects
            Moves[] mov = new Moves[amtMoves];

            int choice, rec, type;
            int pokeCounter = 0, movCounter = 0;
            choice = Menu();
            while (choice != 4)
            {
                Console.WriteLine("Enter 1 for Attacks or 2 for Pokemon");
                while (!int.TryParse(Console.ReadLine(), out type))
                    Console.WriteLine("1 for Attacks or 2 for Pokemon");
                try
                {
                    switch (choice)
                    {
                        case 1: // Add
                            if (type == 1) //New Move
                            {
                                if (movCounter <= amtMoves)
                                {
                                    mov[movCounter] = new Moves(); // object to array instead of null
                                    mov[movCounter].addChange();
                                    movCounter++;
                                }
                                else
                                    Console.WriteLine("The maximum number of attacks has been added");

                            }
                            else //New Pokemon
                            {
                                if (pokeCounter <= amtPoke)
                                {
                                    poke[pokeCounter] = new Pokemon(); // object to array instead of null
                                    poke[pokeCounter].addChange();
                                    pokeCounter++;
                                }
                                else
                                    Console.WriteLine("Maximum attacks added");
                            }

                            break;
                        case 2: //Change
                            Console.Write("Enter the pokemon record number you want to change: ");
                            while (!int.TryParse(Console.ReadLine(), out rec))
                                Console.Write("Enter the pokemon record number you want to change: ");
                            rec--;
                            if (type == 1) //Move
                            {
                                while (rec > movCounter - 1 || rec < 0)
                                {
                                    Console.Write("Not accepted. Please try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the record number for the move you want to change: ");
                                    rec--;
                                }
                                mov[rec].addChange();
                            }
                            else // Pokemon
                            {
                                while (rec > pokeCounter - 1 || rec < 0)
                                {
                                    Console.Write("Not accepted. Please try again.");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the record number for the pokemon you want to change: ");
                                    rec--;
                                }
                                poke[rec].addChange();
                            }
                            break;
                        case 3: // Print
                            if (type == 1) //Moves
                            {
                                for (int i = 0; i < movCounter; i++)
                                    mov[i].print();
                            }
                            else // Pokemon
                            {
                                for (int i = 0; i < pokeCounter; i++)
                                    poke[i].print();
                            }
                            break;
                        default:
                            Console.WriteLine("Not accepted. Please try again");
                            break;
                    }
                }

                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                choice = Menu();

            }
        }

        private static int Menu()
        {
            Console.WriteLine("Please make a selection from the menu");
            Console.WriteLine("1.) Add  2.) Change  3.) Print  4.) Quit");
            int selection = 0;
            while (selection < 1 || selection > 4)
                while (!int.TryParse(Console.ReadLine(), out selection))
                    Console.WriteLine("1.) Add  2.) Change  3.) Print  4.) Quit");
            return selection;
        }
    }
}
