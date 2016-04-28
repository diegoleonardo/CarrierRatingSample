using CarrierRating.Domain.DTO;
using CarrierRating.Service.Service.Interfaces;
using CarrierRating.WebApplication.Models.ViewModels;
using System;
using System.Web.Mvc;

namespace CarrierRating.WebApplication.Controllers
{
    [Authorize]
    public class RatingController : BaseController
    {
        private readonly IRatingService _ratingService;
        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        private RatingDTO ConvertToRatingDTO(RatingViewModel ratingViewModel)
        {
            var ratingDTO = new RatingDTO(ratingViewModel.Id);
            ratingDTO.Rate = ratingViewModel.Rate;
            ratingDTO.Description = ratingViewModel.Description;
            ratingDTO.User = base.UserBase;
            ratingDTO.Carrier = _ratingService.GetCarrierById(ratingViewModel.CarrierId);
            return ratingDTO;
        }

        // GET: Rating
        public ActionResult Index()
        {
            var ratingViewModel = new RatingViewModel();
            ratingViewModel.SetCarriersToRatingList(_ratingService.GetCarrierToRating(base.UserBase.GetStringId()));
            ratingViewModel.SetRatingsList(_ratingService.GetRatingByUserId(base.UserBase.GetStringId()));
            return View(ratingViewModel);
        }

        public ActionResult Rating(string carrierId)
        {
            var ratingViewModel = new RatingViewModel();
            ratingViewModel.CarrierRate = _ratingService.GetCarrierById(carrierId).GetDTO();
            ratingViewModel.CarrierId = ratingViewModel.CarrierRate.GetStringId();
            ratingViewModel.CarrierName = ratingViewModel.CarrierRate.GetFullName();
            ratingViewModel.User = base.UserBase.GetDTO();
            ratingViewModel.SetRatingsList(_ratingService.GetRatingByUserId(base.UserBase.GetStringId()));
            return View(ratingViewModel);
        }

        [HttpPost]
        public ActionResult Rating(RatingViewModel ratingViewModel)
        {
            try
            {
                var ratingDTO = ConvertToRatingDTO(ratingViewModel);
                _ratingService.Create(ratingDTO);
                TempData["AlertSuccess"] = "Operation Done!";
            }
            catch(Exception e)
            {
                this.ModelState.AddModelError("CustomError", e.Message);
                return View(ratingViewModel);
            }
            return RedirectToAction("Index");
        }
    }
}