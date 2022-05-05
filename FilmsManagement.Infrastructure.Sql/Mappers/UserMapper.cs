using FilmsManagement.Domain.Models;
using FilmsManagement.Infrastructure.Sql.DataModels;

namespace FilmsManagement.Infrastructure.Sql.Mappers
{
    public static class UserMapper
    {
        public static User ToDomainModel(this UserModel model)
        {
            return new User
            {
                Id = model.Id,
                Mail = model.Mail,
                Nickname = model.Nickname
            };
        }

        public static UserModel ToSqlModel(this User domain)
        {
            return new UserModel
            {
                Id = domain.Id,
                Mail = domain.Mail,
                Nickname = domain.Nickname
            };
        }
    }
}
