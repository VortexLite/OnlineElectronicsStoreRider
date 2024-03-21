namespace OnlineElectronicsStore.Domain.Entity;

public class UserRole
{
    public int Id { get; set; }

    public int IdUser { get; set; }
    public User User { get; set; }

    public int IdRole { get; set; }
    public Role Role { get; set; }
}