

using Deneme;

List<Group> groups = new List<Group>();

string input;

do
{
    Console.WriteLine("1. Yeni qrup yarat");
    Console.WriteLine("2. Qrupların siyahısını göstər");
    Console.WriteLine("3. Qrup üzərində düzəliş etmək");
    Console.WriteLine("4. Qrupdakı tələbələrin siyahısını göstər");
    Console.WriteLine("5. Bütün tələbələrin siyahısını göstər");
    Console.WriteLine("6. Tələbə yarat");
    Console.WriteLine("0. Çıxış");
    Console.Write("Seciminiz: ");
    input = Console.ReadLine();
    Console.Clear();

    switch (input)
    {
        case "1":
            CreateGroup(groups);
            break;
        case "2":
            GetAllGroup(groups);
            break;
        case "3":
            EditGroup(groups);
            break;
        case "4":
            ShowGroupStudents(groups);
            break;
        case "5":
            GetAllStudents(groups);
            break;
        case "6":
            CreateStudent(groups);
            break;
        default:
            break;
    }

} while (input != "0");


// ========================== METODLAR ========================== //




void CreateGroup(List<Group> groups)
{
    string categoryInput;
    string onlineInput;

    while (true)
    {
        Console.Write("Grup No: ");
        string groupNo = Console.ReadLine();



        CourseCategoryEnum category;

        while (true)
        {
            Console.WriteLine("Kateqoriya seçin:");
            Console.WriteLine("1. Programming");
            Console.WriteLine("2. Design");
            Console.WriteLine("3. System Administration");
            Console.Write("Secim: ");
            categoryInput = Console.ReadLine();


            switch (categoryInput)
            {
                case "1":
                    category = CourseCategoryEnum.Programming;
                    break;
                case "2":
                    category = CourseCategoryEnum.Design;
                    break;
                case "3":
                    category = CourseCategoryEnum.SystemAdministration;
                    break;
                default:
                    Console.WriteLine("Yanlis Secim!");
                    continue;
            }
            break;
        }

        bool isOnline;


        while (true)
        {
            Console.WriteLine("IsOnline: ");
            Console.WriteLine("1. Online");
            Console.WriteLine("2. Eyani");
            Console.Write("Secim: ");
            onlineInput = Console.ReadLine();


            switch (onlineInput)
            {
                case "1":
                    isOnline = true;
                    break;
                case "2":
                    isOnline = false;
                    break;
                default:
                    Console.WriteLine("Secim Yanlisdir!");
                    continue;
            }
            break;
        }



        try
        {
            Group group = new Group(groupNo, category, isOnline);
            groups.Add(group);
            Console.WriteLine("Qrup ugurla yaradildi.");
            break;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Xəta baş verdi: {e.Message}");
        }
    }
}





void GetAllGroup(List<Group> groups)
{
    foreach (var group in groups)
    {
        Console.WriteLine($"GroupName: {group.GroupNo}, IsOnline: {group.IsOnline}, StudentCount: {group.Students.Count}");
    }
}

void EditGroup(List<Group> groups)
{
    Console.WriteLine("Adını dəyişmək istədiyiniz qrupu seçin:");

    for (int i = 0; i < groups.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {groups[i].GroupNo}");
    }

    Console.Write("Seçim: ");

    int selectedIndex;
    try
    {
        selectedIndex = Convert.ToInt32(Console.ReadLine());

        if (selectedIndex < 1 || selectedIndex > groups.Count)
        {
            Console.WriteLine("Yanlış seçim etdiniz.");
            return;
        }
    }
    catch
    {
        Console.WriteLine("Yanlış seçim etdiniz.");
        return;
    }

    Group groupToChangeName = groups[selectedIndex - 1];

    Console.WriteLine($"Hazırki ad: {groupToChangeName.GroupNo}");

    string newGroupNo;
    while (true)
    {
        Console.Write("Yeni GroupNo daxil edin: ");
        newGroupNo = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(newGroupNo))
        {
            Console.WriteLine("Yeni GroupNo boş ola bilməz.");
            continue;
        }

        bool containsLetter = newGroupNo.Any(char.IsLetter);
        bool containsDigit = newGroupNo.Any(char.IsDigit);

        if (!containsLetter || !containsDigit)
        {
            Console.WriteLine("Yeni GroupNo həm hərf, həm də rəqəm daxil etməlidir.");
            continue;
        }

        if (groups.Any(g => g.GroupNo == newGroupNo))
        {
            Console.WriteLine("Bu adda qrup artıq mövcuddur!");
            continue;
        }

        break;
    }

    groupToChangeName.GroupNo = newGroupNo;
    Console.WriteLine("GroupNo uğurla dəyişdirildi.");
}

void ShowGroupStudents(List<Group> groups)
{
    while (true)
    {
        Console.WriteLine("Hansı qrupun məlumatını görmək istəyirsiniz? Seçin:");

        for (int i = 0; i < groups.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {groups[i].GroupNo}");
        }

        Console.Write("Qrup: ");
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Seçim boş ola bilməz. Zəhmət olmasa düzgün bir ədəd daxil edin.");
            continue;
        }

        try
        {
            int seeGroup = Convert.ToInt32(input) - 1;

            if (seeGroup < 0 || seeGroup >= groups.Count)
            {
                Console.WriteLine("Yanlış seçim! Siyahıdakı nömrələrdən birini daxil edin.");
                continue;
            }

            Group selectedGroupStudents = groups[seeGroup];

            Console.WriteLine($"\n\"{selectedGroupStudents.GroupNo}\" qrupundakı tələbələr:");

            if (selectedGroupStudents.Students.Count == 0)
            {
                Console.WriteLine("Bu qrupda hələ tələbə yoxdur.");
            }
            else
            {
                foreach (var s in selectedGroupStudents.Students)
                {
                    s.GetInfo();
                }
            }

            break;
        }
        catch (FormatException)
        {
            Console.WriteLine("Zəhmət olmasa yalnız ədəd daxil edin.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Xəta baş verdi: {ex.Message}");
        }
    }
}

void GetAllStudents(List<Group> groups)
{
    foreach (var group in groups)
    {
        foreach (var student in group.Students)
        {
            student.GetInfo();
        }
    }
}

void CreateStudent(List<Group> groups)
{
    string guaranteedInput;

    while (true)
    {
        try
        {
            Console.WriteLine("Telebenin Adi:");
            string name = Console.ReadLine();

            Console.WriteLine("Telebenin Soyadi:");
            string surname = Console.ReadLine();

            Console.WriteLine("Telebeni elave edeceyiniz qrupu secin:");
            for (int i = 0; i < groups.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {groups[i].GroupNo}");
            }

            Console.Write("Grup: ");
            int chooseGroup = Convert.ToInt32(Console.ReadLine()) - 1;

            if (chooseGroup < 0 || chooseGroup >= groups.Count)
            {
                Console.WriteLine("Yanlis grup secimi!");
                continue;
            }

            Group selectedGroup = groups[chooseGroup];

            Console.WriteLine("Guaranteed: ");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            Console.WriteLine("0. Ana menyuya qayit");
            Console.Write("Secim: ");

            guaranteedInput = Console.ReadLine();
            StudentTypeEnum studentType;

            if (guaranteedInput == "0")
                break;

            switch (guaranteedInput)
            {
                case "1":
                    studentType = StudentTypeEnum.Guaranteed;
                    break;
                case "2":
                    studentType = StudentTypeEnum.NotGuaranteed;
                    break;
                default:
                    Console.WriteLine("Secim Yanlisdir!");
                    continue;
            }

            Student student = new Student(name, surname, selectedGroup, studentType);
            selectedGroup.Add(student);

            Console.WriteLine("Telebe ugurla elave edildi.");
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Xeta: {ex.Message}");
        }
    }
}






