using CQRSMediatR.DataAccess.CQRS.Commands.Request;
using CQRSMediatR.DataAccess.CQRS.Commands.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSMediatR.DataAccess.CQRS.Handlers.CommandHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            using(ApplicationDbContext context = new ApplicationDbContext())
            {
                var deleteProduct = context.Products.FirstOrDefault(p => p.Id == request.Id);
                context.Products.Remove(deleteProduct);
                await context.SaveChangesAsync();
                return new DeleteProductCommandResponse()
                {
                    IsSuccess = true
                };
            }
        }
    }
}
