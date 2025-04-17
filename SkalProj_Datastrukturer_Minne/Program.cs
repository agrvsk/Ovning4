using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Text;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            // Svar på frågor...
            // 1. Se dokument Stack_vs_Heap
            //
            // 2. Value Types är ofta små (primitiver och structs) som lagras på stacken (om de inte deklarerats i en Referece Type!).
            //    Vid metodanrop skapas en kopia i anropad metod.
            //    Reference Types är:  (klasser objekt interface delegater och strängar).
            //    De lagras alltid på heapen. Metoder anropas med en minnesreferens(pekare).
            //    Metoden påverkar därför samma objekt och inte en kopia.
            //
            // 3. Metod 1 instansierar en int (som lagras på stacken) y = x skapar därför en ny kopia (låda)
            //    Metod 2 instansierar en klass (som lagras på heapen) y = x får y att adressera samma objekt som x. 
            //
            //    se fler svar under resp. metod...

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n5. Rekursion vs Iteration"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '5':
                        RekursionvsIteration();
                        break;



                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }


        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */
            List<string> theList = new List<string>();
            bool finished = false;

            Console.Clear();
            Console.WriteLine($"Stored elements: {theList.Count} capacity: {theList.Capacity} ");
            Console.WriteLine("Enter some input, start the text with +/- exit with 0");

            do
            {
                char nav = ' ';
                string value = "";
                try
                {
                    string input = Console.ReadLine();
                    nav = input![0];                //First char
                    value = input.Substring(1);     //The following chars...
                }
                catch (IndexOutOfRangeException)    //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine($"Stored elements: {theList.Count} capacity: {theList.Capacity} ");
                    Console.WriteLine("Enter some input, start the text with +/- exit with 0");
                }

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        break;
                    case '-':
                        theList.Remove(value);
                        break;
                    case '0':
                        finished = true;
                        break;
                    default:
                        Console.WriteLine("Enter some input, start the text with +/- exit with 0");
                        break;
                }

                Console.WriteLine($"Stored elements: {theList.Count} capacity: {theList.Capacity} ");

            } while (!finished);
            Console.Clear();
            /*
            Svar på frågor:
            2. Kapaciteten ökar när Adderat värde inte får plats i den underliggande arrayen. 
            3. Första gången ökas kapaciteten till 4, därefter dubbleras den vid behov. (4,8,16,32...)
            4. Ökningen sker stegvis eftersom det tar tid att skapa om den underliggande arrayen.
            5. Kapaciteten minskar inte då vi tar bort element.
            6. Om vi på förhand vet hur många element som ska hanteras så är en egendefinierad array bättre.
            */

        }



        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Queue<string> theQueue = new();
            bool finished = false;

            Console.Clear();
            Console.WriteLine($"Stored elements: {theQueue.Count} capacity: {theQueue.ToArray().Length} ");
            Console.WriteLine("Enter some input, start the text with +/- exit with 0");

            do
            {
                char nav = ' ';
                string value = "";
                try
                {
                    string input = Console.ReadLine();
                    nav = input![0];                //First char
                    value = input.Substring(1);     //The following chars...
                }
                catch (IndexOutOfRangeException)    //If the input line is empty, we ask the user for some input.
                {
                    Console.Clear();
                    Console.WriteLine($"Stored elements: {theQueue.Count} capacity: {theQueue.ToArray().Length} ");
                    Console.WriteLine("Enter some input, start the text with +/- exit with 0");
                }

                switch (nav)
                {
                    case '+':
                        theQueue.Enqueue(value);
                        break;
                    case '-':
                        if (theQueue.Count > 0)
                            Console.WriteLine(theQueue.Dequeue());
                        break;
                    case '0':
                        finished = true;
                        break;
                    default:
                        Console.WriteLine("Enter some input, start the text with +/- exit with 0");
                        break;
                }

                Console.WriteLine($"Stored elements: {theQueue.Count} capacity: {theQueue.ToArray().Length} ");

            } while (!finished);
            Console.Clear();
            /*
            Svar på frågor:
            1. Se ICA Queue vs ICA Stack
            Kapaciteten ökar med ett för varje Adderat värde. 
            Kapaciteten minskar också för varje element som tas bort (Dequeue).
            men vi kan bara ta bort dem i samma ordning som vi la in dem.
            
            theQueue.Enqueue("Kalle");
            theQueue.Enqueue("Greta");
            theQueue.Dequeue() -> Kalle borta.
            theQueue.Enqueue("Stina");
            theQueue.Dequeue() -> Greta borta.
            theQueue.Enqueue("Olle");

             */
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            Stack<char> theStack = new();
            bool finished = false;
            Console.Clear();

            do
            {
                string input = "";
                do
                {
                    Console.WriteLine("Enter a line to reverse. exit with 0");
                    input = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(input));


                if (input.Equals("0"))
                    finished = true;
                else
                {
                    foreach (char tkn in input)
                    {
                        theStack.Push(tkn);
                        //Console.WriteLine($"Stored elements: {theList.Count} capacity: {theList.ToArray().Length} ");

                    }
                    StringBuilder reverse = new StringBuilder();
                    while (theStack.Count > 0)
                    {
                        reverse.Append(theStack.Pop());
                        //Console.WriteLine($"Stored elements: {theList.Count} capacity: {theList.ToArray().Length} ");
                    }
                    ;

                    Console.WriteLine("Reversed: " + reverse.ToString());

                }




            } while (!finished);
            Console.Clear();

            /*
            Svar på frågor:
            1. Se ICA Queue vs ICA Stack
            Kapaciteten ökar med ett för varje Adderat värde. 
            Kapaciteten minskar också för varje element som tas bort (Pop).
            men vi kan bara ta bort dem i omvänd ordning mot hur vi la in dem.
            Därför lämpar sig inte Stack för ICA-kön.
            */

        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            Stack<char> theStack = new();
            bool finished = false;

            Console.Clear();
            do
            {
                string input = "";
                do
                {
                    Console.WriteLine("Enter a line to check. exit with 0");
                    input = Console.ReadLine();

                } while (string.IsNullOrWhiteSpace(input));


                if (input.Equals("0"))
                    finished = true;
                else
                {
                    try
                    {
                        foreach (char tkn in input)
                        {
                            switch (tkn)
                            {
                                //Starttecknen är fritt fram att använda...
                                case '(':
                                    theStack.Push(tkn);
                                    break;
                                case '[':
                                    theStack.Push(tkn);
                                    break;
                                case '{':
                                    theStack.Push(tkn);
                                    break;

                                //Sluttecken ska matcha rätt starttecken annars kastar vi ett exception.
                                case ')':
                                    if (!'('.Equals(theStack.Pop()))
                                        throw new InvalidOperationException("Expected char: (");
                                    break;
                                case ']':
                                    if (!'['.Equals(theStack.Pop()))
                                        throw new InvalidOperationException("Expected char: [");
                                    break;
                                case '}':
                                    if (!'{'.Equals(theStack.Pop()))
                                        throw new InvalidOperationException("Expected char: {");
                                    break;

                                default: break;
                            }
                        }
                        //Kontrollera att stacken är tom!
                        if (theStack.Count > 0) throw new InvalidOperationException("Det återstår tecken att stänga.");

                        //Kommer vi hit så är strängen välformad:
                        Console.WriteLine("Strängen är välformad");

                    }
                    catch (InvalidOperationException ioe)
                    {
                        Console.WriteLine(ioe.Message);
                        Console.WriteLine("Strängen är INTE välformad");
                    }
                    finally
                    {
                        //Listan måste vara tom när nästa test börjar...
                        theStack.Clear();
                    }

                }

            } while (!finished);
            Console.Clear();

        }

        /*
        Se bild Rekursion vs Iteration.jpg
        Rekursiva metoder kan vara farliga vid stort antal anrop 
        eftersom stacken automatiskt fylls på.
        Det sker inte för iterativa metoder se de verkar vara att föredra.
        */
        private static void RekursionvsIteration()
        {
            bool finished = false;

            do
            {
                string input = "";
                string seed = "";
                int iSeed=0;
                do
                {
                    Console.Clear();
                    Console.WriteLine("1. Recursiv Even.");
                    Console.WriteLine("2. Iterativ Even.");
                    Console.WriteLine("3. Recursiv Fibonacci.");
                    Console.WriteLine("4. Iterativ Fibonacci.");
                    Console.WriteLine("0. Exit.");

                    input = Console.ReadLine();

                    if (string.Compare("0", input) == 0)
                    {
                        finished = true;
                        break;
                    }

                    if (string.Compare("1", input) == 0
                    ||  string.Compare("2", input) == 0
                    ||  string.Compare("3", input) == 0
                    ||  string.Compare("4", input) == 0
                    )
                    {
                        Console.Write("Ange antal anrop/iterationer:");
                        seed = Console.ReadLine(); //Siffra att seeda med!
                        if (!int.TryParse(seed, out iSeed))
                            seed = null;

                    }
                } while (string.IsNullOrWhiteSpace(input)
                      || string.IsNullOrWhiteSpace(seed));

                if (input.Equals("0"))
                {
                    finished = true;
                    break;
                }

                switch (input)
                {
                    case "1":
                        int q = RecursiveEven(iSeed);
                        Console.WriteLine("\nSvar:" + q);
                        Console.WriteLine("-------------------------------------");
                        break;

                    case "2":
                        int x = IterativeEven(iSeed);
                        Console.WriteLine("\nSvar:" + x);
                        Console.WriteLine("-------------------------------------");
                        break;

                    case "3":
                        (int, int) w = RecursivFibonacci(iSeed);
                        Console.WriteLine("\nSvar:" + w.Item1);
                        Console.WriteLine("-------------------------------------");
                        break;

                    case "4":
                        int y = IterativFibonacci(iSeed);
                        Console.WriteLine("\nSvar:" + y);
                        Console.WriteLine("-------------------------------------");
                        break;

                    default:
                        break;
                }

                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();

            } while (!finished);
            
            Console.Clear();
        }

        static int RecursiveEven(int n)
        {
            //Bryter om någon anropar med n<1, vilket aldrig skulle få metoden att vända...
            if (n < 1) return 0;
            if (n == 1)
            {
                Console.Write($"Recursiv even: {2}");
                return 2;
            }

            //Uppdelad på flera rader för att kunna printa ut serien.
            int temp = (RecursiveEven(n - 1) + 2);
            Console.Write($",{temp}");
            return temp;

            //Utan utskrift... 
            //return (RecursiveEven(n - 1) + 2);
        }
        static int IterativeEven(int n)
        {
            int result = 0;
            Console.Write($"Iterativ even: ");
            for (int i = 1; i <= n; i++)
            {
                result += 2;
                if (i > 1)
                    Console.Write($",{result}");
                else
                    Console.Write($" {result}");
            }
            return result;
        }

        static (int, int) RecursivFibonacci(int n)
        {
            //Bryter om någon anropar med negativt n, vilket aldrig skulle få metoden att vända...
            if (n < 2) return (0, 0);
            if (n == 2)
            {
                Console.Write($"Recursiv Fibonacci: 0,1");
                //Metoden initieras med de två första värdena i serien.
                return (1, 0);
            }

            //Returnerade värden summeras. Returnerar sedan de värden som ska summeras i nästa steg. 
            (int, int) temp = RecursivFibonacci(n - 1);
            Console.Write($",{temp.Item1 + temp.Item2}");
            return ((temp.Item1 + temp.Item2), temp.Item1);
            
        }

        static int IterativFibonacci(int n)
        {
            if (n < 2) return 0;
            if (n < 3) return 1;
            Console.Write($"Iterativ Fibonacci: 0,1");

            int result = 0;
            int temp1 = 1;
            int temp2 = 0;

            //De två första elementen är typ seed för serien
            //så den riktiga beräkningen körs då n > 3
            for (int i = 3; i <= n; i++)
            {
                result = temp1 + temp2;
                temp2 = temp1;
                temp1 = result;
                Console.Write($",{result}");
            }
            return result;
        }
    }
}

