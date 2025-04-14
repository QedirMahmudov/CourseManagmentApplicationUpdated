using Deneme;

public class Group
{
    private static List<string> groupNums = new List<string>();

    private string _groupNo;
    private int _limit;
    private bool _isOnline;

    public List<Student> Students { get; set; }

    public CourseCategoryEnum Category { get; set; }

    public string GroupNo
    {
        get => _groupNo;
        set
        {
            if (value.Length <= 3)
            {
                throw new Exception("Qrup adı 3 hərfdən qısa ola bilməz!");
            }

            string groupNum = "";
            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsDigit(value[i]))
                {
                    groupNum += value[i];
                }
            }

            if (groupNums.Contains(groupNum))
            {
                throw new Exception("Bu qrup nömrəsində qrup artıq mövcuddur!");
            }

            _groupNo = value;
            groupNums.Add(groupNum);
        }
    }

    public bool IsOnline
    {
        get => _isOnline;
        set
        {
            _isOnline = value;
            _limit = _isOnline ? 15 : 10;
        }
    }

    public int Limit => _limit;

    public Group(string groupNo, CourseCategoryEnum category, bool isOnline)
    {
        Students = new List<Student>();
        GroupNo = groupNo;
        Category = category;
        IsOnline = isOnline;
    }

    public void Add(Student student)
    {
        if (Students.Count >= Limit)
        {
            Console.WriteLine("Qrup limiti keçildi! Student əlavə etmək mümkün olmadı!");
        }
        else
        {
            Students.Add(student);
        }
    }
}