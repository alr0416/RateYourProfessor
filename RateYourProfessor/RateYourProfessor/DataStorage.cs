using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateYourProfessor
{
    public class DataStorage
    {

        public static List<Professor> professors = new List<Professor>();
        public static List<Rating> ratings = new List<Rating>();
        public static List<Categories> categories = new List<Categories>();


        protected const string ProfessorsFilePath = "professors.txt";
        private const string RatingsFilePath = "ratings.txt";
        private const string CategoriesFilePath = "categories.txt";

        public List<Professor> GetProfessors()
        {
            if (File.Exists(ProfessorsFilePath))
            {
                string json = File.ReadAllText(ProfessorsFilePath);
                return JsonConvert.DeserializeObject<List<Professor>>(json);
            }
            return new List<Professor>();
        }

        public bool SaveProfessors(List<Professor> professors)
        {
            try
            {
                // Create professors.txt
                CreateEmptyFile(ProfessorsFilePath);

                Console.WriteLine("Files created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating files: {ex.Message}");
            }

            for (int i = 0; i < professors.Count; i++)
            {
                var currentProfessor = professors[i];

                // Check for invalid conditions
                if (currentProfessor.ID <= 0 || currentProfessor.Name == null)
                {
                    return false;
                }

                // Check for duplicate IDs
                for (int j = i + 1; j < professors.Count; j++)
                {
                    if (currentProfessor.ID == professors[j].ID)
                    {
                        Console.WriteLine($"Duplicate ID found: {currentProfessor.ID}");
                        return false;
                    }
                }
            }
            string json = JsonConvert.SerializeObject(professors, Formatting.Indented);
            File.WriteAllText(ProfessorsFilePath, json);
            return true;
        }

        public List<Rating> GetRatings()
        {
            if (File.Exists(RatingsFilePath))
            {
                string json = File.ReadAllText(RatingsFilePath);
                return JsonConvert.DeserializeObject<List<Rating>>(json);
            }
            return new List<Rating>();
        }

        public bool SaveRatings(List<Rating> ratings)
        {
            try
            {
                // Create ratings.txt
                CreateEmptyFile(RatingsFilePath);

                Console.WriteLine("Files created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating files: {ex.Message}");
                return false;
            }

            for (int i = 0; i < ratings.Count; i++)
            {
                var currentRating = ratings[i];

                // Check for invalid conditions
                if (currentRating.ID <= 0 || currentRating.Value < 0 || currentRating.Value > 5)
                {
                    Console.WriteLine("Invalid rating ID or Score.");
                    return false;
                }

                // Check for duplicate IDs
                for (int j = i + 1; j < ratings.Count; j++)
                {
                    if (currentRating.ID == ratings[j].ID)
                    {
                        Console.WriteLine($"Duplicate rating ID found: {currentRating.ID}");
                        return false;
                    }
                }
            }

            string json = JsonConvert.SerializeObject(ratings, Formatting.Indented);
            File.WriteAllText(RatingsFilePath, json);
            return true;
        }

        public List<Categories> GetCategories()
        {
            if (File.Exists(CategoriesFilePath))
            {
                string json = File.ReadAllText(CategoriesFilePath);
                return JsonConvert.DeserializeObject<List<Categories>>(json);
            }
            return new List<Categories>();
        }

        public bool SaveCategories(List<Categories> categories)
        {
            try
            {
                // Create categories.txt
                CreateEmptyFile(CategoriesFilePath);

                Console.WriteLine("Files created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating files: {ex.Message}");
                return false;
            }

            for (int i = 0; i < categories.Count; i++)
            {
                var currentCategory = categories[i];

                // Check for invalid conditions
                if (currentCategory.ID <= 0 || currentCategory.Name == null)
                {
                    Console.WriteLine("Invalid category ID or Name.");
                    return false;
                }

                // Check for duplicate IDs
                for (int j = i + 1; j < categories.Count; j++)
                {
                    if (currentCategory.ID == categories[j].ID)
                    {
                        Console.WriteLine($"Duplicate category ID found: {currentCategory.ID}");
                        return false;
                    }
                }
            }

            string json = JsonConvert.SerializeObject(categories, Formatting.Indented);
            File.WriteAllText(CategoriesFilePath, json);
            return true;
        }

        public void CreateEmptyFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, string.Empty);
            }
        }

        public void ClearProfessorsFile()
        {
            File.WriteAllText(ProfessorsFilePath, string.Empty);
        }
        public void ClearCategoriesFile()
        {
            File.WriteAllText(CategoriesFilePath, string.Empty);
        }
        public void ClearRatingsFile()
        {
            File.WriteAllText(RatingsFilePath, string.Empty);
        }

        public void DeleteProfessorsFile()
        {
            File.Delete(ProfessorsFilePath);
        }
        public void DeleteCategoriesFile()
        {
            File.Delete(CategoriesFilePath);
        }
        public void DeleteRatingsFile()
        {
            File.Delete(RatingsFilePath);
        }

        public void AddProfessor()
        {
            Console.Write("Enter Professor ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                // Check if the ID is unique
                if (professors.Any(p => p.ID == id))
                {
                    Console.WriteLine($"Professor with ID {id} already exists. Please choose a unique ID.");
                    return;
                }

                Console.Write("Enter Professor Name: ");
                string name = Console.ReadLine();
                professors.Add(new Professor(id, name));
                Console.WriteLine("Professor added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid input for Professor ID.");
            }
        }

        public void AddRating()
        {
            if (categories.Count > 0 && professors.Count > 0)
            {
                Console.Write("Enter Rating ID: ");
                if (int.TryParse(Console.ReadLine(), out int ratingId))
                {
                    // Check if the ID is unique
                    if (ratings.Any(r => r.ID == ratingId))
                    {
                        Console.WriteLine($"Rating with ID {ratingId} already exists. Please choose a unique ID.");
                        return;
                    }

                    ViewProfessors();

                    Console.Write("Enter Professor ID From the List: ");
                    if (int.TryParse(Console.ReadLine(), out int professorId))
                    {
                        Professor professor = professors.FirstOrDefault(p => p.ID == professorId);
                        if (professor != null)
                        {
                            ViewCategories();

                            Console.Write("Enter Category ID From the List: ");
                            if (int.TryParse(Console.ReadLine(), out int categoryId))
                            {

                                Console.Write("Enter Rating Value (1-10): ");
                                if (int.TryParse(Console.ReadLine(), out int value) && value >= 1 && value <= 10)
                                {
                                    Rating newRating = new Rating(ratingId, professorId, categoryId, value);
                                    ratings.Add(newRating);
                                    professor.Ratings.Add(newRating);
                                    Console.WriteLine("Rating added successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input for Rating Value. Please enter a value between 1 and 10.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input for Category ID.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Professor with ID {professorId} not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for Professor ID.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input for Rating ID.");
                }
            }
            else
            {
                Console.WriteLine("You need at least one professor and one category to add a new rating.");
            }
        }

        public void AddCategory()
        {
            Console.Write("Enter Category ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                // Check if the ID is unique
                if (categories.Any(c => c.ID == id))
                {
                    Console.WriteLine($"Category with ID {id} already exists. Please choose a unique ID.");
                    return;
                }

                Console.Write("Enter Category Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Category Description: ");
                string description = Console.ReadLine();
                categories.Add(new Categories(id, name, description));
                Console.WriteLine("Category added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid input for Category ID.");
            }
        }

        public void EditProfessor()
        {
            ViewProfessors();
            Console.Write("Enter Professor ID to edit: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Professor professor = professors.FirstOrDefault(p => p.ID == id);
                if (professor != null)
                {
                    Console.Write("Enter new Professor Name: ");
                    string newName = Console.ReadLine();
                    professor.Name = newName;
                    Console.WriteLine("Professor edited successfully.");
                }
                else
                {
                    Console.WriteLine($"Professor with ID {id} not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for Professor ID.");
            }
        }

        public void EditRating()
        {
            ViewRatings();
            Console.Write("Enter Rating ID to edit: ");
            if (int.TryParse(Console.ReadLine(), out int ratingId))
            {
                Rating rating = ratings.FirstOrDefault(r => r.ID == ratingId);
                if (rating != null)
                {
                    Console.Write("Enter new Rating Value: ");
                    if (int.TryParse(Console.ReadLine(), out int newValue))
                    {
                        rating.Value = newValue;
                        Console.WriteLine("Rating edited successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for Rating Value.");
                    }
                }
                else
                {
                    Console.WriteLine($"Rating with ID {ratingId} not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for Rating ID.");
            }
        }

        public void EditCategory()
        {
            ViewCategories();
            Console.Write("Enter Category ID to edit: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Categories category = categories.FirstOrDefault(c => c.ID == id);
                if (category != null)
                {
                    Console.Write("Enter new Category Name: ");
                    string newName = Console.ReadLine();
                    Console.Write("Enter new Category Description: ");
                    string newDescription = Console.ReadLine();
                    category.Name = newName;
                    category.Description = newDescription;
                    Console.WriteLine("Category edited successfully.");
                }
                else
                {
                    Console.WriteLine($"Category with ID {id} not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for Category ID.");
            }
        }

        public void DeleteProfessor()
        {
            ViewProfessors();
            Console.Write("Enter Professor ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Professor professor = professors.FirstOrDefault(p => p.ID == id);
                if (professor != null)
                {
                    professors.Remove(professor);
                    Console.WriteLine("Professor deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"Professor with ID {id} not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for Professor ID.");
            }
        }

        public void DeleteRating()
        {
            ViewRatings();
            Console.Write("Enter Rating ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Rating rating = ratings.FirstOrDefault(r => r.ID == id);
                if (rating != null)
                {
                    ratings.Remove(rating);
                    Console.WriteLine("Rating deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"Rating with ID {id} not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for Rating ID.");
            }
        }

        public void DeleteCategory()
        {
            ViewCategories();
            Console.Write("Enter Category ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Categories category = categories.FirstOrDefault(c => c.ID == id);
                if (category != null)
                {
                    categories.Remove(category);
                    Console.WriteLine("Category deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"Category with ID {id} not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for Category ID.");
            }
        }
        public void ViewProfessors()
        {
            Console.WriteLine("List of Professors:");
            foreach (var professor in professors)
            {
                Console.WriteLine($"ID: {professor.ID}, Name: {professor.Name}");
            }
        }

        public void ViewRatings()
        {
            Console.WriteLine("List of Ratings:");
            foreach (var rating in ratings)
            {
                Console.WriteLine($"ID: {rating.ID}, Professor ID: {rating.ProfessorID}, Category ID: {rating.CategoryID}, Value: {rating.Value}");
            }
        }

        public void ViewCategories()
        {
            Console.WriteLine("List of Categories:");
            foreach (var category in categories)
            {
                Console.WriteLine($"ID: {category.ID}, Name: {category.Name}, Description: {category.Description}");
            }
        }

         public void SaveData()
        {
            SaveProfessors(professors);
            SaveRatings(ratings);
            SaveCategories(categories);
            Console.WriteLine("Data saved successfully.");
        }

         public void LoadData()
        {
            professors = GetProfessors();
            ratings = GetRatings();
            categories = GetCategories();
            Console.WriteLine("Data loaded successfully.");
        }
    }

    
}

