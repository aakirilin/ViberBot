using System.ComponentModel.DataAnnotations;

namespace ViberBot.Models
{
    public class User
    {
        public int id { get; set; }

        [Required]
        [RegularExpression("^\\w+$", ErrorMessage = "Логин может состоять только из букв русского или латинского алфавита.")]
        public string login { get; set; }

        [Required]
        [RegularExpression("^[\\w\\d!]+$", ErrorMessage = "Пароль может состоять только из букв русского или латинского алфавита, цифр и знака восклицания.")]
        public string password { get; set; }

        public UserRole? role { get; set; }

        public string accsesToken { get; set; }

        public User() { }

        public User(string login, string password, UserRole role)
        {
            this.login = login;
            this.role = role;
            this.password = RijndaelAlgorithm.Encrypt(password);
        }

        public User(int id, string login, string password, UserRole role) : this(login, password, role)
        {
            this.id = id;
        }

        public bool EqualPassword(string password)
        {
            var passwordDecrypt = RijndaelAlgorithm.Decrypt(this.password);
            return passwordDecrypt.Equals(password);
        }
    }
}
