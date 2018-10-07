using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WcfServiceHumanCycle.DTO;

namespace WcfServiceHumanCycle.Model
{
    public class Slice
    {
        public int SliceId { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public ICollection<Human> Humans { get; set; }

        public Slice()
        {
            Humans = new HashSet<Human>();
        }

        public override string ToString()
        {
            return base.ToString();
        }


    }
}