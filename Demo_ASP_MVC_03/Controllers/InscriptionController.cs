using Demo_ASP_MVC_03.Data;
using Demo_ASP_MVC_03.Data.Entities;
using Demo_ASP_MVC_03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Demo_ASP_MVC_03.Controllers
{
    public class InscriptionController : Controller
    {
        [ViewData]
        public string Title { get; set; }

        private IEnumerable<SelectListItem> GetSelectListItems()
        {
            return FakeDB.GetPersonRole().Select(
                pr => new SelectListItem(pr.Name, pr.Id.ToString())
            );
        }

        public IActionResult Form()
        {
            Title = "Formulaire d'inscription";
            ViewData["PersonRoles"] = GetSelectListItems();

            //return View("Form_HtmlHelper");
            return View("Form_TagHelper");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Form(InscriptionDataViewModel inscriptionData)
        {
            if(!ModelState.IsValid)
            {
                Title = "Formulaire invalide";
                ViewData["PersonRoles"] = GetSelectListItems();

                //return View("Form_HtmlHelper");
                return View("Form_TagHelper");
            }

            PersonRole personRole = FakeDB.GetPersonRoleById((int)inscriptionData.PersonRoleId);

            FakeDB.AddInscription(new Data.Entities.Inscription()
            {
                Email = inscriptionData.Email,
                Firstname = inscriptionData.Firstname,
                Lastname = inscriptionData.Lastname,
                NbGuest = (int)inscriptionData.NbGuest,
                PhoneNumber = inscriptionData.PhoneNumber,
                SpamOk = (bool)inscriptionData.SpamOk,
                PersonRole = personRole,
            });

            // Transite de donnée avec la redirection
            TempData["Name"] = inscriptionData.Firstname + " " + inscriptionData.Lastname;

            return RedirectToAction(nameof(Success));
        }

        public IActionResult Success()
        {
            if (!TempData.ContainsKey("Name"))
            {
                return RedirectToAction("Index", "Home");
            }

            Title = "Inscription validé";

            return View();
        }
    }
}
