using ExtraEdge.Models;
namespace ExtraEdge.Services
{
    public interface IMobileService
    {
        IEnumerable<Mobile> GetMobiles();
        Mobile GetMobilebyId(int id);
        int AddMobile(Mobile mobile);
        int Updatemobile(Mobile mobile);
        int Deletemobile(int id);


    }
}
