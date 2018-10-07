using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceHumanCycle.Model;

namespace UnitTestProjectWcfServiceHumanCycle
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CreateHuman();

        }

        [TestMethod]
        public void TestMethod2()
        {
            List<Human> humen = GetHumen();
        }

        public List<Human> GetHumen()
        {
            using(Dal dal = new Dal())
            {
               return dal.GetHumen();
            }
        }

        public Human ReturnLastHuman()
        {
            using (Dal dal = new Dal())
            {
                var human = dal.ReturnLastHuman();
                return human;
            }
        }

        public void CreateHuman()
        {
            string firstName = "test01";
            string lastName = "test02";
            using (Dal dal = new Dal())
            {
                dal.CreateHuman(firstName, lastName);
            }
        }
    }
}
