using Infrastructure.SqlServer;
using Mapster;

namespace MapsterApp
{
    public class RegisterMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UserModel, UserDto>()
                .Map(x => x.FullName, src => src.LastName + " " + src.FirstName);
        }
    }
}
