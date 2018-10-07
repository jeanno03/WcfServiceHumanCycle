using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfServiceHumanCycle.Model
{
    [DataContract]
    public class Gender
    {
        [DataMember]
        public int GenderId { get; set; }
        [DataMember]
        public int Number { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public ICollection <Human> Humans { get; set; }

        public Gender()
        {
            Humans = new HashSet<Human>();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}