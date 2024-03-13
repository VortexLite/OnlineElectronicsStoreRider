namespace OnlineElectronicsStore.Domain.Enum;

public enum StatusCode
{
    //User
    UserNotFound = 1,
    
    //Category
    CategoryElementsNotFound = 20,
    
    //Navigation
    NavigationElementNotFound = 30,
    
    //Product
    ProductElementNotFound = 40,
    
    //All
    OK = 200,
    InternalServerError = 500
}