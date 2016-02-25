using InteractiveAlchemyWalkthrough.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace InteractiveAlchemyWalkthrough.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {                        
            var elementSettings = GetElementSettings();
            var elements = BuildGermLine(elementSettings);
            var groups = elements.Values.GroupBy(e => e.Level).OrderBy(g => g.Key);
            return View(groups);
        }

        private Dictionary<string, ElementSetting> GetElementSettings()
        {
            var recipesFile = Server.MapPath("~/Content/recipes.txt");
            var lines = System.IO.File.ReadLines(recipesFile).ToArray();

            var elements = new Dictionary<string, ElementSetting>();

            for(int i=0; i<lines.Count(); i += 3)
            {
                var elementSetting = new ElementSetting(lines[i]);
                var origin = lines[i + 2];

                if (origin != "Default")
                {
                    var parentPairs = origin.Split(new[] { " OR " }, StringSplitOptions.None); // Man + Sex OR Sex + Woman
                    foreach (var parentPair in parentPairs)
                    {
                        var parents = parentPair.Split(new[] { " + " }, StringSplitOptions.None);
                        elementSetting.AddParents(parents[0], parents[1]);
                    }
                }

                elements.Add(elementSetting.Name, elementSetting);
            }

            return elements;
        }

        private Dictionary<string, Element> BuildGermLine(Dictionary<string, ElementSetting> elementSettings)
        {
            var elements = new Dictionary<string, Element>();

            foreach(var elementSetting in elementSettings.Values)
            {
                BuildGermLine(elementSetting, elementSettings, elements);
            }

            return elements;
        }

        private Element BuildGermLine(ElementSetting elementSetting, Dictionary<string, ElementSetting> elementSettings, Dictionary<string, Element> elements)
        {
            if (elements.ContainsKey(elementSetting.Name))
            {
                return elements[elementSetting.Name];
            }

            var element = new Element(elementSetting.Name);

            foreach(var parentPair in elementSetting.PossibleParentPairs)
            {
                var firstParent = BuildGermLine(elementSettings[parentPair.Item1], elementSettings, elements);
                firstParent.EndOfLine = false;

                var secondParent = BuildGermLine(elementSettings[parentPair.Item2], elementSettings, elements);
                secondParent.EndOfLine = false;

                element.PossibleParents.Add(new ParentPair(firstParent, secondParent));
            }

            element.Id = elements.Count;
            elements.Add(element.Name, element);
            return element;
        }
    }
}