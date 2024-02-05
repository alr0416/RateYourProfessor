using Newtonsoft.Json;
using RateYourProfessor;
using System.Data;
// See https://aka.ms/new-console-template for more information


public class Program
{
        
    static DataStorage dataStorage = new DataStorage();
    

    static void Main()
    {
        dataStorage.LoadData();
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("1. Add Professor");
            Console.WriteLine("2. Add Rating");
            Console.WriteLine("3. Add Category");
            Console.WriteLine("4. Edit Professor");
            Console.WriteLine("5. Edit Rating");
            Console.WriteLine("6. Edit Category");
            Console.WriteLine("7. Delete Professor");
            Console.WriteLine("8. Delete Rating");
            Console.WriteLine("9. Delete Category");
            Console.WriteLine("10. View Professors");
            Console.WriteLine("11. View Ratings");
            Console.WriteLine("12. View Categories");
            Console.WriteLine("0. Exit");


            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        dataStorage.AddProfessor();
                        break;
                    case 2:
                        dataStorage.AddRating();
                        break;
                    case 3:
                        dataStorage.AddCategory();
                        break;
                    case 4:
                        dataStorage.EditProfessor();
                        break;
                    case 5:
                        dataStorage.EditRating();
                        break;
                    case 6:
                        dataStorage.EditCategory();
                        break;
                    case 7:
                        dataStorage.DeleteProfessor();
                        break;
                    case 8:
                        dataStorage.DeleteRating();
                        break;
                    case 9:
                        dataStorage.DeleteCategory();
                        break;
                    case 10:
                        dataStorage.ViewProfessors();
                        break;
                    case 11:
                        dataStorage.ViewRatings();
                        break;
                    case 12:
                        dataStorage.ViewCategories();
                        break;
                    case 0:
                        dataStorage.SaveData();
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    

}





    


