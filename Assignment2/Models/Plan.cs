using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{

    public class Plan
    {
        string name;
        int dayTimeFree;
        double dayTimeFee;
        double eveningMinutesFee;
        double weekendMinutesFee;

        public Plan() { }

        public Plan(
            string name,
            int dayTimeFree,
            double dayTimeFee,
            double eveningMinutesFee,
            double weekendMinutesFee
            )
        {

            this.name = name;
            this.dayTimeFree = dayTimeFree;
            this.dayTimeFee = dayTimeFee;
            this.eveningMinutesFee = eveningMinutesFee;
            this.weekendMinutesFee = weekendMinutesFee;
        }

        public string Name   // property
        {
            get { return name; }
            set { name = value; }
        }

        public int DayTimeFree   // property
        {
            get { return dayTimeFree; }
            set { dayTimeFree = value; }
        }

        public double DayTimeFee   // property
        {
            get { return dayTimeFee; }
            set { dayTimeFee = value; }
        }

        public double EveningMinutesFee   // property
        {
            get { return eveningMinutesFee; }
            set { eveningMinutesFee = value; }
        }

        public double WeekendMinutesFee   // property
        {
            get { return weekendMinutesFee; }
            set { weekendMinutesFee = value; }
        }

    }

}