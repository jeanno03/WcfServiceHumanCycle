using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfServiceHumanCycle.Model
{
    [DataContract]
    public class Human
    {
        [DataMember]
        public int HumanId { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public virtual ICollection<Human>  Parent { get; set; }
        [DataMember]
        public virtual ICollection<Human> Children { get; set; }
        [DataMember]
        public virtual Town Town { get; set; }
        [DataMember]
        public virtual Slice Slice { get; set; }
        [DataMember]
        public virtual Gender Gender { get; set; }
        [DataMember]
        public virtual Statut Statut { get; set; }

        public Human()
        {
            Parent = new HashSet<Human>();
            Children = new HashSet<Human>();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}