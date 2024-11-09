using backend.data.entities;

namespace backend.data;

public class BackendSingletonDb
{
    private static BackendSingletonDb _instance;
    public List<Polls> Polls { get; set; }
    public List<Votes> Votes { get; set; }

    private BackendSingletonDb()
    {
        Polls = new List<Polls>();
        Votes = new List<Votes>();
    }

    public static BackendSingletonDb GetInstance()
    {
        if (_instance == null)
        {
            _instance = new BackendSingletonDb();
        }
        return _instance;
    }
}