using CarFleet.BLL.DTO;
using CarFleet.BLL.Responses;
using CarFleet.BLL.Services;
using CarFleet.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarFleet.API.Controllers
{
    [Route("api/vehicle/")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly VehicleService _vehicleService;
        private readonly FirebaseService _firebaseService;

        public VehicleController(VehicleService vehicleService, FirebaseService firebaseService)
        {
            _vehicleService = vehicleService;
            _firebaseService = firebaseService;
        }

        //GET: /get/
        [HttpGet("get")]
        public async Task<IActionResult> GetVehicles()
        {
            List<VehicleDTO> vehicles = await _vehicleService.GetVehicles();
            return Ok(vehicles);
        }

        //GET: /category
        [HttpGet("category")]
        public async Task<IActionResult> GetVehicleCategory(string vehicleId)
        {
            CategoryDTO category =  await _vehicleService.GetCategory(vehicleId);
            return Ok(category);
        }


        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> AddVehicle([FromForm] AddVehicleResponse vehicle)
        {
            //var identity = HttpContext.User.Identities.FirstOrDefault();
            //var role = identity.Claims.FirstOrDefault(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;

            //if (role != "Admin")
            //{
            //    return Unauthorized("You don't have to correct permissons to do this.");
            //}

            //await _vehicleService.Add(vehicle);

            return Ok("Not Implemented");
        }
    }
}
