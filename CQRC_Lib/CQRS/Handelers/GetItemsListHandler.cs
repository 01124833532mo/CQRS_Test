using CQRS_Lib.CQRS.Queries;
using CQRS_Lib.Data;
using CQRS_Lib.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Lib.CQRS.Handelers
{
	public class GetItemsListHandler : IRequestHandler<GetAllItemsQuery, List<Items>>
	{
		private readonly AppDbContext _db;

		public GetItemsListHandler(AppDbContext dbContext)
        {
			_db = dbContext;
		}
        public async Task<List<Items>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
		{
			//return await _db.Items.ToListAsync();

			return await Task.FromResult(_db.Items.ToList());
		}
	}
}
