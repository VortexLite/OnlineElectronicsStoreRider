using Microsoft.AspNetCore.Identity;

namespace OnlineElectronicsStore.Domain.Entity;

public class Role : IdentityRole
{ 
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<User> Users { get; set; }
    public List<UserRole> UserRoles { get; set; }
}

