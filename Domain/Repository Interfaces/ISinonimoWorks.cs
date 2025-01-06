using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository_Interfaces
{
    public interface ISinonimoWorks
    {
        Task<bool> SaveCHangesAsync(CancellationToken cancellationToken = default);
    }
}
