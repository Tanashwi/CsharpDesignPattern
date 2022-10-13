namespace Singleton
{
  public class Logger
  {
    //This improves singleton behabior
    private static readonly Lazy<Logger> _LazyLogger
    = new Lazy<Logger>(()=> new Logger());
    
    //not needed now with Lazy<T>
    //private static Logger? _instance;

    public static Logger Instance
    {
        get
        {
            return _LazyLogger.Value;
           // if(_instance == null)
            //{
                //_instance = new Logger();
            //}
            //return _instance;
        }
    }
    protected Logger()
    {

    }

    public void Log(string message)
    {
        Console.WriteLine($"Message to Log: {message}");
    }
  }
}
