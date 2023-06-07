using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Domian.Common
{
    public class Helpers
    {
        
        public int GetDataToINT(string id)
        {
            Int32.TryParse(id, out int ReceiptId);

            bool exitLoop=false;
            while (exitLoop==false)
            {
                
                if (ReceiptId == 0)
                {
                    ChangeColorTextWhenIsError("Data which you write is incorrect, write correct number");
                    id = Console.ReadLine();
                    Int32.TryParse(id, out ReceiptId);
                }
                else if (ReceiptId != 0)
                {
                    exitLoop=true;
                }
            }
            return ReceiptId;
        }

        public double GetDataToDouble(string text)
        {
            double.TryParse(text, out double varDouble);

            bool exitLoop = false;
            while (exitLoop == false)
            {

                if (varDouble == 0)
                {
                    ChangeColorTextWhenIsError("Data which you write is incorrect, write correct number");
                    text = Console.ReadLine();
                    double.TryParse(text, out varDouble);
                }
                else if (varDouble != 0)
                {
                    exitLoop = true;
                }
            }
           

            return varDouble;
        }

        public int ChceckVarIsInBorder(int var, int minVal, int maxVal)
            {
            int correctValue=0;
            bool ValueIsInLimit = false;

            while (ValueIsInLimit == false)
            {
                if ((var <= maxVal) && (var >= minVal))
                {
                    correctValue = var;
                    ValueIsInLimit = true;
                }
                else
                {
                    ChangeColorTextWhenIsError($"Value which you write is wrong. Write value between : {minVal}-{maxVal}");
                    Int32.TryParse(Console.ReadLine(), out var);
                    
                }
            }


            return correctValue;
            }

        public void ChangeColorText (string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ChangeColorTextWhenIsError(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ChangeColorTextWhenGetAcces(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public bool CheckUserWriteExit(string text)
        {
            bool userWriteExit = false;

            if ((text == "Exit") || (text == "exit"))
            {
                userWriteExit = true;
                
            }
            return userWriteExit;
        }


    }
   

    public enum Month
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December,
    }

    
        
}
