using CarrierRating.Domain.DTO;
using CarrierRating.Service.Service.Interfaces;
using CarrierRating.WebApplication.Models.ViewModels;
using System;
using System.Web.Mvc;

namespace CarrierRating.WebApplication.Controllers
{
    [Authorize]
    public class CarrierController : BaseController
    {
        private ICarrierService _carrierService;
        public CarrierController(ICarrierService carrierService)
        {
            _carrierService = carrierService;
        }

        private CarrierDTO ConvertToCarrierDTO(CarrierViewModel carrierViewModel)
        {
            var carrierDTO = new CarrierDTO(carrierViewModel.Id);
            carrierDTO.EIN = carrierViewModel.EIN;
            carrierDTO.FirstName = carrierViewModel.FirstName;
            carrierDTO.LastName = carrierViewModel.LastName;
            carrierDTO.Address = carrierViewModel.Address;
            return carrierDTO;
        }

        public ActionResult Index()
        {
            var carriers = _carrierService.GetAll();
            var carrierViewModel = new CarrierViewModel();
            carrierViewModel.SetCarriersList(carriers);
            return View(carrierViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CarrierViewModel carrierViewModel)
        {
            try
            {
                var carrierDTO = ConvertToCarrierDTO(carrierViewModel);
                _carrierService.Create(carrierDTO);
                TempData["AlertSuccess"] = "Operation Done!";
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError("CustomError", e.Message);
                return View();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            var entity = _carrierService.GetById(id);
            var carrierViewModel = new CarrierViewModel();
            carrierViewModel.MapperCarrierDTO(entity.GetDTO());
            return View(carrierViewModel);
        }

        [HttpPost]
        public ActionResult Edit(CarrierViewModel carrierViewModel)
        {
            try
            {
                var carrierDTO = ConvertToCarrierDTO(carrierViewModel);
                _carrierService.Update(carrierDTO);
                TempData["AlertSuccess"] = "Operation Done!";
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError("CustomError", e.Message);
                return View();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            try
            {
                _carrierService.Delete(id);
                TempData["AlertSuccess"] = "Operation Done!";
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError("CustomError", e.Message);
            }
            return RedirectToAction("Index");
        }
    }
}