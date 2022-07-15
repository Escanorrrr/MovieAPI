using Entity.Abstract;

namespace Entity;

public class Login:IEntity
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}