using Microsoft.VisualBasic;
using System.Diagnostics;
using static Database;

namespace Keoski_Project {
    internal class Program {
        static void Main(string[] args) {

            //DateTimeText();
            //funciotn being call
            //varalbes


            Intro();
            //Variables
            Database Kiosk = new Database();
            var now = DateTime.Now;
            Random rnd = new Random();
            int transNum = rnd.Next(100000, 999999);
            double total = 0;
            double value = 0;
            bool CashorCard = true;
            List<double> list = new List<double>();
            Kiosk.Line2();
                for (int i = 1; i > 0; i++) { 
                    //ask the user how much there item is
                    Console.Write($"\tItem {i}: "); value = PromptDoulbeTry("$");
                    list.Add(value);
                    if (value == 0) {
                        //Display Total 
                        Kiosk.Line(); total = Math.Round(total, 2); Console.Write($"\tTotal - "); ColorText($"{total:C}", ConsoleColor.Green); Kiosk.Line2();
                        //cash or card payment
                        while (CashorCard == true) {
                            string CC = Prompt("    Pay (cash/card) - ");
                            if (CC == "cash") { Kiosk.Cash(total, Kiosk.ChangeGivin); CashorCard = false; }//end if 
                            else if (CC == "card") { Kiosk.Card(total, Kiosk.ChangeGivin); CashorCard = false; }//end else if
                            else { Kiosk.Invalid() ;}//end else
                        }//end while
                        i = -1;
                    }//end if value = 0
                    else if(value >= 0.01 && value <= 1000.99) { total += value; }//end else if value > 0.01 and < 1000.99
                    else { Kiosk.Invalid(); }//end else
                }//end For
            
                //starts the log files and stores all the inportant info in the program
                //is like a receipt
            ProcessStartInfo PSI = new ProcessStartInfo();
            PSI.FileName = @"C:\Users\MCA-9\Documents\GitHub\FileLog\bin\Debug\net8.0\FileLog.exe";
            PSI.Arguments = $"{now.ToString("hhmmssffff")}{transNum} {now.Date.ToString("MM-dd-yyyy")} {now.ToString("hh:mm:sstt")} {list.Count-1} {total} {Kiosk.Paying} {Kiosk.CardType} {Kiosk.AccountNumber} {Kiosk.ChangeGivin}";
            Process.Start(PSI);


            //SPACE
            space(4);

        }//end main


        //Intro
        static void Intro() {
            ColorText("This is a program that you can use to input the cost of your items", ConsoleColor.Red);
            ColorText("\nBelow you will input the value of each of those items", ConsoleColor.Red);
            ColorText("\nIf you are done inputing your items type 0", ConsoleColor.Red);
            space(2);
        }//end Fucnitn Intro

        

        static object DateTimeText() {
            var now = DateTime.Now;
           // var no = DateOnly.FromDateTime(now);
            Console.WriteLine(now.Date.ToString("MM-dd-yyyy"));
            Console.WriteLine(now.ToString("hh:mm:ss:ff"));
            //test
            Console.WriteLine(now);
            //retrun 
            return now;
        }//end Function Date Time

        

        static void space(int num) {
            for (int i = 0; i < num; i++) {
                Console.WriteLine();
            }//end for 
        }//end fucntion


        #region ColorFullMonths
        static void RainFallColorfulDays() {
            //variables
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            ConsoleColor[] colors = { ConsoleColor.Blue, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.White, ConsoleColor.DarkCyan, ConsoleColor.DarkRed, ConsoleColor.DarkGray, ConsoleColor.Yellow, ConsoleColor.Magenta, ConsoleColor.DarkYellow, ConsoleColor.DarkGreen };
            double[] monthlyRain;
            double avgRainfall = 0;
            double totalRain = 0;
            int years = 0;
            int t = 0;
            //input
            years = PromptInt("How many years will we be tracking rainfall?: ");
            Console.WriteLine();
            monthlyRain = new double[years * 12];
            ///for
            for (int y = 0; y < years; y++) {
                for (int m = 0; m < 12; m++) {
                    //input
                    monthlyRain[t] = ColorTextDouble($"What was rain in month {months[m]}: ", colors[m]);
                    totalRain += monthlyRain[t++];
                    Console.WriteLine();
                }//end month for loop
            }//end  year for loop
            avgRainfall = totalRain / (years * 12);
            Console.WriteLine($"The average monthly rainfall for {years} years was {avgRainfall}\nTotal Rain Fall {totalRain}");
        }//end fucnton

        #endregion



        #region COLOR TEXT, INT, DOUBLE 

        static string ColorText(string message, ConsoleColor color) {
            string value = "";
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
            //return
            return value;
        }//end funciton


        static int ColorTextInt(string messege, ConsoleColor color) {
            int value = 0;
            Console.ForegroundColor = color;
            Console.Write(messege);
            Console.ResetColor();
            value = int.Parse(Console.ReadLine());
            //return
            return value;

        }//end funciton


        static double ColorTextDouble(string messege, ConsoleColor color) {
            double value = 0.0;
            Console.ForegroundColor = color;
            Console.Write(messege);
            Console.ResetColor();
            value = double.Parse(Console.ReadLine());
            //return
            return value;
        }//end funciton

        #endregion



        #region COLORFUL DAYS
        static void ColorfulDays() {
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            ConsoleColor[] colors = { ConsoleColor.Blue, ConsoleColor.DarkYellow, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Magenta, ConsoleColor.Cyan, ConsoleColor.White };
            //for loop output
            for (int i = 0; i < days.Length; i++) {
                ColorText(days[i], colors[i]);
            }//end for
            #region USLESS TEXT
            /*
            //ouput like for but expanded
            ColorText(days[0], colors[0]);
            ColorText(days[1], colors[1]);
            ColorText(days[2], colors[2]);
            ColorText(days[3], colors[3]);
            ColorText(days[4], colors[4]);
            ColorText(days[5], colors[5]);
            ColorText(days[6], colors[6]);
            */
            /*
            //output but all writen out for show
            Console.Write("In my mind, ");
            ColorText(days[0], ConsoleColor.Blue, false);
            Console.WriteLine(" is always blue.");
            ColorText($"{days[1]} are brown for Taco {days[1]}s", ConsoleColor.DarkYellow);
            ColorText($"Red is the color of {days[2]}", ConsoleColor.Red);
            ColorText($"And {days[3]} is definitely green!", ConsoleColor.Green);
            ColorText($"{days[4]} is the last day of the work-week, so it's purple", ConsoleColor.Magenta);
            Console.BackgroundColor = ConsoleColor.White;
            ColorText($" And {days[5]}s are black", ConsoleColor.Black);
            Console.BackgroundColor = ConsoleColor.Black;
            ColorText($"Finally, {days[6]} are while because fuck you, I said so." , ConsoleColor.White);
            */
            #endregion
        }//end funciton
        #endregion



        #region TRY FUNCITON 
        // biging funciton int try
        static int PromptIntTry(string dataRequest) {

            //variabels
            int userInput = 0;
            bool isValid = false;
            //do while loop
            do {
                Console.Write(dataRequest);
                isValid = int.TryParse(Console.ReadLine(), out userInput);
            } while (isValid == false);
            //retun
            return userInput;
        }// end funtion int




        // biging funciton dulbe try
        static double PromptDoulbeTry(string dataRequest) {

            //variabels
            double userInput = 0;
            bool isValid = false;
            //do while loop
            do {
                Console.Write(dataRequest);
                isValid = double.TryParse(Console.ReadLine(), out userInput);
            } while (isValid == false);
            //retun
            return userInput;
        }// end funtion doulbe tyr
        #endregion  



        #region PROMPT FUNCTIONS

        //begin funstion string
        static string Prompt(string dataRequest) {

            //variables
            string userInput = "";

            //request information from user
            Console.Write(dataRequest);

            //recive respones
            userInput = Console.ReadLine().ToLower();

            //return
            return userInput;

        }//end funtion

        static string PromptChar(string dataRequest) {

            //variables
            string userInput = "";

            //request information from user
            Console.Write(dataRequest);

            //recive respones
            userInput = Console.ReadLine().ToUpper();

            //return
            return userInput;

        }//end funtion


        // biging funciton int
        static int PromptInt(string dataRequest) {

            //variabels
            int userInput = 0;

            //input
            userInput = int.Parse(Prompt(dataRequest));

            //return
            return userInput;

        }// end funtion int




        //regin funtion double
        static double PromptDouble(string dataRequest) {
            //color
            Console.ForegroundColor = ConsoleColor.Green;

            //variables 
            double userInput = 0.0;

            //input
            userInput = double.Parse(Prompt(dataRequest));

            //rester color
            Console.ResetColor();

            //return
            return userInput;
        }// end funciton double 

        #endregion



    }//end class
}//end namespace
