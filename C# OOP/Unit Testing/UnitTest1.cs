using System;
using System.Reflection;
using ExtendedDatabase;
using NUnit.Framework;

namespace Database.Tests
{
    public class Tests
    {
        private Database database;
        private FieldInfo[] fields;
        private int[] dataField;
        [SetUp]
        public void SetUp()
        {
            database = new Database(1, 2, 3, 4);
            Type type = typeof(Database);
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (FieldInfo field in fields)
            {
                if (field.Name == "data")
                {
                    dataField = field.GetValue(database) as int[];


                }

            }
        }
        [Test]
        [TestCase(new int[] { 1, 2, 3 })]
        public void Check_Constructor_Params(int[] input)
        {
            Database actual = new Database(input);
            Assert.AreEqual(input.Length, actual.Count);


        }

        [Test]
        public void Check_If_Storing_Array_Capacity_Is_16()
        {


            Assert.AreEqual(dataField.Length, 16);
            //tofix
        }
        [Test]
        public void Check_If_Exception_Is_Thrown_When_Array_Capcity_Is_Not_16()
        {



        }
        [Test]
        public void Check_If_Add_Method_Adds_A_New_Element_At_The_Next_Cell()
        {
            database.Add(5);
            Assert.That(dataField[4] == 5);
        }
        [Test]
        public void Check_If_Exception_Is_Thrown_When_You_Try_To_Add_A_17th_Element()
        {
            for (int i = 1; i <= 12; i++)
            {
                database.Add(i);
            }
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(17);


            });


        }

        [Test]
        public void Check_If_Remove_Method_Removes_The_Element_At_The_Last_Cell()
        {
            database.Remove();
            Assert.That(dataField[3] == 0);
        }
        [Test]
        public void Check_If_Exception_Is_Thrown_When_You_Try_To_Remove_Element_From_Empty_Database()
        {
            for (int i = 1; i <= 4; i++)
            {
                database.Remove();
            }
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();


            });


        }


        [Test]
        public void Check_If_Constructor_Stores_Elements_In_An_Array()
        {
            Assert.That(dataField[0] == 1 && dataField[1] == 2 && dataField[2] == 3 && dataField[3] == 4);


        }
        [Test]
        public void Fetch_Should_Return_Elements_As_Array()
        {
            int[] actualData = new int[4];
            for (int i = 0; i < actualData.Length; i++)
            {
                actualData[i] = dataField[i];
            }
            int[] fetchedArray = database.Fetch();
            Assert.AreEqual(fetchedArray, actualData);


        }
        //------------------------------------------------------------------------------------------------------------

        
    }
}