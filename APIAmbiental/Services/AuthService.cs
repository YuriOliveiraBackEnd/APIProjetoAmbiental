using APIAmbiental.Models;

namespace APIAmbiental.Services
{
    public class AuthService : IAuthService
    {
        private List<UserModel> _users = new List<UserModel>
                {
                    new UserModel { UserId = 1, Username = "Yuri", Password = "pass123", Role = "Adm" },
                    new UserModel { UserId = 2, Username = "Leandro", Password = "pass123", Role = "user" },
                    new UserModel { UserId = 3, Username = "Matheus", Password = "pass123", Role = "user" },
                    new UserModel { UserId = 4, Username = "Felipe", Password = "pass123", Role = "user" },
                    new UserModel { UserId = 5, Username = "Isadora", Password = "pass123", Role = "Adm" },
                    new UserModel { UserId = 6, Username = "Marcos", Password = "pass123", Role = "user" },
                    new UserModel { UserId = 7, Username = "Rogerio", Password = "pass123", Role = "Adm" }
                };


        public UserModel Authenticate(string username, string password)
        {
            // Aqui você normalmente faria a verificação de senha de forma segura
            return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
