using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using WpfPedometer.Model;

namespace WpfPedometer.ViewModel
{
    internal class ConvertToJSON
    {
        public PersonToJSON personToJSON { get; set; }
        public ConvertToJSON(PersonToDG personToDG, int selectedIndex, PersonsToDG personsToDG)
        {
            personToJSON = new PersonToJSON(personToDG.Name, selectedIndex.ToString(), 
                personsToDG.persons[personsToDG.persons.FindIndex(x => x.User == personToDG.Name)].Status,
                personToDG.AvgSteps, personToDG.MaxCountSteps, personToDG.MinCountSteps);

        }

        public void ToJSON()
        {
            string json = JsonSerializer.Serialize(personToJSON, options);
            var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)[..^25];
            File.WriteAllText(path + "\\New JSON\\PersonsInfo.json", json);
        }
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions()
        {
            AllowTrailingCommas = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true
        };
    }
}
