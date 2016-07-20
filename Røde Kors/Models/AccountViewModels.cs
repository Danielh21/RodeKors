using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Røde_Kors.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Fornavn ")]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Efternavn")]
        public string lastName { get; set; }

        [Required]
        public int CPR { get; set; }

        [Display(Name = "C/O")]
        public string CO { get; set; }

        [Display(Name = "Adresse")]
        public string streetAndNumber { get; set; }

        [Display(Name = "Postnumber")]
        public int zipcode { get; set; }

        [Display(Name = "By")]
        public string city { get; set; }

        [Required]
        public int telefon1 { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display (Name = "Er personen en vagtkoordinator?")]
        public bool vagtkoordinator { get; set; }

        [Display (Name ="Er personen uddannet Medic?")]
        public bool medic { get; set; }

        [Display(Name = "Hvilket niveau er personen uddannet på? ")]
        public level levelList { get; set; }

        [Display (Name = "Chauffør")]
        public driverLevels driver { get; set; }


    }

    public class EditViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Fornavn ")]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Efternavn")]
        public string lastName { get; set; }

        [Required]
        public int CPR { get; set; }

        [Display(Name = "C/O")]
        public string CO { get; set; }

        [Display(Name = "Adresse")]
        public string streetAndNumber { get; set; }

        [Display(Name = "Postnumber")]
        public int zipcode { get; set; }

        [Display(Name = "By")]
        public string city { get; set; }

        [Required]
        public int telefon1 { get; set; }

        [Display(Name = "Er personen en vagtkoordinator?")]
        public bool vagtkoordinator { get; set; }

        [Display(Name = "Du er uddannet som: ")]
        public string eduLevel { get; set; }

        [Display(Name = "Chauffør")]
        public string driver { get; set; }


    }
    public enum level
        {
            [Display(Name = "Observatør")]
            Observatør,
            [Display(Name = "Elev")]
            Elev,
            [Display(Name = "Team Samarit")]
            TeamSamarit,
            [Display(Name = "Team Leder 1")]
            TeamLeder1,
            [Display(Name = "Team Leder 2")]
            TeamLeder2,
            [Display(Name = "Team Leder 3")]
            TeamLeder3
        }

    public enum driverLevels
    {
        [Display (Name = "Ikke Chauffør")]
        IkkeChauffør,
        [Display(Name ="Chaffør Normal Bil")]
        Chauffør1,
        [Display(Name = "Chaffør Stor Bil")]
        Chauffør2,
        [Display(Name = "Chaffør Stor Bil + Trailer")]
        Chauffør3,

    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
