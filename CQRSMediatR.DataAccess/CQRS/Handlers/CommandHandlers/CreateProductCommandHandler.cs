using CQRSMediatR.DataAccess.CQRS.Commands.Request;
using CQRSMediatR.DataAccess.CQRS.Commands.Response;
using CQRSMediatR.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSMediatR.DataAccess.CQRS.Handlers.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            using(ApplicationDbContext context = new ApplicationDbContext())
            {
                var product = new Product();
                product.Name = request.Name;
                product.Price = request.Price;
                product.Quantity = request.Quantity;
                product.CreateTime = DateTime.Now;
                var result = context.Products.Add(product);
                await context.SaveChangesAsync();
                return new CreateProductCommandResponse
                {
                    IsSuccess = true,
                    ProductId = result.Entity.Id
                };
            }
        }
    }
}
