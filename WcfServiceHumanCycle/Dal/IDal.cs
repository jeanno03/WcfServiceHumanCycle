using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WcfServiceHumanCycle.DTO;

namespace WcfServiceHumanCycle.Model
{

    interface IDal:IDisposable
    {
        List<Human> GetHumen();
        Human ReturnLastHuman();
        Human CreateHuman(string firstName, string lastName);
        Human UpdateHuman(Human human);   
        void InsertGenderList(List<Gender> genders);
        void InsertStatutList(List<Statut> statuts);
        void InsertSliceList(List<Slice> slices);
        void InsertTownList(List<Town> towns);
        void InsertHumanList(List<Human> humen);
        void DeleteHumanTable();
        void DeleteGenderTable();
        void DeleteSliceTable();
        void DeleteStatutTable();
        void DeleteTownTable();
        Gender GetHumanGender(Human human);
        Slice GetHumanSlice(Human human);
        Statut GetHumanStatut(Human human);
        Town GetHumanTown(Human human);
        Human GetHuman(int humanId);
        string GetGenderName(int humanId);
        string GetSliceName(int humanId);
        string GetStatutName(int humanId);
        string GetTownName(int humanId);
        string GetParentsId(int humanId);


    }
}
