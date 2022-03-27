namespace MinimalLogin.Users;

public class User
{
    public string Id { get; set; }
    public string Name { get; set; }
    public DateTime Birthday { get; set; }
    public string Gender { get; set; }
    public string PreferedProgramingLanguage { get; set; }

    public string UserName { get; set; }
    public string Password { get; set; }

    public User(string id, string name, DateTime birthday, string gender, string preferedProgramingLanguage, string userName, string password)
    {
        Id = id;
        Name = name;
        Birthday = birthday;
        Gender = gender;
        PreferedProgramingLanguage = preferedProgramingLanguage;
        UserName = userName;
        Password = password;
    }

    public User(string name, DateTime birthday, string gender, string preferedProgramingLanguage, string userName, string password)
    {
        Name = name;
        Birthday = birthday;
        Gender = gender;
        PreferedProgramingLanguage = preferedProgramingLanguage;
        UserName = userName;
        Password = password;
    }
}
