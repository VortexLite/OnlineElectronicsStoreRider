﻿namespace OnlineElectronicsStore.Domain.Entity;

public class Role
{ 
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<User> Users { get; set; }
}

