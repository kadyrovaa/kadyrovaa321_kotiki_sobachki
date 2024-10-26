using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<PetPhoto> photos = new List<PetPhoto>();

    static void Main()
    {
        InitializePhotos();

        Console.WriteLine("Добро пожаловать в приложение 'Фотографии питомцев'!");
        Console.WriteLine("Введите ваше имя:");
        string userName = Console.ReadLine();

        if (userName == "Андрей пирокинезис")
        {
            ShowPetPhotos("Ра");
        }
        else if (userName == "Деля")
        {
            ShowPetPhotos("Нуби");
        }
        else
        {
            Console.WriteLine("Неизвестный пользователь. Доступ запрещен.");
            return;
        }

        while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Добавить фотографию");
            Console.WriteLine("2. Поиск по описанию");
            Console.WriteLine("3. Сортировка по описанию");
            Console.WriteLine("4. Выход");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddPhoto();
                    break;
                case "2":
                    SearchPhotos();
                    break;
                case "3":
                    SortPhotos();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    static void InitializePhotos()
    {
        photos.Add(new PetPhoto { PetName = "Ра", Description = "Котенок Ра играет с мячиком", PhotoPath = "photo_5316516549026239223_y.jpg" });
        photos.Add(new PetPhoto { PetName = "Нуби", Description = "Собачка Нуби сидит на солнышке", PhotoPath = "photo_5316516549026239219_y.jpg" });
        photos.Add(new PetPhoto { PetName = "Ра", Description = "Котенок Ра вкусно покушал, он доволен", PhotoPath = "photo_5316516549026239222_y.jpg" });
        photos.Add(new PetPhoto { PetName = "Нуби", Description = "Собачка Нуби наелся и спит", PhotoPath = "photo_5316516549026239215_y.jpg" });
    }

    static void ShowPetPhotos(string petName)
    {
        var petPhotos = photos.Where(p => p.PetName == petName).ToList();
        Console.WriteLine($"Фотографии {petName}:");
        foreach (var photo in petPhotos)
        {
            Console.WriteLine($"Описание: {photo.Description}, Путь к фото: {photo.PhotoPath}");
        }
    }

    static void AddPhoto()
    {
        Console.WriteLine("Введите кличку питомца (Ра/Нуби):");
        string petName = Console.ReadLine();

        Console.WriteLine("Введите описание фотографии:");
        string description = Console.ReadLine();

        Console.WriteLine("Введите путь к фотографии:");
        string photoPath = Console.ReadLine();

        photos.Add(new PetPhoto { PetName = petName, Description = description, PhotoPath = photoPath });
        Console.WriteLine("Фотография добавлена!");
    }

    static void SearchPhotos()
    {
        Console.WriteLine("Введите текст для поиска:");
        string searchText = Console.ReadLine();

        var foundPhotos = photos.Where(p => p.Description.Contains(searchText)).ToList();
        Console.WriteLine("Найденные фотографии:");
        foreach (var photo in foundPhotos)
        {
            Console.WriteLine($"Описание: {photo.Description}, Путь к фото: {photo.PhotoPath}");
        }
    }

    static void SortPhotos()
    {
        var sortedPhotos = photos.OrderBy(p => p.Description).ToList();
        Console.WriteLine("Отсортированные фотографии:");
        foreach (var photo in sortedPhotos)
        {
            Console.WriteLine($"Описание: {photo.Description}, Путь к фото: {photo.PhotoPath}");
        }
    }
}

class PetPhoto
{
    public string PetName { get; set; }
    public string Description { get; set; }
    public string PhotoPath { get; set; }
}