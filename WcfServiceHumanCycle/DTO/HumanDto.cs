using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfServiceHumanCycle.Model;

namespace WcfServiceHumanCycle.DTO
{
    public class HumanDto
    {
        public int HumanId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public string GenderName { get; set; }
        public string SliceName { get; set; }
        public string StatutName { get; set; }
        public string TownName { get; set; }

        public string ParentsId { get; set; }
        //public List<int> ChildrenId { get; set; }



        public HumanDto()
        {
            //ParentsId = new List<int>();
            //ChildrenId = new List<int>();
        }

        public HumanDto(int HumanId)
        {
            this.HumanId = HumanId;
            this.LastName = GetHuman().LastName;
            this.FirstName = GetHuman().FirstName;
            
            GetGenderName();
            GetSliceName();
            GetStatutName();
            GetTownName();

            //GetParentsId();
        }

        private Human GetHuman()
        {
            using (IDal dal = new Dal())
            {
                Human human = dal.GetHuman(this.HumanId);
                return human;
            }

        }

        private string GetGenderName()
        {
            using (IDal dal = new Dal())
            {
                return this.GenderName = dal.GetGenderName(this.HumanId);
            }

        }

        private string GetSliceName()
        {
            using (IDal dal = new Dal())
            {
                return this.SliceName = dal.GetSliceName(this.HumanId);
            }

        }

        private string GetStatutName()
        {
            using (IDal dal = new Dal())
            {
                return this.StatutName = dal.GetStatutName(this.HumanId);
            }

        }

        private string GetTownName()
        {
            using (IDal dal = new Dal())
            {
                return this.TownName = dal.GetTownName(this.HumanId);
            }

        }

        private string GetParentsId()
        {
            using (IDal dal = new Dal())
            {
                return this.ParentsId = dal.GetParentsId(this.HumanId);
            }

        }
    }
}