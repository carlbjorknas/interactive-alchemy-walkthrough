using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InteractiveAlchemyWalkthrough.Models
{
    public class ElementSetting
    {
        public ElementSetting(string name)
        {
            Name = name;
            PossibleParentPairs = new List<Tuple<string, string>>();
        }

        public List<Tuple<string, string>> PossibleParentPairs { get; private set; }

        public string Name { get; private set; }
        
        public void AddParents(string parent1, string parent2)
        {
            PossibleParentPairs.Add(new Tuple<string, string>(parent1, parent2));
        }
    }
}