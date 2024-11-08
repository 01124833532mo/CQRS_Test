using CQRS_Lib.CQRS.Commands;
using CQRS_Lib.Data.Models;
using CQRS_Lib.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Lib.CQRS.Handlers
{
	// Ensure InsertItemHandler implements IRequestHandler<InsertItemCommand, Items>
	public class InsertItemHandler : IRequestHandler<InsertItemCommand, Items>
	{
		private readonly AppDbContext _db;

		public InsertItemHandler(AppDbContext db)
		{
			_db = db;
		}

		public async Task<Items> Handle(InsertItemCommand request, CancellationToken cancellationToken)
		{
			await _db.Items.AddAsync(request.Item, cancellationToken);
			await _db.SaveChangesAsync(cancellationToken);
			return request.Item;
		}
	}
}
