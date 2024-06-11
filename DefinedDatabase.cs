public class Database {
    //0
    //keep track of how many of each donomination of bill and clin the kiok currntly has
    //varables    //value    //How many there are
    int _100 = 2;     //$100          //2       
    int _50  = 1;     //$50           //1
    int _20  = 6;     //$20           //6
    int _10  = 25;    //$10           //25
    int _5   = 9;     //$5            //9
    int _1   = 32;    //$1            //32
    int _025 = 84;    //$0.25         //84
    int _010 = 6;     //$0.10         //6
    int _005 = 104;   //$0.05         //104
    int _001 = 92;    //$0.01         //92
    string _cardName = "N/A";
    string _AcountNum = "N/A";
    double _Paying = 0.00;
    double _ChangeGivin = 0.00;



    //Get and use in the main of program 
    public string AccountNumber { get { return _AcountNum; } }//end account number
    public string CardType { get { return _cardName; } }//end cardtype
    public double Paying { get { return _Paying; } }
    public double ChangeGivin { get {  return _ChangeGivin; } }


    //completed valt method   //how much money in the kiosk
    public double Valt() {
        double total = 0;
        double fulTotal = 0;
        //calclate
        total = _100 * 100;
        fulTotal += total;
        total = _50 * 50;
        fulTotal += total;
        total = _20 * 20;
        fulTotal += total;
        total = _10 * 10;
        fulTotal += total;
        total = _5 * 5;
        fulTotal += total;
        total = _1 * 1;
        fulTotal += total;
        total = _025 * 0.25;
        fulTotal += total;
        total = _010 * 0.10;
        fulTotal += total;
        total = _005 * 0.05;
        fulTotal += total;
        total = _001 * 0.01;
        fulTotal += total;
        //retrun
        return fulTotal;
    }//end valt funtion

    //completed change method   //used to tell the user how much money they get back from the kiosk
    public void ChangeC(double _change) {
        bool EndChange = false;
        bool Cancel = false;
        if (_change > 0) {
            _change = Math.Round(_change, 2);
            Line();
            Console.Write($"       Change - ");
            ColorText($"{_change:C}", ConsoleColor.DarkGreen);
                _ChangeGivin = _change;
            Line2();
        }//end if 
            double _fulTotal = Valt();
        while (_change > 0 && EndChange == false) {
            if (Cancel == true) { _change = 0;  }
            if (_fulTotal >= _change) {
                if (_change >= 100 && _100 > 0) {
                    _change -= 100; _100--;  //$100 
                    Console.Write("    Dispensed - ");
                    ColorText("$100.00\n", ConsoleColor.Green);
                } else if (_change >= 50 && _50 > 0) {
                    _change -= 50; _50--;   //$50
                    Console.Write("    Dispensed - ");
                    ColorText("$50.00\n", ConsoleColor.Green);
                } else if (_change >= 20 && _20 > 0) {
                    _change -= 20; _20--;    //$20
                    Console.Write("    Dispensed - ");
                    ColorText("$20.00\n", ConsoleColor.Green);
                } else if (_change >= 10 && _10 > 0) {
                    _change -= 10; _10--;    //$10
                    Console.Write("    Dispensed - ");
                    ColorText("$10.00\n", ConsoleColor.Green);
                } else if (_change >= 5 && _5 > 0) {
                    _change -= 5; _5--;     //$5
                    Console.Write("    Dispensed - ");
                    ColorText("$5.00\n", ConsoleColor.Green);
                } else if (_change >= 1 && _1 > 0) {
                    _change -= 1; _1--;     //$1
                    Console.Write("    Dispensed - ");
                    ColorText("$1.00\n", ConsoleColor.Green); ;
                } else if (_change >= 0.25 && _025 > 0) {
                    _change -= 0.25; _025--;   //$0.25
                    Console.Write("    Dispensed - ");
                    ColorText("$0.25\n", ConsoleColor.Green);
                } else if (_change >= 0.10 && _010 > 0) {
                    _change -= 0.10; _010--;   //$0.10
                    Console.Write("    Dispensed - ");
                    ColorText("$0.10\n", ConsoleColor.Green);
                } else if (_change >= 0.05 && _005 > 0) {
                    _change -= 0.05; _005--;   //$0.05
                    Console.Write("    Dispensed - ");
                    ColorText("$0.05\n", ConsoleColor.Green);
                } else if (_change >= 0.01 && _001 > 0) {
                    _change -= 0.01; _001--;   //$0.01
                    Console.Write("    Dispensed - ");
                    ColorText("$0.01\n", ConsoleColor.Green);
                }//end if else tree
                else if (_fulTotal < _change) { EndChange = true; }//end esle if
                else {
                    if (_change == 0) { ThanksForPaying(); EndChange = true; } else { return; }
                }//end esle
            }//end if
           else if (_change == 0) { ThanksForPaying(); EndChange = true; }
           else if (_fulTotal < _change) { Cancel = CancelOrCard(_fulTotal, _change);  }
           else { EndChange = true; }
        }//end while
    }//end Function Payment

    //completed cash method
    public double Cash(double _total, double _change) {
        //varables
        //double change = 0;
        double payment = 0;
        double remaning = 0;
        bool usingCard = false;
        Line();
        //insert cash 
            for (int i = 1; i > 0; i++) {
                if (usingCard) { break; }

                Console.Write($"     Payment {i}: ");
                payment = PromptDoulbeTry("$");
                _Paying = payment;
                if (payment == 100 || payment == 50 || payment == 20 || payment == 10 || payment == 5 || payment == 2 || payment == 1 || payment == 0.50 || payment == 0.25 || payment == 0.10 || payment == 0.05 || payment == 0.01) {
                    if (payment == 0 && remaning > 0) { _total = remaning; i = -1; }//end if
                    else if (payment < _total) {
                        remaning = _total - payment;
                        Line(); Console.Write($"     Remaning : ");
                        ColorText($"{remaning:C}", ConsoleColor.Magenta); Line2();
                        _total = remaning;
                        usingCard = AskIfCard(_total, _change);
                    }//end else if 
                    else {
                        _change = payment - _total;
                        i = -1;
                    }//end else
                }//end if payment
                else { Invalid(); }
            }//end For
            ChangeC(_change);
       return _change;
    }//end funiton Cash 

    //completed card method 
    public void Card(double _total, double _change) {
        //varables
        string acountNumber = "";
        string cardType = "";
        bool Card = false;
        int Digits = 0;
        int sum = 0;
        int a = 0;
        bool EndCard = false;
        bool UsingCash = false;
        while (EndCard == false) {
            if (UsingCash) { ThanksForPaying();  break; }
            //part of your card transation 
            Line(); ColorText("    16   **** **** **** **** \n    15   **** ****** *****", ConsoleColor.Magenta);
            Line2(); Digits = PromptIntTry("\t   16 or 15\n      Digits on card?: ");
            Line(); acountNumber = Prompt($"\tCard's number  -\n\t");
            //for loop  luna agarithim
            for (int i = acountNumber.Length - 2; i >= 0; i--) {
                int d = Convert.ToInt32(acountNumber.Substring(i, 1));
                if (a % 2 == 0) {
                    d = d * 2;
                    if (d > 9) { d -= 9; }
                }//end if
                sum += d;
                a++;
            }//end for
             //if for to tell that the card is valid to tell what type of card it is
            if ((10 - (sum % 10)) == Convert.ToInt32(acountNumber.Substring(acountNumber.Length - 1))) {
                Line(); Console.WriteLine("\t     Vallid"); Line();
                _AcountNum = acountNumber;
                string first4String = (acountNumber[0].ToString() + acountNumber[1].ToString() + acountNumber[2].ToString() + acountNumber[3].ToString());
                int acountNum = int.Parse(first4String);
                if (Digits == 16) {
                    if ((acountNum >= 5100 && acountNum <= 5199) || (acountNum >= 5500 && acountNum <= 5599)) {
                        cardType = "\t     Master"; Card = true;
                    }//end if for master card
                    else if (acountNum == 6011 || (acountNum >= 6500 && acountNum <= 6599)) {
                        cardType = "\t    Discover"; Card = true;
                    }//end else if for discover card
                    else if (acountNum >= 4000 && acountNum <= 4999) {
                        cardType = "\t      Visa"; Card = true;
                    }//end else if for american express card
                    else { InvalidCard(); }//end else validation
                }//end if for 16 digits 
                else if (Digits == 15 && ((acountNum >= 3400 && acountNum <= 3499) || (acountNum >= 3700) && acountNum <= 3799)) {
                    cardType = "     AmericanExpress"; Card = true;
                }//end else if for american express card and 15 digits
                else { InvalidCard(); }//end else validation
                if (Card == true) { //will only run if it is an if tryed while but messed up
                    _cardName = cardType;
                    string[] result = MoneyRequest(acountNum.ToString(), _total);
                    Console.WriteLine(cardType);
                    Line();
                    if (result[1] == "declined") { //if card declined
                        Console.WriteLine($"\t    {result[1]}");
                        Line();
                        UsingCash = AskIfCash(_total, _change);
                    } else { //else to make result to a double
                        double number = double.Parse(result[1]);
                        number = Math.Round(number, 2);
                        if (number == _total) {
                            Console.Write($"\tCharged - "); ColorText($"${number}\n", ConsoleColor.Green);
                            _total = _total - number;
                            Console.Write($"      New Total - "); ColorText($"{_total:C}", ConsoleColor.Green);
                            Line2();
                            CashBack(_change);
                            EndCard = true;
                        }//end if for num = total
                        else if (number < _total) {
                            Console.Write($"\tCharged - "); ColorText($"${number}\n", ConsoleColor.Green);
                            _total = _total - number;
                            Console.Write($"      New Total - "); ColorText($"{_total:C}", ConsoleColor.Green);
                            Line2();
                            UsingCash = AskIfCash(_total, _change);
                        }//end else if < total
                        else { UsingCash = AskIfCash(_total, _change); }//end else
                    }//end else and if 
                }//end if
            } else { InvalidCard();  UsingCash = AskIfCash(_total, _change); }//end else 
        }//end while 
    }//end fucniton Card 

    //need Done Just need to find where to put it and how to use it
    static string[] MoneyRequest(string account_number, double amount) {
        Random rnd = new Random();
        //50% chance transaciton passes or fails
        bool pass = rnd.Next(100) < 50;
        //bool pass = false;  //to test if not working 
                            //50% chance that a faled transcation is declned
        bool declined = rnd.Next(100) < 50;
        //if tree
        if (pass) {
            return new string[] { account_number, amount.ToString() };
        } else {
            if (!declined) {
                return new string[] { account_number, (amount / rnd.Next(2, 6)).ToString() };
            } else {
                return new string[] { account_number, "declined" };
            }//end if and esle in the else
        }//end if else for pass or declined
    }//end money request 



    static string ColorText(string message, ConsoleColor color) {
        string value = "";
        Console.ForegroundColor = color;
        Console.Write(message);
        Console.ResetColor();
        //return
        return value;
    }//end funciton
    static void space(int num) {
        for (int i = 0; i < num; i++) {
            Console.WriteLine();
        }//end for 
    }//end fucntion

    #region Cash, Card, CashBack


    //run everytime after you use card and it deline or not charged all to see if you want to change paymentmethod
    public bool AskIfCash(double _total, double _change) {
        bool UseCash = true;
        while (UseCash == true) {
            string YesorNo = PromptChar("Change payment Method (Y/N): ");
            if (YesorNo == "Y") {
                Cash(_total, _change);
                UseCash = false;
                return true;
            } else if (YesorNo == "N") {
               UseCash = false;
                return false;
            } else { Invalid(); }//end if else tree
        }//end while
        return false;
    }//end method 


    //run everytime after you insert cash to see if you want to change paymentmethod
    public bool AskIfCard(double _total, double _change) {
        bool UseCard = true;
        while (UseCard == true) {
            string YesorNo = PromptChar("Change payment Method (Y/N): ");
            if (YesorNo == "Y") {
                Card(_total, _change);
                UseCard = false;
                return true;
            } else if (YesorNo == "N") {
                Line();
                UseCard = false; 
                return false;
            } else { Invalid(); }//end if else tree
        }//end while
        return false;
    }//end method



    public bool CancelOrCard(double _total, double _change) {
        bool UseCard = true;
        Console.WriteLine("  Kiosk does not have enough\n  money to pay you back");
        Line();
        Console.WriteLine("  You can Cancel Transaction\n\tor Try a card");
        Line();
        while (UseCard == true) {
            string CancelorCard = PromptChar("  Cancel (X) or Card (C) : ");
            if (CancelorCard == "C") {
                Card(_total, _change);
                UseCard = false;
                return true;
            } else if (CancelorCard == "X") {
                UseCard = false;
                return true;
            } else { Invalid(); }//end if else tree
        }//end while
        return false;
    }//end method



    //run after card method if the card is valid and charged all ask if they would like cash back
    public void CashBack(double _change) {
        bool CashBack = true;
        while (CashBack == true) {
            string YesorNo = PromptChar("Would you like Cash back (Y/N): ");
            if (YesorNo == "Y") {
                    Line();
                _change = PromptDouble("     How much Cash? - ");
                if (_change == 100 || _change == 50 || _change == 20 || _change == 10 || _change == 5) {
                    ChangeC(_change);
                    break;
                }//end cash back
                else { Invalid(); }
                CashBack = false;
            } else if (YesorNo == "N") {
                ThanksForPaying();
                CashBack = false;
            } else { Invalid(); }//end if else tree
        }//end while
    }//end method

    #endregion
    #region Lines and Invalid function
    public void InvalidCard() {
        Line(); ColorText("\tInvalid input\n   Enter a valid card number", ConsoleColor.Red); Line2();
        //ask the user if they would like to pay with cash

    }//end invalidCard function

    public void Invalid() { Line(); ColorText("\tInvalid input", ConsoleColor.Red); Line2(); }//end fucniton invalid

    public void ThanksForPaying() { Line(); ColorText("     Thank you for paying", ConsoleColor.Cyan); Line2(); }//end function Thanks

    public void Line() { Console.WriteLine("\n-------------------------------\n"); }//end fucniton line
    public void Line2() { Console.WriteLine("\n\n-------------------------------\n"); }//end fucniton line

    #endregion
    #region TRY FUNCITON 

    public int PromptIntTry(string dataRequest) {

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

    public double PromptDoulbeTry(string dataRequest) {

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

    public string Prompt(string dataRequest) {
        //variables
        string userInput = "";
        //request information from user
        Console.Write(dataRequest);
        //recive respones
        userInput = Console.ReadLine().ToLower();
        //return
        return userInput;
    }//end method prompt

    public string PromptChar(string dataRequest) {
        //variables
        string userInput = "";
        //request information from user
        Console.Write(dataRequest);
        //recive respones
        userInput = Console.ReadLine().ToUpper();
        //return
        return userInput;
    }//end method char


    public int PromptInt(string dataRequest) {
        //variabels
        int userInput = 0;
        //input
        userInput = int.Parse(Prompt(dataRequest));
        //return
        return userInput;
    }// end method int


    public double PromptDouble(string dataRequest) {
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
    }// end method double 

    #endregion
}//end Database