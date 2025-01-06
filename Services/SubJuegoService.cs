using AutoMapper;
using Domain.Entities;
using Models.DTOSubJuego;
using Models.RepositoryManager;
using Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class SubJuegoService : ISubJuegoService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public SubJuegoService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SubJuegoDTO> CreatedAsync(SubJuegoForCreateDTO subJuegoForCreate, CancellationToken cancellationToken = default)
        {
            var finalSubJuego = _mapper.Map<SubJuego>(subJuegoForCreate);

            await _repositoryManager.SubJuegos.Insert(finalSubJuego);

            await _repositoryManager.Works.SaveCHangesAsync(cancellationToken);

            return _mapper.Map<SubJuegoDTO>(finalSubJuego);
        }

        public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<SubJuegoDTO> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            var user = await _repositoryManager.SubJuegos.GetByNameAsync(name, cancellationToken);

            return _mapper.Map<SubJuegoDTO>(user);
        }

        public async Task<IEnumerable<SubJuegoDTO>> GetJuegosAsync(CancellationToken cancellationToken = default)
        {
            var subjuegos = await _repositoryManager.SubJuegos.GetAllAsyc(cancellationToken).ConfigureAwait(false);

            return _mapper.Map<IEnumerable<SubJuegoDTO>>(subjuegos);
        }

        public async Task<bool> SubJuegoExistAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _repositoryManager.SubJuegos.SubJuegoExistAsync(name, cancellationToken);
        }

        public async Task<SubJuegoDTO> UpdateAsync(string name, SubJuegoForUpdateDTO subJuegoForUpdate, CancellationToken cancellationToken = default)
        {
            var subJuegoEntity = await _repositoryManager.SubJuegos.GetByNameAsync(name,cancellationToken).ConfigureAwait(false);

            _mapper.Map(subJuegoForUpdate,subJuegoEntity);

            await _repositoryManager.Works.SaveCHangesAsync(cancellationToken).ConfigureAwait(false);

            var subJuego = await _repositoryManager.SubJuegos.GetByNameAsync(name,cancellationToken)!.ConfigureAwait(false);

            return _mapper.Map<SubJuegoDTO>(subJuego);

        }
    }
}
