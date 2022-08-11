using System.ComponentModel.DataAnnotations;

namespace CheckMate_API.Models
{
    /// <summary>
    /// Model Principal de Member.
    /// </summary>
    public class Member
    {
        public int MemberId { get; set; }
        public string Pseudo { get; set; } = String.Empty;
        public string Mail { get; set; } = String.Empty;
        public string PasswordHash { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        private int _Elo;
        public int Elo
        {
            get { return _Elo; }
            set
            {
                if (value == 0)
                { 
                    _Elo = 1200; 
                }
                else
                {
                    _Elo = value;
                }
            }
        }
        public string Token { get; set; } = String.Empty;
        public bool IsAdmin { get; set; }
    }
    /// <summary>
    /// Model de formulaire de création pour les Member.
    /// </summary>
    public class MemberRegisterForm
    {
        [Required]
        public string Pseudo { get; set; }

        [Required]
        [EmailAddress]
        public string Mail { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        public string Gender { get; set; }
        
        [Required]
        public int Elo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Les deux mots de passe doivent correspondre")]
        public string PasswordCheck { get; set; }
    }   
    /// <summary>
    /// Model de formulaire pour la connexion d'un Member.
    /// </summary>
    public class MemberLoginForm
    {
        [Required]
        public string Credentials { get; set; }

        [Required]
        public string Password { get; set; }
    }
}