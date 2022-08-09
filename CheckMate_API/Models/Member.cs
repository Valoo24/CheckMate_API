using System.ComponentModel.DataAnnotations;

namespace CheckMate_API.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public string Pseudo { get; set; } = String.Empty;
        public string Mail { get; set; } = String.Empty;

        public string PasswordHash { get; set; }

        public DateTime Birthdate { get; set; }

        public string Gender { get; set; }

        public int Elo { get; set; }
        public string Token { get; set; } = String.Empty;


        public bool IsAdmin { get; set; }


    }

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
        public int  Elo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       
       
        // !!! Message d'erreur temporaire !!!
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Les deux mdp doivent correspondre")]
        public string PasswordCheck { get; set; }
    }   


    public class MemberLoginForm
    {
        [Required]
        public string Credentials { get; set; }

        [Required]
        public string Password { get; set; }

    }

}
