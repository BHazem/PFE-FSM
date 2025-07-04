using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
	[AllowAnonymous]
	[Route("api/[Controller]/[action]")]
	[ApiController]
	public class PrescriptionMarketplaceController : ControllerBase
	{

		// GET api/saveDrugPharmacy
		[HttpGet]
		public IActionResult savedrugPharmacy()
		{
			return Ok(core.Handlers.Scripts.LoadDrugPharmacyData());
		}

		// GET api/saveDrugs
		[HttpGet]
		public IActionResult savedrugs()
		{
			return Ok(core.Handlers.Scripts.LoadDrugsData());
		}

		// GET api/Categories
		[HttpGet]
		public IActionResult GetCategories()
		{
			return Ok(core.Handlers.Category.GetCategories());
		}

		// GET api/Categories
		[HttpGet]
		public IActionResult GetPharmacyById(int id_Pharmacy)
		{
			return Ok(core.Handlers.Pharmacy.GetpharmacieByID(id_Pharmacy));
		}

		// GET api/Categories
		[HttpGet]
		public IActionResult GetDrugByID(int id_Drug)
		{
			return Ok(core.Handlers.Drug.GetDrugsByID(id_Drug));
		}

		// GET api/SearchDrug/5
		[HttpGet]
		public IActionResult GetdDrugs(string drug_name)
		{
			return Ok(core.Handlers.Drug.GetDrugs(drug_name));
		}

		// GET api/SearchDrug/5
		[HttpGet]
		public IActionResult GetCategoryByID(int id_categorie)
		{
			return Ok(core.Handlers.Category.GetCategorieByID(id_categorie));
		}

		// GET api/CategoryDrugs/5
		[HttpGet]
		public ActionResult GetDrugsByCategories(int id_category)
		{
			return Ok(core.Handlers.Drug.GetDrugsByCategorie(id_category));
		}

		// GET api/DrugPharmacies/5
		[HttpGet]
		public ActionResult Getpharmacies(int id_drug)
		{
			return Ok(core.Handlers.Pharmacy.Getpharmacies(id_drug));
		}

		// GET api/DrugPharmacies/5
		[HttpGet]
		public ActionResult GetDrugPharmacyByID(int id_drug,int id_pharmacy)
		{
			return Ok(core.Handlers.Pharmacy.GetDrugPharmacyByID(id_drug,id_pharmacy));
		}

		// GET api/DrugsPharmacies/5
		[HttpGet]
		public IActionResult GetDrugsPharmacies([FromQuery] int[] ids)
		{
			return Ok(core.Handlers.Pharmacy.GetDrusPharmacies(ids.ToList()));
		}

		// GET api/DrugsPharmacies/5
		[HttpGet]
		public IActionResult GetDrusPharmaciesBYID([FromQuery] int[] ids , int id_pharmacy2)
		{
			return Ok(core.Handlers.Pharmacy.GetDrusPharmaciesBYID(ids.ToList(), id_pharmacy2));
		}


		[HttpGet]
		public IActionResult SendEmail(string email )
		{
			return Ok(core.Handlers.Email.sendEmail(email));
		}

		[HttpGet]
		public IActionResult convertPdf()
		{
			return Ok(core.Handlers.Email.CreatePDF());
		}

		// POST api/savePrescription
		[HttpPost]
		public ActionResult Post(string patient_name,string pharmacie_name,[FromQuery] int[] ids,string email)
		{
			return Ok(core.Handlers.Prescription.Insert(patient_name, pharmacie_name, ids.ToList(),email));
		}


	}
}
