using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WcfServiceHumanCycle.DTO;

namespace WcfServiceHumanCycle.Model
{
    public class Dal : IDal
    {
        private AppDbContext bdd;

        public Dal()
        {
            bdd = new AppDbContext();
        }

        public void Dispose()
        {
            bdd.Dispose();
        }

        public List<Human> GetHumen()
        {
            List<Human> humen = bdd.Humans.ToList();
            //There is a probleme with the transfert protocol lets see it later
            //var humen = bdd.Humans.Include(h => h.Gender).Include(h => h.Slice).Include(h => h.Statut).Include(h => h.Town).ToList();
            return humen;
        }

        public Human ReturnLastHuman()
        {

            Human human = bdd.Humans.OrderByDescending(h => h.HumanId).Take(1).SingleOrDefault();
            //There is a probleme with the transfert protocol lets see it later
            //Human human = bdd.Humans.OrderByDescending(h => h.HumanId).Take(1).Include(h => h.Slice).AsNoTracking().SingleOrDefault();
            //Human human = bdd.Humans.OrderByDescending(h => h.HumanId).Take(1)..Include(h => h.Slice).Include(h => h.Statut).Include(h => h.Town).SingleOrDefault();
            return human;
        }

        public Human CreateHuman(string lastName, string firstName)
        {
            Human human = new Human() { LastName = lastName, FirstName = firstName };
            bdd.Humans.Add(human);
            bdd.SaveChanges();
            return human;
        }

        public Human UpdateHuman(Human human)
        {
            Human humanBdd = bdd.Humans.Find(human.HumanId);
            bdd.Entry(humanBdd).CurrentValues.SetValues(human);
            bdd.SaveChanges();
            return human;
        }

        public void InsertGenderList(List<Gender> genders)
        {
            for (int i = 0; i < genders.Count; i++)
            {
                bdd.Genders.Add(genders[i]);
                bdd.SaveChanges();
            }

        }

        public void InsertSliceList(List<Slice> slices)
        {
            for (int i = 0; i < slices.Count; i++)
            {
                bdd.Slices.Add(slices[i]);
                bdd.SaveChanges();
            }
        }

        public void InsertStatutList(List<Statut> statuts)
        {
            for (int i = 0; i < statuts.Count; i++)
            {
                bdd.Statuts.Add(statuts[i]);
                bdd.SaveChanges();
            }
        }

        public void InsertTownList(List<Town> towns)
        {
            for (int i = 0; i < towns.Count; i++)
            {
                bdd.Towns.Add(towns[i]);
                bdd.SaveChanges();
            }
        }

        public void InsertHumanList(List<Human> humen)
        {

            for (int i = 0; i < humen.Count; i++)
            {
                //for each human I have a list of object
                Gender genderReturn = TestGender(humen[i].Gender);
                Slice sliceReturn = TestSlice(humen[i].Slice);
                Statut statutReturn = TestStatut(humen[i].Statut);
                Town townReturn = TestTown(humen[i].Town);

                //i set the object which existing on database
                if (genderReturn != null)
                {
                    humen[i].Gender = genderReturn;
                }
                //else I dont let the object of human and it will be create on the database

                //i set the object which existing on database
                if (sliceReturn != null)
                {
                    humen[i].Slice = sliceReturn;
                }
                //else I dont let the object of human and it will be create on the database

                //i set the object which existing on database
                if (statutReturn != null)
                {
                    humen[i].Statut = statutReturn;
                }
                //else I dont let the object of human and it will be create on the database

                //i set the object which existing on database
                if (townReturn != null)
                {
                    humen[i].Town = townReturn;
                }
                //else I dont let the object of human and it will be create on the database

                bdd.Humans.Add(humen[i]);
                bdd.SaveChanges();
            }
        }

        //I check if the object on the parameter exist on the database
        //If it exists the method returns the object else its returns null
        private Gender TestGender(Gender gender)
        {
            List<Gender> genders = bdd.Genders.ToList();
            Gender genderTest = new Gender();
            foreach (Gender ge in genders)
            {
                try
                {
                    if (ge.Number == gender.Number)
                    {
                        genderTest = ge;
                    }
                }
                catch (NullReferenceException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }
            }
            return genderTest;
        }

        //I check if the object on the parameter exist on the database
        //If it exists the method returns the object else its returns null
        private Slice TestSlice(Slice slice)
        {
            List<Slice> slices = bdd.Slices.ToList();
            Slice sliceTest = new Slice();
            foreach (Slice si in slices)
            {
                try
                {
                    if (si.Number == slice.Number)
                    {
                        sliceTest = si;
                    }
                }
                catch (NullReferenceException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }
            }
            return sliceTest;
        }

        //I check if the object on the parameter exist on the database
        //If it exists the method returns the object else its returns null
        private Statut TestStatut(Statut statut)
        {
            List<Statut> statuts = bdd.Statuts.ToList();
            Statut statutTest = new Statut();
            foreach (Statut st in statuts)
            {
                try
                {
                    if (st.Number == statut.Number)
                    {
                        statutTest = st;
                    }
                }
                catch (NullReferenceException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }
            }
            return statutTest;
        }

        //I check if the object on the parameter exist on the database
        //If it exists the method returns the object else its returns null
        private Town TestTown(Town town)
        {     
            List<Town> towns = bdd.Towns.ToList();
            Town townTest = new Town();
            //townTest = null;
            foreach (Town to in towns)
            {
                try
                {
                    if (to.Number == town.Number)
                    {
                        townTest = to;    
                    }
                }catch(NullReferenceException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }
            }
            return townTest;           
        }

        public void DeleteHumanTable()
        {
            List<Human> humen = bdd.Humans.ToList();
            foreach (Human human in humen)
            {
                bdd.Humans.Remove(human);
                bdd.SaveChanges();
            }
        }

        public void DeleteGenderTable()
        {
            List<Gender> genders = bdd.Genders.ToList();
            foreach (Gender gender in genders)
            {
                bdd.Genders.Remove(gender);
                bdd.SaveChanges();
            }
        }

        public void DeleteSliceTable()
        {
            List<Slice> slices = bdd.Slices.ToList();
            foreach (Slice slice in slices)
            {
                bdd.Slices.Remove(slice);
                bdd.SaveChanges();
            }
        }

        public void DeleteStatutTable()
        {
            List<Statut> statuts = bdd.Statuts.ToList();
            foreach (Statut statut in statuts)
            {
                bdd.Statuts.Remove(statut);
                bdd.SaveChanges();
            }
        }

        public void DeleteTownTable()
        {
            List<Town> towns = bdd.Towns.ToList();
            foreach(Town town in towns)
            {
                bdd.Towns.Remove(town);
                bdd.SaveChanges();
            }           
        }

        public Gender GetHumanGender(Human human)
        {
            Human humanBdd = bdd.Humans.Where(h => h.LastName.Equals( human.LastName)).SingleOrDefault();
            //I search for the Gender Id
            int genderId = bdd.Humans.Where(h => h.LastName.Equals(human.LastName)).Select(h => h.Gender.GenderId).SingleOrDefault();

            System.Diagnostics.Debug.WriteLine("1/gender id : " + genderId);

            //then i retrieve the object
            //Gender gender = bdd.Genders.Where(g => g.Number.Equals(genderNumber)).SingleOrDefault();
            Gender gender = bdd.Genders.Find(genderId);

            System.Diagnostics.Debug.WriteLine("2/genderId : " + gender.GenderId);

            return gender;
        }

        public Slice GetHumanSlice(Human human)
        {
            throw new NotImplementedException();
        }

        public Statut GetHumanStatut(Human human)
        {
            throw new NotImplementedException();
        }

        public Town GetHumanTown(Human human)
        {
            throw new NotImplementedException();
        }

        public Human GetHuman(int humanId)
        {
            Human human = bdd.Humans.Find(humanId);
            return human;
        }

        public string GetGenderName(int humanId)
        {
            string genderName = bdd.Humans.Where(h => h.HumanId.Equals(humanId)).Select(h => h.Gender.Name).SingleOrDefault();
            return genderName;
        }

        public string GetSliceName(int humanId)
        {
            string sliceName = bdd.Humans.Where(h => h.HumanId.Equals(humanId)).Select(h => h.Slice.Name).SingleOrDefault();
            return sliceName;
        }

        public string GetStatutName(int humanId)
        {
            string statutName = bdd.Humans.Where(h => h.HumanId.Equals(humanId)).Select(h => h.Statut.Name).SingleOrDefault();
            return statutName;
        }

        public string GetTownName(int humanId)
        {
            string townName = bdd.Humans.Where(h => h.HumanId.Equals(humanId)).Select(h => h.Town.Name).SingleOrDefault();
            return townName;
        }

        //not working
        public string GetParentsId(int humanId)
        {
            List<Human> parentsList = bdd.Humans.Where(h => h.HumanId.Equals(humanId)).Include(h => h.Parent).ToList();
            string parentsId = null;
            for (int i = 0; i < parentsList.Count; i++)
            {
                string id = "[id=" + parentsList[i].HumanId+"]";
                parentsId = parentsId + id;
            }
            return parentsId;
        }

        //public List<int> GetParentsId(int humanId)
        //{
        //    List<Human> parentsList = bdd.Parents.Where(p => p.HumanId.Equals(humanId)).ToList();
        //    List<int> parentsId = new List<int>();
        //    for (int i = 0; i < parentsList.Count; i++)
        //    {
        //        parentsId.Add(parentsList[i].HumanId);
        //    }
        //    return parentsId;
        //}


    }


}