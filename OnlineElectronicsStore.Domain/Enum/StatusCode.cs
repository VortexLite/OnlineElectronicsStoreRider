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
    
    //Producer
    ProducerElementNotFound = 50,
    
    //Image
    ImageElementNotFound = 60,
    
    //Authenticate
    AuthenticateUserNotFound = 70,
    
    //Profile
    ProfileUserNotFound = 80,
    
    //CategoryCharacteristic
    CategoryCharacteristicElementNotFound = 90,
    
    //ProductCharacteristic
    ProductCharacteristicElementNotFound = 100,
    
    //ShoppingCartItem
    ShoppingCartItemElementNotFound = 110,
    
    //All
    OK = 200,
    InternalServerError = 500
}