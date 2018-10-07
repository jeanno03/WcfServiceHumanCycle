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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: ajoutez vos opérations de service ici
        [OperationContract]
        List<Human> GetHumen();

        [OperationContract]
        Human ReturnLastHuman();

        [OperationContract]
        Human CreateHuman(string lastName, string firstName);

        [OperationContract]
        Human UpdateHuman(Human human);

        [OperationContract]
        void InsertGenderList(List<Gender> genders);

        [OperationContract]
        void InsertHumanList(List<Human> humen);

        [OperationContract]
        void InsertStatutList(List<Statut> statuts);

        [OperationContract]
        void InsertSliceList(List<Slice> slices);

        [OperationContract]
        void InsertTownList(List<Town> towns);
        //not working
        [OperationContract]
        Gender GetHumanGender(Human human);

        [OperationContract]
        void DeleteAllTables();

        [OperationContract]
        HumanDto GetHumanDto(int humanId);

    }


    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
