using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using WpfPedometer.Model;


namespace WpfPedometer.ViewModel
{
    public class PersonsToDG
    {
        private int COUNTDAYS = 30;
        public List<Person> persons = new List<Person>();
        public List<PersonToDG> personsToDG = new List<PersonToDG>();
        public List<List<double>> steps = new List<List<double>>();
        public List<List<double>> listDays = new List<List<double>>();


        public void FillDG()
        {
            for (int i = 1; i <= COUNTDAYS; i++)
            {
                var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)[..^25];
                path += "\\Data\\day"+i+".json";
                var json = File.ReadAllText(path);
                persons = JsonConvert.DeserializeObject<List<Person>>(json);

                foreach (var person in persons)
                {
                    PersonToDG personToDG = new PersonToDG(person.User, person.Steps);

                    if (!personsToDG.Exists(x => x.Name == person.User))
                    {
                        personsToDG.Add(personToDG);
                        steps.Add(new List<double>());

                    }
                    else
                    {
                        personsToDG[personsToDG.FindIndex(x => x.Name == person.User)].AvgSteps += person.Steps;
                        if (personsToDG[personsToDG.FindIndex(x => x.Name == person.User)].MaxCountSteps < person.Steps)
                        {
                            personsToDG[personsToDG.FindIndex(x => x.Name == person.User)].MaxCountSteps = person.Steps;
                        }
                        if (personsToDG[personsToDG.FindIndex(x => x.Name == person.User)].MinCountSteps > person.Steps)
                        {
                            personsToDG[personsToDG.FindIndex(x => x.Name == person.User)].MinCountSteps = person.Steps;
                        }
                    }
                    steps[personsToDG.FindIndex(x => x.Name == person.User)].Add(person.Steps);
                }


            }
            for (int i = 0; i < personsToDG.Count; i++)
            {
                personsToDG[i].AvgSteps /= steps[i].Count;
                listDays.Add(new List<double>());
                for (int j = 1; j <= steps[i].Count; j++)
                {
                    listDays[i].Add(j);
                }
            }
        }
        public void Paint(DataGridRowEventArgs e)
        {
            PersonToDG product = (PersonToDG)e.Row.DataContext;

            if (product.AvgSteps * 1.2 < product.MaxCountSteps || product.AvgSteps * 0.8 > product.MinCountSteps)
                e.Row.Background = new SolidColorBrush(Colors.Orange);
            else
                e.Row.Background = new SolidColorBrush(Colors.White);
        }
    }
}
