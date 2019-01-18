using InternshipsManagmentProject.Data;
using InternshipsManagmentProject.Data.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InternshipsManagmentProject.Tests
{
    [TestClass]
    public class RepositoryTest
    {
        Firm lastAdded;
        static Func<Entities> contextCreator = () => new Entities();

        private static Repository<Firm> instance = new Repository<Firm>();


        [TestMethod]
        public void Add_SimpleItem_OK()
        {

            string guid = Guid.NewGuid().ToString();


            Firm newEntity = new Firm
            {
                FirmId = guid,
                Description = "AN ADD",
                Name = "New FIRM",
                NumberOfEmployees = 10,
                Deleted = false,
            };
            int result = instance.AddEntity(newEntity);
            int expected = 1;
            lastAdded = newEntity;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Update_OK()
        {
            /// changed values for tests  


            Func<Entities> contextCreator = () => new Entities();


            Firm updateEntity = new Firm
            {
                FirmId = "e20badcf-fd71-4ca1-9f2d-a8d1335f7c34",
                Description = "AN UPDATED FIRM",
                Name = "New FIRM",
                NumberOfEmployees = 10,
                Deleted = false,
            };

            int result = instance.UpdateEntity(updateEntity);
            int expected =1;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Find_OK2()
        {
            Func<Entities> contextCreator = () => new Entities();
            Firm result = instance.GetById(pks: "05d68886-5798-403c-a941-dcfaa6bacd2c");
            Assert.AreEqual(result.FirmId, "05d68886-5798-403c-a941-dcfaa6bacd2c");
        }
        //00000000-0000-0000-0000-000000000000
        [TestMethod]
        public void Remove_SimpleItem_forEntity_OK()
        {
            /// changed pk for tests  
            Func<Entities> contextCreator = () => new Entities();
            Firm removeEntity = instance.GetById("adc9c491-c1ee-49b1-851b-3cb1b8fde958");
            int result = instance.Remove(removeEntity);
            int expected = 1;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void GetData_OK()
        {

            Func<Entities> contextCreator = () => new Entities();
            Repository<Firm> instance = new Repository<Firm>(dbContextCreator: contextCreator);
            Expression<Func<Firm, bool>> filter = a => a.FirmId == "00000000-0000-0000-0000-000000000000";
            IEnumerable<Firm> result = instance.GetData(filter);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() == 0);
        }

        [TestMethod]
        public void All_OK()
        {
            Func<Entities> contextCreator = () => new Entities();
            Repository<Firm> instance = new Repository<Firm>(dbContextCreator: contextCreator);
            IEnumerable<Firm> result = instance.GetAll();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }
    }


}
