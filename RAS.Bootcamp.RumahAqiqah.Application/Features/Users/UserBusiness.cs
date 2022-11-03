using RAS.Bootcamp.RumahAqiqah.Data.Entities;
namespace RAS.Bootcamp.RumahAqiqah.Application.Features.Users
{
    public interface IUserBusiness
    {
        User Register(User user, Account account);
        User Add(User request);
        void Remove(User request);
        void Update(User request);

    }
    public class UserBusiness
    {

    }
}
