using System;
using System.Collections.Generic;
using System.Globalization;

namespace TestApp
{
    class Program
    {
        //Global variables
        static int beforeGermCount;
        static int afterGermCount;
        static float chemTime;
        static double rateCount, rateCount2, rateCount3, rateCount4, rateCount5;

        static List<string> chemList = new List<string>() { "Propane", "Hypochlorite", "Peracetic Acid", "Chlorine Dioxide", "Hydrogen Peroxide", "Iodophor Disinfectant" };

        static List<int> chosenChemIndex = new List<int>();
        static List<float> chemListRating = new List<float>();



        //Check the users choice (self or random)
        static string checkUserChoice()
        {
            while (true)
            {
                Console.WriteLine("\nType 'self' if you would like to enter the amount of live germs, or\n" +
                "type 'random' if you want the computer to randomly generate the number of live germs\n");

                string countChoice = Console.ReadLine();

                if (countChoice.Equals("self") || countChoice.Equals("random"))
                {
                    return countChoice;
                }
                else
                {
                    Console.WriteLine("Error: Enter a valid value\n");
                }
            }
        }

        //Check the users input (beforegermcount)
        static int checkBeforeGC(string questionBGC, int minBGC, int maxBGC)
        {
            string ErrorMSGBGC = $"Error: Enter a number between {minBGC} and {maxBGC}";
            while (true)
            {
                try
                {
                    Console.WriteLine(questionBGC);

                    beforeGermCount = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);

                    if (beforeGermCount > 249 && beforeGermCount < 501)
                    {
                        return beforeGermCount;
                    }
                    else
                    {
                        Console.WriteLine(ErrorMSGBGC);
                    }
                }
                catch
                {
                    Console.WriteLine(ErrorMSGBGC);
                }
            }
        }

        //Check user input (chemtime)
        static float checkChemTime(string questionCT, int minCT, int maxCT)
        {
            string ErrorMSGCT = $"Error: Enter a number between {minCT} and {maxCT}";
            while (true)
            {
                try
                {
                    Console.WriteLine(questionCT);

                    float chemTime = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);

                    if (chemTime > 0 && chemTime < 61)
                    {
                        return chemTime;
                    }
                    else
                    {
                        Console.WriteLine(ErrorMSGCT);
                    }
                }
                catch
                {
                    Console.WriteLine(ErrorMSGCT);
                }
            }
        }

        //Check user input (aftergermcount)
        static int checkAfterGC(string questionAGC, int minAGC, int maxAGC)
        {
            string ErrorMSGAGC = $"Error: Enter a number between {minAGC} and {maxAGC}";
            while (true)
            {
                try
                {
                    Console.WriteLine(questionAGC);

                    int afterGermCount = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);

                    if (afterGermCount > minAGC && afterGermCount < maxAGC)
                    {
                        return afterGermCount;
                    }
                    else
                    {
                        Console.WriteLine(ErrorMSGAGC);
                    }
                }
                catch
                {
                    Console.WriteLine(ErrorMSGAGC);
                }
            }
        }

        static int checkChemChoice(string question, int min, int max)
        {
            string ErrorMSG = $"Error: Enter a number between {min} and {max}";
            while (true)
            {
                try
                {
                    Console.WriteLine(question);

                    int chemNameIndex = Convert.ToInt32(Console.ReadLine());

                    if (chosenChemIndex.Contains(chemNameIndex - 1))
                    {
                        Console.WriteLine("Error: You can't enter the same value more than once\n");
                    }
                    else
                    {
                        if (chemNameIndex >= min && chemNameIndex <= max)
                        {
                            return chemNameIndex - 1;
                        }
                        else
                        {
                            Console.WriteLine(ErrorMSG);
                        }
                    }
   
                }
                catch
                {
                    Console.WriteLine(ErrorMSG);
                }
            }
        }

        //Sorted List
        static void sortChem()
        {
            Console.WriteLine("Unordered List\n" +
                "--------------");
            foreach (int name in chosenChemIndex)
            {
                Console.WriteLine(name + $"= {chemListRating[chosenChemIndex.IndexOf(name)]}");
            }

            for (int leftPointer = 0; leftPointer < chemListRating.Count - 1; leftPointer++)
            {
                for (int rightPointer = leftPointer + 1; rightPointer < chemListRating.Count; rightPointer++)
                {
                    if (chemListRating[leftPointer] < chemListRating[rightPointer])
                    {
                        float orderRating = chemListRating[leftPointer];
                        chemListRating[leftPointer] = chemListRating[rightPointer];
                        chemListRating[rightPointer] = orderRating;

                        int orderName = chosenChemIndex[leftPointer];
                        chosenChemIndex[leftPointer] = chosenChemIndex[rightPointer];
                        chosenChemIndex[rightPointer] = orderName;
                    }
                }
            }

            Console.WriteLine("\n\nHighest Chemical Rating to Lowest\n" +
                "---------------------------------");

            for (int chemIndex = 0; chemIndex < chemListRating.Count; chemIndex++)
            
            {
                Console.WriteLine($"{chemIndex + 1}. "+chemList[chosenChemIndex[chemIndex]] + $" = {chemListRating[chemIndex]}");
            }
        }

        static void Main(string[] args)
        {
            //Welcome message
            Console.WriteLine("Welcome to Chemical App where we test chemicals to calculate an efficiency rating.                    |\n" +
                "                                                                                                      |\n" +
                "For this app, you are required either let the computer randomly generate an amount of germs,          |\n" +
                "or you can put together your own amount. Then you will need to time how long you put the chemical     |\n" +
                "in with the germs, and finally, record how many germs are left.                                       |\n" +
                "______________________________________________________________________________________________________|\n");
            //Ask user to continue or quit
            //Check the users response
            bool flag1 = true;
            while (flag1)
            {
                Console.WriteLine("Press <Enter> to continue with the program or type 'quit' to end the program");
                string checkChoice = Console.ReadLine();
                if (checkChoice.Equals(""))
                {
                    Console.WriteLine("You are using Chemical App\n\n");
                    chemApp();
                }
                else if (checkChoice.Equals("quit"))
                {
                    Console.WriteLine("Thanks for using Chemical App\n");
                    sortChem();
                    flag1 = false;
                }
                else
                {
                    Console.WriteLine("Error: Enter a valid value\n");
                }
            }
        }

        //Start component 2
        static void chemApp()
        {
            //Create list of chemical products
            string menu = "Type the number of the chemical you will be using from this list:\n\n";
            for (int chemNum = 0; chemNum < chemList.Count; chemNum++)
            {
                menu += $"{chemNum + 1}. {chemList[chemNum]}\n";
            }

            //Entering the chemical name
            chosenChemIndex.Add(checkChemChoice(menu, 1, 6));

            string userChoice = checkUserChoice();

            //Loop 5 times
            for (int testNum = 1; testNum < 6; testNum++)
            {
                if (userChoice.Equals("self"))
                {
                    //Test number
                    Console.WriteLine($"Test {testNum}");

                    checkBeforeGC("Enter the amount of live germs present\n", 249, 501);

                    checkChemTime("Enter how long the germs have been in the chemicals (minutes)\n", 0, 61);

                    checkAfterGC("How many live germs are left\n", -1, 251);

                    //Calculate the efficiency rating
                    double chemRating = (beforeGermCount - afterGermCount) / chemTime;

                    //Rounding Rating to 3dp
                    chemRating = Math.Round(chemRating, 3);

                    Console.WriteLine($"\nThe Efficiency Rating of {chemList[chosenChemIndex[chosenChemIndex.Count - 1]]} is {chemRating}\n");

                    if (testNum == 1)
                    {
                        rateCount = chemRating;
                    }
                    if (testNum == 2)
                    {
                        rateCount2 = chemRating;
                    }
                    if (testNum == 3)
                    {
                        rateCount3 = chemRating;
                    }
                    if (testNum == 4)
                    {
                        rateCount4 = chemRating;
                    }
                    if (testNum == 5)
                    {
                        rateCount5 = chemRating;
                    }
                }
                else if (userChoice.Equals("random"))
                {
                    //Test number
                    Console.WriteLine($"\nTest {testNum}\n");

                    //Generate random number of germs before
                    Random rand_germ = new Random();

                    beforeGermCount = rand_germ.Next(500, 1000);
                    beforeGermCount = rand_germ.Next(250, 500);
                    Console.WriteLine($"The amount of alive germs is: {beforeGermCount}\n");

                    //Generate random time
                    Random rand_time = new Random();
                    chemTime = rand_time.Next(1, 60);
                    Console.WriteLine($"The time the chemical was mixed with the germs is: { chemTime}\n");

                    //Generate random number of germs after
                    Random rand_germ2 = new Random();
                    afterGermCount = rand_germ2.Next(1, 499);
                    afterGermCount = rand_germ2.Next(0, 250);
                    Console.WriteLine($"The amount of alive germs after adding the chemical is: {afterGermCount}");

                    //Calculate the efficiency rating
                    double chemRating = (beforeGermCount - afterGermCount) / chemTime;
                    //Rounding Rating to 3dp

                    chemRating = Math.Round(chemRating, 3);

                    Console.WriteLine($"The Efficiency Rating of {chemList[chosenChemIndex[chosenChemIndex.Count - 1]]} is {chemRating}\n\n");

                    if (testNum == 1)
                    {
                        rateCount = chemRating;
                    }
                    if (testNum == 2)
                    {
                        rateCount2 = chemRating;
                    }
                    if (testNum == 3)
                    {
                        rateCount3 = chemRating;
                    }
                    if (testNum == 4)
                    {
                        rateCount4 = chemRating;
                    }
                    if (testNum == 5)
                    {
                        rateCount5 = chemRating;
                    }
                }
            }
            //Calculating the final rating 
            double testAvg = rateCount + rateCount2 + rateCount3 + rateCount4 + rateCount5;
            double finalRating = testAvg / 5;

            chemListRating.Add((float)Math.Round(finalRating, 3));

            Console.WriteLine($"{chemList[chosenChemIndex[chosenChemIndex.Count - 1]]} has a Final Efficiency Rating of {chemListRating[chemListRating.Count - 1]}\n");
        }
    }
}
