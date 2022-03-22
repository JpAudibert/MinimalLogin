namespace MinimalLogin.Users;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Birthday { get; set; }
    public string Gender { get; set; }
    public string PreferedProgramingLanguage { get; set; }

    public User(int id, string name, DateTime birthday, string gender, string preferedProgramingLanguage)
    {
        Id = id;
        Name = name;
        Birthday = birthday;
        Gender = gender;
        PreferedProgramingLanguage = preferedProgramingLanguage;
    }

}
