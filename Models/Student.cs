using Deneme;

public class Student
{
    public string _name;
    public string _surname;

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            value = value.Trim();
            bool hasDigit = false;

            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsDigit(value[i]))
                {
                    throw new Exception("Adinizda reqem ola bilmez!");

                    hasDigit = true;
                }
            }



            if (value.Length >= 3 && !hasDigit)
            {
                _name = value;
                Console.WriteLine($"{value}");
            }
            else if (!hasDigit)
            {
                throw new Exception("Adiniz 3 herfden qisa olabilmez!");

            }
        }
    }
    public string Surname
    {
        get
        {
            return _surname;
        }
        set
        {
            value = value.Trim();
            bool hasDigit = false;

            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsDigit(value[i]))
                {
                    throw new Exception("Soyadinizda reqem ola bilmez!");

                    hasDigit = true;
                }
            }



            if (value.Length >= 3 && !hasDigit)
            {
                _surname = value;
                Console.WriteLine($"{value}");
            }
            else if (!hasDigit)
            {
                throw new Exception("Soyadiniz 3 herfden qisa ola bilmez!");
            }
        }
    }
    public Group Group { get; set; }
    public StudentTypeEnum Type { get; set; }

    public Student(string name, string surname, Group group, StudentTypeEnum type)
    {
        Name = name;
        Surname = surname;
        Group = group;
        Type = type;
    }

    public void GetInfo()
    {
        Console.WriteLine($"Ad: {Name}, Soyad: {Surname}, Qrup: {Group.GroupNo}, Tip: {Type}");
    }
}