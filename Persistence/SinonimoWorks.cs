using System;
using Domain.Repository_Interfaces;

namespace Persistence
{
    internal sealed class SinonimoWorks : ISinonimoWorks
    {
        private readonly SinonimoContext _dbcontext;

        public SinonimoWorks(SinonimoContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<bool> SaveCHangesAsync(CancellationToken cancellationToken = default)
        {
            return (await _dbcontext.SaveChangesAsync() >= 0);
        }
    }
}
