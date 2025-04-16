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
                    + "\n5. Rekursiv Even"
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
                        TestRecursivEven();
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
                string value="";
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
                    case '+': theList.Add(value);       
                        break;
                    case '-': theList.Remove(value);  
                        break;
                    case '0': finished = true;          
                        break;
                    default : Console.WriteLine("Enter some input, start the text with +/- exit with 0"); 
                        break;
                }

                Console.WriteLine($"Stored elements: {theList.Count} capacity: {theList.Capacity} ");

            } while (!finished);
            Console.Clear ();
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
                        if(theQueue.Count > 0)
                            Console.WriteLine (theQueue.Dequeue() );
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


                if(input.Equals("0"))
                    finished = true;
                else
                {
                    foreach (char tkn in input)
                    {
                        theStack.Push(tkn);
                        //Console.WriteLine($"Stored elements: {theList.Count} capacity: {theList.ToArray().Length} ");

                    }
                    StringBuilder reverse = new StringBuilder();
                    while(theStack.Count > 0)
                    {
                        reverse.Append(theStack.Pop() );
                        //Console.WriteLine($"Stored elements: {theList.Count} capacity: {theList.ToArray().Length} ");
                    };

                    Console.WriteLine("Reversed: "+ reverse.ToString() );

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




        private static void TestRecursivEven()
        {
            Console.Clear();
            int q = RecursiveEven(3);
            Console.WriteLine("-------------------------------------");
            int w = Fibonacci(13);
            Console.ReadLine();
            Console.Clear();
        }

        //0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144
        static int Fibonacci(int n)
        {
            if (n == 1)
            {
                Console.WriteLine($"Arg: {n} returns 0");
                return 0;
            }

            if (n == 2)
            {
                Console.WriteLine($"Arg: {n} returns 1");
                return 1;
            }


            int temp = (Fibonacci(n - 1) + Fibonacci(n - 2));
            Console.WriteLine($"Arg: {n} returns {temp}");
            return temp;

            //return (Fibonacci(n - 1) + Fibonacci(n - 2));
        }

        static int RecursiveEven(int n)
        {
            if (n == 1)
            {
                Console.WriteLine($"Arg: {n} returns {2}");
                return 2;
            }

            int temp = (RecursiveEven(n - 1) + 2);
            Console.WriteLine($"Arg: {n} returns {temp}");
            return temp;

            //return (RecursiveEven(n - 1) + 2);
        }



    }
}

