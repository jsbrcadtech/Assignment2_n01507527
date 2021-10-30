using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Assignment2.Models;

namespace Assignment2.Controllers
{
    public class JController : ApiController
    {
        // **** J3 Attempt - Couldn't finish it properly. **** 

        //Christine, I tried adapting this J3 as you did with those in-class examples as well as what I did for my J1 and J2. 
        //Even with that I wasn't able to figure out how to code the input in a way it could be several ones as the J3 problem suggested.
        // In this problem the input could be several instructions to finally get to school( The rest of the problem I managed to do which was really the opposite way with home as final destination)
        // In other words, even if I tried to pass a few arguments in I wasn't able to code for what the problem is asking for.
        // With my get http requests, the inputs would be limited to the number of arguments I passed in and in this case the inputs could be several different ones.
        // eg: L 1st St, R 2nd St, L 3rd St, R 4th St and so on until finally R/L School/Home. // 
        // Here, I'd probably had to use a POST method where the input requests would be what they call "request BODY"
        // I'm not sure if that'd be correct - Please see what I was reading about body post requests at:https://mixedanalytics.com/knowledge-base/add-body-post-requests/#num3
        // Thank you =)


        /// <summary>
        /// Creates instructions for walking in the opposite direction of the J3 problem's (From school to Home) 
        /// </summary>
        /// <returns> string that shows an array of instructions</returns>
        /// <example>
        /// GET /api/j3 -> 
        ///"Turn RIGHT onto TEST3
        ///Turn RIGHT onto TEST2
        ///Turn LEFT onto TEST1
        ///Turn RIGHT into your HOME."
        /// </example>

        //Problem J3: Returning Home
        [Route("api/j3")]
        [HttpGet]
        public List<string> J3()
        {
            List<Position> positionList = new List<Position>();

            positionList.Add(new Position("L", "Test1"));
            positionList.Add(new Position("R", "Test2"));
            positionList.Add(new Position("L", "Test3"));
            positionList.Add(new Position("L", "School"));

            List<string> returnList = new List<string>();

            string instruction = "";
            for (int i = positionList.Count - 1; i > 0; i--)
            {
                Position position = positionList[i];
                instruction = "Turn";
                if (string.Equals(position.Direction, "L"))
                {
                    instruction += " RIGHT ";
                }
                else
                {
                    instruction += " LEFT ";
                }
                instruction += "onto " + positionList[i - 1].Local.ToUpper();

                returnList.Add(instruction);
            }

            instruction = "Turn";
            if (string.Equals(positionList[0].Direction, "L"))
            {
                instruction += " RIGHT ";
            }
            else
            {
                instruction += " LEFT ";
            }
            instruction += "into your HOME.";

            returnList.Add(instruction);

            return returnList;
        }


        /// <summary>
        /// Counts how many numbers from input ranges are RSA numbers (lowerRange and upperRange)
        /// RSA numbers: A number is an RSA number if it has exactly four divisors. 
        /// </summary>
        /// <param name="lowerRange"></param>
        /// <param name="upperRange"></param>
        /// <returns> string that shows the number of RSA numbers between " + lowerRange + " and " + upperRange + " is " + result </returns>
        /// <example>
        /// GET api/j2/10/12 ->
        /// "The number of RSA numbers between 10 and 12 is 1"
        /// </example>
        /// <example>
        /// GET api/j2/11/15 ->
        /// "The number of RSA numbers between 11 and 15 is 2"
        /// </example>

        //Problem J2: RSA Numbers
        [Route("api/j2/{lowerRange}/{upperRange}")]
        [HttpGet]
        public string J2(int lowerRange, int upperRange)
        {
            int result = CountRSA(lowerRange, upperRange);

            return "The number of RSA numbers between " + lowerRange + " and " + upperRange + " is " + result;
        }
        public int CountRSA(int lowerRange, int upperRange)
        {

            int countRSA = 0;
            for (int i = lowerRange; i <= upperRange; i++)
            {
                if (IsRSA(i))
                {
                    countRSA++;
                }
            }
            return countRSA;
        }
        public bool IsRSA(int number)
        {
            int countDivision = 0;
            for (int i = number; i >= 1; i--)
            {
                if (number % i == 0)
                {
                    countDivision++;
                }
            }
            if (countDivision == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Calculates  dayTime,eveningMinutes, weekendMinutes for plan A and Plan B and indicates which one is the cheapest.
        /// </summary>
        /// <param name="dayTime"></param>
        /// <param name="eveningMinutes"></param>
        /// <param name="weekendMinutes"></param>
        /// <returns> 
        /// string that shows the calculation of {dayTime},{eveningMinutes}, {weekendMinutes}
        /// for minutes of planA and PlanB, then it also indicates which one is the chepeast option or the same price instead.
        /// </returns>
        /// <example> 
        /// GET api/j1/251/10/60 -> 
        /// "Plan A costs 51.25 Plan B costs 18.95 Plan B is the cheapest."
        /// </example>
        /// <example>
        /// GET api/j1/100/50/50 ->
        /// "Plan A costs 17.5 Plan B costs 30 Plan A is the cheapest."
        /// </example>
        /// <example>
        /// GET api/j1/162/61/66 ->
        /// ">Plan A costs 37.85 Plan B costs 37.85 Plan A and B are the same price."
        /// </example>

        //Junior 2005 -  Problem J1: The Cell Sell
        [Route("api/j1/{dayTime}/{eveningMinutes}/{weekendMinutes}")]
        [HttpGet]
        public string J1(int dayTime, int eveningMinutes, int weekendMinutes)
        {
            Plan planA = new Plan("A", 100, 0.25, 0.15, 0.20);
            Plan planB = new Plan("B", 250, 0.45, 0.35, 0.25);

            string message1 = ("Plan " + planB.Name + " is the cheapest.");
            string message2 = ("Plan " + planA.Name + " is the cheapest.");
            string message3 = "Plan A and B are the same price.";

            double amountA = 0;
            double resultDayTimeA = dayTime - planA.DayTimeFree;
            if (resultDayTimeA > 0)
            {
                amountA = planA.DayTimeFee * resultDayTimeA;
            }

            amountA += planA.EveningMinutesFee * eveningMinutes;
            amountA += planA.WeekendMinutesFee * weekendMinutes;

            double amountB = 0;
            double resultDayTimeB = dayTime - planB.DayTimeFree;
            if (resultDayTimeB > 0)
            {
                amountB = planB.DayTimeFee * resultDayTimeB;
            }

            amountB += planB.EveningMinutesFee * eveningMinutes;
            amountB += planB.WeekendMinutesFee * weekendMinutes;

            if (Math.Round(amountA, 2).CompareTo(Math.Round(amountB, 2)) == 0) //Used to round up to 2 decimal places - amount A & amount B and compare them//  
            {
                return ("Plan " + planA.Name + " costs " + amountA) + " " + ("Plan " + planB.Name + " costs " + amountB) + " " + message3;
            }
            else if (amountA.CompareTo(amountB) > 0)
            {
                return ("Plan " + planA.Name + " costs " + amountA) + " " + ("Plan " + planB.Name + " costs " + amountB) + " " + message1;
            }
            else if (amountA.CompareTo(amountB) < 0)
            {
                return ("Plan " + planA.Name + " costs " + amountA) + " " + ("Plan " + planB.Name + " costs " + amountB) + " " + message2;
            }

            return "";
        }

    }
}

