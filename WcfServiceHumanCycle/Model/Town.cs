using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfServiceHumanCycle.Model
{
    public class Town
    {
        public int TownId { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public ICollection<Human> Humans { get; set; }

        public Town()
        {
            Humans = new HashSet<Human>();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}