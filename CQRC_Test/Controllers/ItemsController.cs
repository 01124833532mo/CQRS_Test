using CQRS_Lib.Data.Models;
using CQRS_Lib.Reps;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Test.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ItemsController(IItemsRepo _repo) : ControllerBase
	{
       

        [HttpGet]
		public async Task<IActionResult> GetItems()
		{
			return Ok(_repo.GetItems());
		}

		[HttpPost]
		public async Task<IActionResult> InsertItem(Items item)
		{
			_repo.InsertItem(item);

			return Ok(item);
		}

	}
}
