namespace AvaloniaApplication1;

public class User{
    public int id { get; set; }
    public string username { get; set; }
    public bool adult { get; set; }

    public User(int id, string username, bool adult){
        this.id = id;
        this.username = username;
        this.adult = adult;
    }
}