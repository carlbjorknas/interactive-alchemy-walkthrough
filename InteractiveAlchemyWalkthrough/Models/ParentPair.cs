using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InteractiveAlchemyWalkthrough.Models
{
    public class ParentPair
    {
        public ParentPair(Element firstParent, Element secondParent)
        {
            FirstParent = firstParent;
            SecondParent = secondParent;
        }

        public Element FirstParent { get; set; }
        public Element SecondParent { get; set; }
    }
}