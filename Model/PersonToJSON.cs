using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace WpfPedometer.Model
{
    public class PersonToJSON
    {
        public string Name { get; set; }
        public string Rank { get; set; }
        public string Status { get; set; }
        public int AvgSteps { get; set; }
        public int MaxCountSteps { get; set; }
        public int MinCountSteps { get; set; }
        public PersonToJSON(string name, string rank, string status, int avgSteps, int maxCount, int minCount)
        {
            this.Name = name;
            this.Rank = rank;
            this.Status = status;
            this.AvgSteps = avgSteps;
            this.MaxCountSteps = maxCount;
            this.MinCountSteps = minCount;
        }
       
    }
}
