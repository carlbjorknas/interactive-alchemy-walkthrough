using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InteractiveAlchemyWalkthrough.Models
{
    public class Element
    {
        private int _level = 0;
        private List<int> _ancestorIds;

        public Element(string name)
        {
            Name = name;
            PossibleParents = new List<ParentPair>();
            EndOfLine = true;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool EndOfLine { get; set; }

        public int Level
        {
            get
            {
                if (_level == 0 && PossibleParents.Any())
                {
                    var minParentLevel = int.MaxValue;
                    foreach(var parentPair in PossibleParents)
                    {
                        var maxParentLevel = Math.Max(parentPair.FirstParent.Level, parentPair.SecondParent.Level);
                        minParentLevel = Math.Min(minParentLevel, maxParentLevel + 1);
                    }
                    _level = minParentLevel;
                }
                return _level;
            }
        }
        
        public List<ParentPair> PossibleParents { get; set; }

        public List<int> AncestorIds
        {
            get
            {
                if (_ancestorIds == null)
                {
                    var ancestorIds = new HashSet<int>();
                    foreach (var parentPair in PossibleParents)
                    {
                        ancestorIds.Add(parentPair.FirstParent.Id);
                        ancestorIds.UnionWith(parentPair.FirstParent.AncestorIds);

                        ancestorIds.Add(parentPair.SecondParent.Id);
                        ancestorIds.UnionWith(parentPair.SecondParent.AncestorIds);                        
                    }
                    _ancestorIds = ancestorIds.ToList();
                }

                return _ancestorIds;
            }
        }
    }
}