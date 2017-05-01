namespace Comforthuse.Database
{
    public interface IDbEmployee
    {
        void InsertCase();
        void GetAllCases();
        bool GetNextCaseId();
    }
}
