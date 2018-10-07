using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfServiceHumanCycle.DTO;
using WcfServiceHumanCycle.Model;

namespace WcfServiceHumanCycle
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {

        private AppDbContext bdd = new AppDbContext();

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<Human> GetHumen()
        {
            using (IDal dal = new Dal())
            {

                var humen = dal.GetHumen();
                return humen;
            }

        }

        public Human ReturnLastHuman()
        {
            using (IDal dal = new Dal())
            {                
                var human = dal.ReturnLastHuman();
                return human;
            }
        }


        public Human CreateHuman(string lastName, string firstName)
        {

            using (IDal dal = new Dal())
            {
                var human = dal.CreateHuman(lastName, firstName);
                return human;
            }
    
            
        }

        public Human UpdateHuman(Human human)
        {
            using (IDal dal = new Dal())
            {
                //Gender gender = dal.GetHumanGender(human);
                dal.UpdateHuman(human);
                return human;
            }
        }

        public void InsertGenderList(List<Gender> genders)
        {
            using (IDal dal = new Dal())
            {
                dal.InsertGenderList(genders);
            }
        }

        public void InsertHumanList(List<Human> humen)
        {
            using (IDal dal = new Dal())
            {
                dal.InsertHumanList(humen);
            }
        }

        public void InsertStatutList(List<Statut> statut)
        {
            using (IDal dal = new Dal())
            {
                dal.InsertStatutList(statut);
            }
        }

        public void InsertSliceList(List<Slice> slices)
        {
            using (IDal dal = new Dal())
            {
                dal.InsertSliceList(slices);
            }
        }

        public void InsertTownList(List<Town> towns)
        {
            using (IDal dal = new Dal())
            {
                dal.InsertTownList(towns);
            }
        }

        public Gender GetHumanGender(Human human)
        {
            using (IDal dal = new Dal())
            {
                Gender gender = dal.GetHumanGender(human);
                System.Diagnostics.Debug.WriteLine("3/genderId : " + gender.GenderId);
                return gender;
            }
        }

        public void DeleteAllTables()
        {
            using(IDal dal = new Dal())
            {
                dal.DeleteHumanTable();
                dal.DeleteGenderTable();
                dal.DeleteSliceTable();
                dal.DeleteStatutTable();
                dal.DeleteTownTable();            
            }
        }

        public HumanDto GetHumanDto(int humanId)
        {
            HumanDto humanDto = new HumanDto(humanId);
            return humanDto;
        }
    }
}

                        
            
