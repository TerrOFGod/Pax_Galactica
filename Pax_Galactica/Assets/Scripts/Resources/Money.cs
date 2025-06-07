public class Money : Resource
{
    private static Money instance;
    public static Money Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<Money>();
            }

            return instance;
        }
    }
}