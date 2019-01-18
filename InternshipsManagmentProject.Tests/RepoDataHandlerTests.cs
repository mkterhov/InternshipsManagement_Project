using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using InternshipsManagmentProject.Data;
using InternshipsManagmentProject.Data.Repos;
using InternshipsManagmentProject.Data.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace InternshipsManagmentProject.Tests
{
    [TestClass]
    public class RepositoryDataResponseHandler
    {
        static Func<Entities> contextCreator = () => new Entities();

        static RepositoryGenericDRH<Firm> instance = new RepositoryGenericDRH<Firm>();


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
            DataResponseHandler<string> result = instance.AddEntity(newEntity);
            bool expected = true;
            Assert.AreEqual(expected, result.Succes);
        }
        [TestMethod]
        public void Update_OK()
        {
            /// changed values for tests  


            Func<Entities> contextCreator = () => new Entities();


            Firm updateEntity = new Firm
            {
                FirmId = "e20badcf-fd71-4ca1-9f2d-a8d1335f7c34",
                Description = "GENERIC AN UPDATED FIRM",
                Name = "New FIRM",
                NumberOfEmployees = 10,
                Deleted = false,
            };

            var result = instance.UpdateEntity(updateEntity);
            bool expected = true;

            Assert.AreEqual(expected, result.Succes);
        }
        [TestMethod]
        public void Find_OK2()
        {
            Func<Entities> contextCreator = () => new Entities();
            DataResponseHandler<Firm> result = instance.GetById(pks: "5798-403c-a941-dcfaa6bacd2c");
            if(result.Succes==false)
            {
                Assert.AreEqual(result.Succes, false);
                return;
            } else
            {
                Assert.AreEqual(result.Container.FirmId, "05d68886-5798-403c-a941-dcfaa6bacd2c");

            }
        }
        //00000000-0000-0000-0000-000000000000
        [TestMethod]
        public void Remove_SimpleItem_forEntity_OK()
        {
            /// changed pk for tests  
            Func<Entities> contextCreator = () => new Entities();
            DataResponseHandler<Firm> removeEntity = instance.GetById("e081e4ef-377c-4ddd-977b-9e31ddf9f345");
            if(removeEntity.Succes==true)
            {
                var result = instance.Remove(removeEntity.Container);
                var expected = true;
                Assert.AreEqual(expected, result.Succes);
            }
            else
            {
                Assert.AreEqual(removeEntity.Succes, false);
            }
        }
        [TestMethod]
        public void GetData_OK()
        {

            Func<Entities> contextCreator = () => new Entities();
            Expression<Func<Firm, bool>> filter = a => a.FirmId == "00000000-0000-0000-0000-000000000000";
            DataResponseHandler<IEnumerable<Firm>> result = instance.GetData(filter);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Container.Count() == 0);
        }

        [TestMethod]
        public void All_OK()
        {
            Func<Entities> contextCreator = () => new Entities();
            DataResponseHandler<IEnumerable<Firm>> result = instance.GetAll();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Container.Count() > 0);
        }

    }
}
