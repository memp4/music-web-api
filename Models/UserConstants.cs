namespace UserSpace.Models;

public class UserConstants
{
    public static List<UserModel> Users = new List<UserModel>()
    {
        new UserModel() {Username = "admin", EmailAddres = "admin@email.com", Password = "12345",
            GivenName = "Name", Surename = "Surename", Role = "user"},
        new UserModel() {Username = "dada", EmailAddres = "dada@email.com", Password = "5555",
            GivenName = "DODO", Surename = "SureDO", Role = "user" }
    };
}