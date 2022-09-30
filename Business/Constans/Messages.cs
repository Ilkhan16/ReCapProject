namespace Business.Constans;

public static class Messages
{
    #region CarMessages
    public static string Listed = "ID listed.";
    public static string CarAdded = "Car added.";
    public static string CarNameInvalid = "Car name is invalid!!";
    public static string CarUpdated = "Car updated.";
    public static string CarRemoved = "Car removed!";
    public static string CarsListed = "Cars listed";
    #endregion

    #region BrandMessages
    public static string BrandAdded = "Brand added.";
    public static string BrandUpdated = "Brand updated.";
    public static string BrandRemoved = "Brand removed!";
    public static string BrandListed = "Brands listed";
    #endregion

    #region ColorMessages
    public static string ColorAdded = "Color added.";
    public static string ColorUpdated = "Color updated.";
    public static string ColorRemoved = "Color removed!";
    public static string ColorListed = "Colors listed";
    #endregion

    #region UserMessages
    public static string UserAdded = "User added.";
    public static string UserUpdated = "User updated.";
    public static string UserRemoved = "User removed!";
    public static string UserListed = "Users listed";
    #endregion

    #region CustomerMessages
    public static string CustomerAdded = "Customer added.";
    public static string CustomerUpdated = "Customer updated.";
    public static string CustomerRemoved = "Customer removed!";
    public static string CustomerListed = "Customers listed";
    #endregion

    #region RentalMessages
    public static string RentalAdded = "Rental added.";
    public static string RentalNotAdded = "You need to deliver the car!!!";
    public static string RentalUpdated = "Rental updated.";
    public static string RentalRemoved = "Rental removed!";
    public static string RentalListed = "Rentals listed";
    #endregion

    #region CarImageMessages
    public static string CarImagesAdded = "Car Image added.";
    public static string CarImagesRemoved = "Car Image removed.";
    public static string CarImagesUpdated = "Car Image updateed.";
    public static string CarImagesListed = "Car Image listed.";
    public static string CarImageCountExceeded = "The car cannot have more than 5 pictures.";
    #endregion

    #region AuthMessages
    public static string UserNotFound = "User not found";
    public static string PasswordError = "Incorrect username and/or password. Please try again.";
    public static string SuccessfulLogin = "Successfully logged in.";
    public static string UserRegistered = "Successfully registered";
    public static string AccessTokenCreated = "Token Created";
    public static string UserAlreadyExists = "User is already registered, Please enter a different Mail";
    public static string AuthorizationDenied = "You do not have the required permission";
    public static string CarNameAlreadyExists = "Car name already in use, enter a different name"; 
    #endregion
}