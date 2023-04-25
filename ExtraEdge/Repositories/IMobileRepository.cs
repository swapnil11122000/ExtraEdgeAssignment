using ExtraEdge.Models;

namespace ExtraEdge.Repositories
{
    public interface IMobileRepository
    {
        IEnumerable<Mobile> GetMobiles();
        Mobile GetMobilebyId(int id);
        int AddMobile(Mobile mobile);
        int Updatemobile(Mobile mobile);
        int Deletemobile(int id);
    }
}
