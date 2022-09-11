using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPedometer.Model
{
    public class PersonToDG
    {
        public string Name { get; set; }
        public int AvgSteps { get; set; }
        public int MaxCountSteps { get; set; }
        public int MinCountSteps { get; set; }


        public PersonToDG(string name, int avgSteps)
        {
            Name = name;
            AvgSteps = avgSteps;
            MaxCountSteps = 0;
            MinCountSteps = int.MaxValue;
        }
    }
}
