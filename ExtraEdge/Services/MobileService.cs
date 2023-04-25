using ExtraEdge.Models;
using ExtraEdge.Repositories;

namespace ExtraEdge.Services
{
    public class MobileService:IMobileService
    {
        private readonly IMobileRepository repo;

        public MobileService(IMobileRepository repo)
        {
            this.repo = repo;
        }

        public int AddMobile(Mobile mobile)
        {
            return repo.AddMobile(mobile);
        }

        public int Deletemobile(int id)
        {
            return repo.Deletemobile(id);
        }

        public Mobile GetMobilebyId(int id)
        {
            return repo.GetMobilebyId(id);
        }

        public IEnumerable<Mobile> GetMobiles()
        {
            return repo.GetMobiles();
        }

        public int Updatemobile(Mobile mobile)
        {
            return repo.Updatemobile(mobile);
        }
    }
}
