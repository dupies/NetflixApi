namespace NetflixApi.Domain.Abstractions;

public class BaseErrors
{
    public static Error NotFound = new(
        "Entity.NotFound",
        "The entity with the specified identifier was not found.");

    public static Error AllreadyExists = new(
        "Entity.AllreadyExists",
        "The entity with the specified identifier allready exists.");

    public static Error InvalidCredentials = new(
        "Entity.InvalidCredentials",
        "The provided credentials were invalid.");

    public static Error DeleteConflict = new(
        "Entity.DeleteConflict",
        "Unable to delete entity due to referential integrity constraints.");
}
