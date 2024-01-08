namespace Imagist_Library.Model;

public class User
{
    public long UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ProfileId { get; set; }

    //relation
    public List<Photo> Photos { get; set; }

    public List<Album> Albums { get; set; }

    public User()
    {
        
    }

    public User(long userId, string username, string email,string password,string profileId)
    {
        UserId = userId;
        Username = username;
        Email = email;
        Password = password;
        ProfileId = profileId;
    }
}