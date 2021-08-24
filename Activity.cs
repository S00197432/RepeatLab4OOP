using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatLab4OOP
{
   public class Activity : IComparable
    {
        public string Name { get; set; }
        public DateTime ActivityDate { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public TypeOfActivity typeOfActivity { get; set; }

        public Activity(string name,DateTime activitydate,decimal cost, string description, TypeOfActivity typeofactivity)
        {
            Name = name;
            ActivityDate = activitydate;
            Cost = cost;
            Description = description;
            typeOfActivity = typeofactivity;
        }

        public override string ToString()
        {
            return string.Format($"{Name} {ActivityDate} {0} ");
        }
        public int CompareTo(object obj)
        {
            Activity act = obj as Activity;
            int returnValue = this.ActivityDate.CompareTo(act.ActivityDate);
            return returnValue;

        }
    }
    public enum TypeOfActivity
    {
        Air,
        Water,
        Land
    }
}
