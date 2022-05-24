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
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, List<GetAllProductQueryResponse>>
    {
        public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            using(ApplicationDbContext context = new ApplicationDbContext())
            {
                var result = await context.Products.ToListAsync();
                return result.Select(x => new GetAllProductQueryResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreateTime = x.CreateTime,
                    Price = x.Price,
                    Quantity = x.Quantity
                }).ToList();
            }
        }
    }
}
