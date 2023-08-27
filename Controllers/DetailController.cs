using AgricultDetailMarket.Data.Interfaces;
using AgricultDetailMarket.Models;
using AgricultDetailMarket.Models.ViewModels;
using AgricultDetailMarket.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgricultDetailMarket.Controllers
{
    public class DetailController : Controller
    {
        private readonly IDetailService _serviceDetail;

        public DetailController(IDetailService service)
        {
            _serviceDetail = service;
        }

   

        [HttpGet]
        public IActionResult GetAllDetails()
        {
            var response = _serviceDetail.GetDetails();
            if(response.StatusCode == Models.Enum.StatusCode.Ok)
            {
               return View(response.Data);
            }
            return View();
        }

        public async Task<IActionResult> GetDetail(int id)
        {
            var response = await _serviceDetail.GetDetail(id);
            if(response.StatusCode == Models.Enum.StatusCode.Ok) 
            {
                return View(response.Data);
            }
            return View();
        }

        public IActionResult Delete() => View();

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _serviceDetail.DeleteDetail(id);
            if(response.StatusCode == Models.Enum.StatusCode.Ok)
            {
                return RedirectToAction("GetAllDetails");
            } 
            return View("Error", $"{response.Description}");
        }

        [HttpGet]
        public async Task<IActionResult> SaveDetail(int id)
        {
            if(id == 0)
            {
                return View();
            }
            var response = await _serviceDetail.GetDetail(id);
            if(response.StatusCode == Models.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }
            ModelState.AddModelError("", response.Description);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveDetail(DetailViewModel model)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                if(model.Id == 0)
                {
                  await  _serviceDetail.CreateDetail(model);
                }
                else
                {
                    await _serviceDetail.UpdateDetail(model.Id, model);
                }
            }
            return RedirectToAction("GetAllDetails");
        }

        public IActionResult CreateDetail() => View();

        [HttpPost]
        public async Task<IActionResult> CreateDetail(DetailViewModel model)
        {
            await _serviceDetail.CreateDetail(model);
            return RedirectToAction("GetAllDetails");
        }



        //========= 1 section ============================ Akkumulators & Tires =========================
        
        [HttpGet]
        public  IActionResult Accumulators()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public IActionResult Tires()
        {
            GetAllDetails();
            return View();
        }

        //=========== 2 section ======================== Hydraulics =====================================

        [HttpGet]
        public async Task<IActionResult> Pumps()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> HighPressureHoses()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Nozzles()
        {
            GetAllDetails();
            return View();
        }

        //============== 3 section ================================ Truck Parts ========================

        [HttpGet]
        public async Task<IActionResult> Gaz53()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Zil5103_Bull()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Zil130()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Paz3205()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Pts4()
        {
            GetAllDetails();
            return View();
        }

        //=================== 4 section ============================== Harvester Parts ==================

        [HttpGet]
        public async Task<IActionResult> GrainCleaningCar()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> HarvesterEnisey()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> HarvesterNiva()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> HarvesterPalesse()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> OtherHarvesters()
        {
            GetAllDetails();
            return View(); 
        }

        //================== 5 section ================== PotatoHarvestingMachines ======================

        [HttpGet]
        public async Task<IActionResult> PotatoHarvestingMachines()
        {
            GetAllDetails();
            return View();
        }

        //================== 6 section ================== ForageHarvestingMadhines ======================

        [HttpGet]
        public async Task<IActionResult> Kir()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SilageHarvestingMachines()
        {
            GetAllDetails();
            return View();
        }

        //================== 7 section ===================== SoilProcessingMachines ======================

        [HttpGet]
        public async Task<IActionResult> Harrow()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Cultivator()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Plough()
        {
            GetAllDetails();
            return View();
        }

        //================ 8 section ====================== HayHarvestingMachines ======================

        [HttpGet]
        public async Task<IActionResult> Rake()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MowerKsf()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MowerKps()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MowerKsd()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MowerLisichki()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MowerKrn()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Baler()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Stackers()
        {
            GetAllDetails();
            return View();
        }

        //==================== 9 section ====================== Seeder Parts ===========================

        [HttpGet]
        public async Task<IActionResult> Seeder()
        {
            GetAllDetails();
            return View();
        }

        //================== 10 section ===================== Tractor Parts ==================

        [HttpGet]
        public async Task<IActionResult> D75()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Mtz1221()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Mtz320()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> OthersMtz()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> T150_Smd60()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> T16_25_40()
        {
            GetAllDetails();
            return View();
        }

        //==================== 11 section =========== Pistons Group ================

        [HttpGet]
        public async Task<IActionResult> Liners()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Crankshafts()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PistonsGroup()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GasketsGbc()
        {
            GetAllDetails();
            return View();
        }

        //=================== 12 section ============== Kits =====================

        [HttpGet]
        public async Task<IActionResult> Kits()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Belts()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> OilSeals()
        {
            GetAllDetails();
            return View();
        }

        //================== 13 section ============== Fuel System =================

        [HttpGet]
        public async Task<IActionResult> Starters()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> FuelSystem()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Turbocompressors()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> FuelAirFilters()
        {
            GetAllDetails();
            return View();
        }

        //=================== 14 section =========== Metal Items ===================

        [HttpGet]
        public async Task<IActionResult> MetalItems()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Segments()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Chain()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Electrodes()
        {
            GetAllDetails();
            return View();
        }

        //============= 15 section ==================== Twine Films ==============

        [HttpGet]
        public async Task<IActionResult> TwineFilms()
        {
            GetAllDetails();
            return View();
        }

        //============ 16 section =================== Headlight ===================

        [HttpGet]
        public async Task<IActionResult> Headlights()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ElectricEquipment()
        {
            GetAllDetails();
            return View();
        }

        //=========== 17 section ==================== GSM ========================

        [HttpGet]
        public async Task<IActionResult> Gsm()
        {
            GetAllDetails();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Electrolyte()
        {
            GetAllDetails();
            return View();
        }

        //=============== 18 section =================== CarTools ================

        [HttpGet]
        public async Task<IActionResult> CarTools()
        {
            GetAllDetails();
            return View();
        }

        //=========================================================================
    }
}
