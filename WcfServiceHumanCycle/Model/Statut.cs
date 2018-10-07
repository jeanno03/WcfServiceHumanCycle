using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfServiceHumanCycle.Model
{
    public class Statut
    {
        public int StatutId { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public ICollection<Human> Humans { get; set; }

        public Statut()
        {
            Humans = new HashSet<Human>();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}