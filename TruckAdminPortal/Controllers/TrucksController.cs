using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TruckAdminPortal.Data;
using TruckAdminPortal.Models;
using TruckAdminPortal.Models.Entities;

namespace TruckAdminPortal.Controllers
{
    //localhost:xxx/api/trucks
    [Route("api/[controller]")]
    [ApiController]
    public class TrucksController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public TrucksController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            
        }


        [HttpGet]
        public IActionResult GetAllTrucks()
        {
            
            return Ok(dbContext.Trucks.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetTruckById(Guid id)
        {
            var truck = dbContext.Trucks.Find(id);

            if (truck == null)
            {
                return NotFound();
            }

            return Ok(truck);
        }
        [HttpPost]
        public IActionResult AddTruck(AddTruckDto addTruckDto)
        {
            var truckEntity = new Truck()
            {
                Name = addTruckDto.Name,
                LicensePlate = addTruckDto.LicensePlate,
                Supplier = addTruckDto.Supplier,
                InputWeight = addTruckDto.InputWeight,
                ExitWeight = addTruckDto.ExitWeight,
                NetWeight = addTruckDto.NetWeight,
                Amount = addTruckDto.Amount

            };

            dbContext.Trucks.Add(truckEntity);
            dbContext.SaveChanges();

            return Ok(truckEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateTruck(Guid id, UpdateTruckDto updateTruckDto)
        {
            var truck = dbContext.Trucks.Find(id);

            if (truck == null)
            {
                return NotFound();
            }

            truck.Name = updateTruckDto.Name;
            truck.LicensePlate = updateTruckDto.LicensePlate;
            truck.Supplier = updateTruckDto.Supplier;
            truck.InputWeight = updateTruckDto.InputWeight;
            truck.ExitWeight = updateTruckDto.ExitWeight;
            truck.NetWeight = updateTruckDto.NetWeight;
            truck.Amount = updateTruckDto.Amount;

            dbContext.SaveChanges();

            return Ok(truck);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteTruck(Guid id) 
        {
            var truck = dbContext.Trucks.Find(id);

            if (truck is null)
            {
                return NotFound();
            }

            dbContext.Trucks.Remove(truck);

            dbContext.SaveChanges();

            return Ok();

        }
    }
}
