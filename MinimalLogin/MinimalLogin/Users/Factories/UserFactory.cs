using MinimalLogin.Users.InputModel;

namespace MinimalLogin.Users.Factories;

public class UserFactory
{
    public static User DefaultFactory(UserInputModel userInputModel)
    {
        return new User( 
            userInputModel.Name,
            userInputModel.Birthday,
            userInputModel.Gender,
            userInputModel.PreferedProgramingLanguage,
            userInputModel.UserName,
            userInputModel.Password);
    }
}

