using CQRS_Lib.CQRS.Commands;
using CQRS_Lib.CQRS.Queries;
using CQRS_Lib.Data.Models;
using CQRS_Lib.Reps;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Test.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ItemsController(IItemsRepo _repo , IMediator _mediator) : ControllerBase
	{
       

        [HttpGet]
		public async Task<IActionResult> GetItems()
		{
			//return Ok(_repo.GetItems());
			var result = await _mediator.Send(new GetAllItemsQuery());
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> InsertItem(Items item)
		{
			//_repo.InsertItem(item);

			//return Ok(item);

			var result = await _mediator.Send(new InsertItemCommand(item));
			return Ok(result);
		}

	}
}
