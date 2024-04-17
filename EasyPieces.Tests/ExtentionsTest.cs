using EasyPieces.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;

namespace EasyPieces.Tests
{
    [TestClass]
    public class ExtentionsTest
    {
        enum Test
        {
            None = 0,
            [Display(Name = "Test One")]
            One = 1,
            [Display(Name = "Test Two")]
            Two = 2,
            [Display(Name = "Test Three")]
            Three = 3
        }

        [TestMethod]
        public void GetDisplayNameWhenNull()
        {
            string displayName = Test.None.GetDisplayName();

            Assert.AreEqual(displayName, "None");
        }

        [TestMethod]
        public void GetDisplayNameWhenNotNull()
        {
            string displayName = Test.One.GetDisplayName();

            Assert.AreEqual(displayName, "Test One");
        }

        [TestMethod]
        public void MoveItemInteger()
        {
            List<int> list = new List<int>() { 2, 3, 1 };

            list.MoveItem(2);

            Assert.AreEqual(list.First(), 1);
            Assert.AreEqual(list.Last(), 3);
        }

        [TestMethod]
        public void MoveItemString()
        {
            List<string> list = new List<string>() { "LastName", "FirstName", "MiddleName" };

            list.MoveItem(1, 0);
            list.MoveItem(2, 1);

            Assert.AreEqual(list.First(), "FirstName");
            Assert.AreEqual(list.Last(), "LastName");
        }

        [TestMethod]
        public void CopyPropertiesTo()
        {
            Person person1 = new Person("John", "", "Doe");
            Person person2 = new Person("Jane", "", "");

            person1.CopyPropertiesTo(person2, ["FirstName"]);

            Assert.AreNotEqual(person1.FirstName, person2.FirstName);
            Assert.AreEqual(person1.MiddleName, person2.MiddleName);
            Assert.AreEqual(person1.LastName, person2.LastName);
        }
    }
}