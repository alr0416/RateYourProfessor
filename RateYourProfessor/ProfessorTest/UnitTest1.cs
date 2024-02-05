
using Newtonsoft.Json;
using RateYourProfessor;
using System;

namespace ProfessorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddEmptyProfessor()
        {
            
            DataStorage ds = new DataStorage();
            ds.ClearProfessorsFile();

            Professor p1 = new Professor(0, null);
            List<Professor> pL = new List<Professor> { p1 };
            ds.SaveProfessors(pL);

            
            Assert.IsNull(ds.GetProfessors());
        }

        [TestMethod]
        public void TestAddProfessorToFileThatExists()
        {

            DataStorage ds = new DataStorage();
            ds.ClearProfessorsFile();
            Professor p1 = new Professor(1, "Bilitski");
            List<Professor> pL = new List<Professor> { p1 };

            ds.SaveProfessors(pL);

            List<Professor> test = ds.GetProfessors();

            Assert.AreEqual(pL[0].Name, test[0].Name);

        }

        [TestMethod]
        public void TestAddProfessorToFileThatDoesNotExist()
        {

            DataStorage ds = new DataStorage();
            ds.DeleteProfessorsFile();
            Professor p1 = new Professor(1, "Bilitski");
            List<Professor> pL = new List<Professor> { p1 };

            ds.SaveProfessors(pL);

            List<Professor> test = ds.GetProfessors();

            Assert.AreEqual(pL[0].Name, test[0].Name);

        }

        [TestMethod]
        public void AddDuplicateProfessorToFile()
        {
            DataStorage ds = new DataStorage();
            ds.ClearProfessorsFile();
            Professor p1 = new Professor(1, "Bilitski");
            Professor p2 = new Professor(1, "Bilitski");
            List<Professor> pL = new List<Professor> { p1, p2 };


            Assert.IsFalse(ds.SaveProfessors(pL));

            
        }

        [TestMethod]
        public void TestAddCategoryToFileThatExists()
        {

            DataStorage ds = new DataStorage();
            ds.ClearCategoriesFile();
            Categories c1 = new Categories(1, "Happy", "How happy are they");
            List<Categories> catList = new List<Categories> { c1 };

            ds.SaveCategories(catList);

            List<Categories> test = ds.GetCategories();

            Assert.AreEqual(catList[0].Name, test[0].Name);

        }

        [TestMethod]
        public void TestAddCategoryToFileThatDoesNotExist()
        {

            DataStorage ds = new DataStorage();
            ds.DeleteCategoriesFile();
            Categories c1 = new Categories(1, "Happy", "How happy are they");
            List<Categories> catList = new List<Categories> { c1 };

            ds.SaveCategories(catList);

            List<Categories> test = ds.GetCategories();

            Assert.AreEqual(catList[0].Name, test[0].Name);

        }



        [TestMethod]
        public void SaveAndRetrieveCategories()
        {
            DataStorage ds = new DataStorage();
            ds.ClearCategoriesFile();

            Categories cat1 = new Categories(1, "Math", " ");
            Categories cat2 = new Categories(2, "Physics", " ");
            List<Categories> categoriesList = new List<Categories> { cat1, cat2 };

            ds.SaveCategories(categoriesList);

            List<Categories> retrievedCategories = ds.GetCategories();

            Assert.AreEqual(categoriesList.Count, retrievedCategories.Count);
        }

        [TestMethod]
        public void AddDuplicateCategoryToFile()
        {
            DataStorage ds = new DataStorage();
            ds.ClearCategoriesFile();

            Categories cat1 = new Categories(1, "Math", " ");
            Categories cat2 = new Categories(1, "Physics", " ");
            List<Categories> categoriesList = new List<Categories> { cat1, cat2 };

            Assert.IsFalse(ds.SaveCategories(categoriesList));
        }


        [TestMethod]
        public void TestAddRatingToFileThatExists()
        {

            DataStorage ds = new DataStorage();

            /*Make a test professor*/
            ds.ClearProfessorsFile();
            Professor p1 = new Professor(1, "Bilitski");
            List<Professor> pL = new List<Professor> { p1 };

            ds.SaveProfessors(pL);

            /*Make a test category*/
            ds.ClearCategoriesFile();
            Categories c1 = new Categories(1, "Happy", "How happy are they");
            List<Categories> catList = new List<Categories> { c1 };

            ds.SaveCategories(catList);

            /*Make a test rating*/

            
            ds.ClearRatingsFile();
            Rating r1 = new Rating(1, 1, 1, 5);
            List<Rating> ratingList = new List<Rating> { r1 };

            ds.SaveRatings(ratingList);

            List<Rating> test = ds.GetRatings();

            Assert.AreEqual(ratingList[0].Value, test[0].Value);

        }

        [TestMethod]
        public void TestAddRatingToFileThatDoesNotExists()
        {

            DataStorage ds = new DataStorage();
            ds.DeleteRatingsFile();

            /*Make a test professor*/
            Professor p1 = new Professor(1, "Bilitski");
            List<Professor> pL = new List<Professor> { p1 };

            ds.SaveProfessors(pL);

            /*Make a test category*/
            ds.ClearCategoriesFile();
            Categories c1 = new Categories(1, "Happy", "How happy are they");
            List<Categories> catList = new List<Categories> { c1 };

            ds.SaveCategories(catList);

            /*Make a test rating*/

            Rating r1 = new Rating(1, 1, 1, 5);
            List<Rating> ratingList = new List<Rating> { r1 };

            ds.SaveRatings(ratingList);

            List<Rating> test = ds.GetRatings();

            Assert.AreEqual(ratingList[0].Value, test[0].Value);

        }

        [TestMethod]
        public void SaveAndRetrieveRatings()
        {
            DataStorage ds = new DataStorage();
            ds.ClearRatingsFile();

            Rating rating1 = new Rating(1, 4, 3, 2);
            Rating rating2 = new Rating(2, 3, 4, 3);
            List<Rating> ratingsList = new List<Rating> { rating1, rating2 };

            ds.SaveRatings(ratingsList);

            List<Rating> retrievedRatings = ds.GetRatings();

            Assert.AreEqual(ratingsList.Count, retrievedRatings.Count);
        }

        [TestMethod]
        public void AddDuplicateRatingToFile()
        {
            DataStorage ds = new DataStorage();
            ds.ClearRatingsFile();

            Rating rating1 = new Rating(1, 4, 3, 2);
            Rating rating2 = new Rating(1, 3, 4, 3);
            List<Rating> ratingsList = new List<Rating> { rating1, rating2 };

            Assert.IsFalse(ds.SaveRatings(ratingsList));
        }

        [TestClass]
        
        public class ProgramTests
        {
            private StringWriter consoleOutput;
            private StringReader consoleInput;

            [TestInitialize]
            public void Setup()
            {
                consoleOutput = new StringWriter();
                Console.SetOut(consoleOutput);
            }

            [TestCleanup]
            public void Cleanup()
            {
                consoleOutput.Dispose();
                consoleInput.Dispose();
                DataStorage.professors.Clear();
                DataStorage.ratings.Clear();
                DataStorage.categories.Clear(); 
            }

            [TestMethod]
            public void TestAddProfessor_UniqueID()
            {
                DataStorage ds = new DataStorage();
                consoleInput = new StringReader("1\nJohn Doe\n");
                Console.SetIn(consoleInput);

                ds.AddProfessor();
                
                Assert.AreEqual(1, DataStorage.professors.Count);
            }

            [TestMethod]
            public void TestAddProfessor_DuplicateID()
            {
                DataStorage ds = new DataStorage();
                DataStorage.professors.Add(new Professor(1, "ExistingProfessor"));
                consoleInput = new StringReader("1\nJohn Doe\n");
                Console.SetIn(consoleInput);

                ds.AddProfessor();
                
                Assert.AreEqual(1, DataStorage.professors.Count); 
            }


            [TestMethod]
            public void TestAddCategory_UniqueID()
            {
                DataStorage ds = new DataStorage();
                consoleInput = new StringReader("1\nTestCategory\nTestDescription\n");
                Console.SetIn(consoleInput);

                ds.AddCategory();

                Assert.AreEqual("TestCategory", DataStorage.categories[0].Name);
            }

            [TestMethod]
            public void TestAddCategory_DuplicateID()
            {
                DataStorage ds = new DataStorage();
                DataStorage.categories.Add(new Categories(1, "ExistingCategory", "ExistingDescription"));
                consoleInput = new StringReader("1\nTestCategory\nTestDescription\n");
                Console.SetIn(consoleInput);

                ds.AddCategory();

                Assert.AreEqual(1, DataStorage.categories.Count);
                Assert.AreEqual("ExistingCategory", DataStorage.categories[0].Name);
            }


            

            [TestMethod]
            public void TestAddRating_UniqueID()
            {
                DataStorage ds = new DataStorage();
                /*Add a valid professor*/
                consoleInput = new StringReader("1\nJohn Doe\n");
                Console.SetIn(consoleInput);

                ds.AddProfessor();

                /*Add a valid category*/
                consoleInput = new StringReader("1\nTestCategory\nTestDescription\n");
                Console.SetIn(consoleInput);

                ds.AddCategory();

                /*Add a valid rating*/
                consoleInput = new StringReader("1\n1\n1\n5\n");
                Console.SetIn(consoleInput);

                ds.AddRating();

                Assert.AreEqual(1, DataStorage.ratings.Count);
                Assert.AreEqual(5, DataStorage.ratings[0].Value);
            }
            
            [TestMethod]
            public void TestAddRating_DuplicateID()
            {
                DataStorage ds = new DataStorage();
                /*Add a valid professor*/
                consoleInput = new StringReader("1\nJohn Doe\n");
                Console.SetIn(consoleInput);

                ds.AddProfessor();

                /*Add a valid category*/
                consoleInput = new StringReader("1\nTestCategory\nTestDescription\n");
                Console.SetIn(consoleInput);

                ds.AddCategory();

                /*Add a valid rating*/
                consoleInput = new StringReader("1\n1\n1\n5\n");
                Console.SetIn(consoleInput);

                ds.AddRating();

                /*Try to add a duplicate rating id*/
                consoleInput = new StringReader("1\n1\n1\n7\n");
                Console.SetIn(consoleInput);

                ds.AddRating();
                Assert.AreEqual(1, DataStorage.ratings.Count);
                Assert.AreEqual(5, DataStorage.ratings[0].Value);
            }

        }
    }
}