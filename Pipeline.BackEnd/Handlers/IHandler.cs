using Pipeline.BackEnd.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pipeline.BackEnd.Handlers
{
    public interface IHandler<T, TResponse> where T : IRequest<TResponse>
    {
        Task<TResponse> Handle(T request, System.Threading.CancellationToken cancellationToken = default);
    }

    public interface IHandler<T> where T : IRequest
    {
        Task Handle(T request, System.Threading.CancellationToken cancellationToken = default);
    }

    public interface ISynchronousHandler<T, TResponse> where T : IRequest, IRequest<TResponse>
    {
        TResponse Handle(T request);
    }
}
