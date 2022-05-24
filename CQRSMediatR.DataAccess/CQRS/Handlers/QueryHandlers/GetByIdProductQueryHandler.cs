using CQRSMediatR.DataAccess.CQRS.Queries.Request;
using CQRSMediatR.DataAccess.CQRS.Queries.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSMediatR.DataAccess.CQRS.Handlers.QueryHandlers
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            using(ApplicationDbContext context = new ApplicationDbContext())
            {
                var result = await context.Products.FirstOrDefaultAsync(x => x.Id == request.Id);
                return result != null ? new GetByIdProductQueryResponse
                {
                    Id = result.Id,
                    CreateTime = result.CreateTime,
                    Name = result.Name,
                    Price = result.Price,
                    Quantity = result.Quantity
                } : new GetByIdProductQueryResponse();
                 
            }
        }
    }
}
