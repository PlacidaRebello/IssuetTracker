using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IStatusEngine
    {
        int CreateStatus(Status status);
        Status GetStatusByName(string statusName);
        bool RemoveStatus(Status status);
        bool StatusExists(int id);

        Status GetStatus(int id);
        bool EditStatus(Status newStatus);
    }
}
