using Demo_ASP_MVC_03.Data.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo_ASP_MVC_03.Models
{
    public class InscriptionDataViewModel
    {
        [Required(ErrorMessage = "Votre courriel est necessaire. Merci")]
        [EmailAddress(ErrorMessage = "Vous avez mal saisi votre courriel.")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Courriel")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Votre prénom est requis")]
        [DataType(DataType.Text)]
        [DisplayName("Prénom")]
        public string? Firstname { get; set; }

        [Required(ErrorMessage = "Votre nom de famille est requis")]
        [DataType(DataType.Text)]
        [DisplayName("Nom de famille")]
        public string? Lastname { get; set; }

        [Required(ErrorMessage = "Le role est requis")]
        [DisplayName("Role")]
        public int? PersonRoleId { get; set; }

        [Phone(ErrorMessage = "Format invalide")]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Numero du téléphone portable")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Le nombre de personnes est requis")]
        [Range(1, 10, ErrorMessage = "De 1 à 10 personnes uniquement.")]
        [DisplayName("Nombre de personne")]
        public int? NbGuest { get; set; }

        [Required(ErrorMessage = "Nous devons savoir si vous aimez les spam.")]
        [DisplayName("S'inscrire à la newsletter - Promis pas de spam ♥")]
        public bool SpamOk { get; set; }
    }
}
