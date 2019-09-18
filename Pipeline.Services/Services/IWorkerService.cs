using System;
using System.Collections.Generic;
using System.Text;

namespace Pipeline.Services.Services
{
    public interface IWorkerService
    {
        System.Threading.Tasks.Task ExecuteAsync(System.Threading.CancellationToken cancellationToken);
    }
}
