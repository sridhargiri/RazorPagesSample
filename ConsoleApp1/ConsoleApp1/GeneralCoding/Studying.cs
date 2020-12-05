/// <summary>
/// Stores signatures of various important methods related to the site.
/// </summary>
public interface ISiteInterface
{
};

/// <summary>
/// Skeleton of the singleton that inherits the interface.if this class is sealed subclass cannot inherit from it
/// </summary>
/// <summary>
/// Sample singleton object.
/// </summary>
public class SiteStructure : ISiteInterface
{
    class Inside : SiteStructure
    {
        public Inside()
        {

        }
    }
    /// <summary>
    /// This is an expensive resource.
    /// We need to only store it in one place.
    /// </summary>
    object[] _data = new object[10];

    /// <summary>
    /// Allocate ourselves.
    /// We have a private constructor, so no one else can.
    /// </summary>
    static readonly SiteStructure _instance = new SiteStructure();

    /// <summary>
    /// Access SiteStructure.Instance to get the singleton object.
    /// Then call methods on that instance.
    /// </summary>
    public static SiteStructure Instance
    {
        get { return _instance; }
    }

    /// <summary>
    /// This is a private constructor, meaning no outsiders have access.
    /// </summary>
    private SiteStructure()
    {
        // Initialize members here.
    }
}

/// <summary>
/// Here is an example class where we use a singleton with the interface.
/// </summary>
class TestClass
{
    /// <summary>
    /// Sample.
    /// </summary>
    public TestClass()
    {
        // Send singleton object to any function that can take its interface.
        SiteStructure site = SiteStructure.Instance;
        CustomMethod(site);
    }

    /// <summary>
    /// Receives a singleton that adheres to the ISiteInterface interface.
    /// </summary>
    private void CustomMethod(ISiteInterface interfaceObject)
    {
        // Use the singleton by its interface.
    }
}