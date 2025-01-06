using AutoMapper;
using Domain.Entities;
using Models.DTOJuego;
using Models.RepositoryManager;
using Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class JuegoService : IJuegoService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        
        public JuegoService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<JuegoDTO> CreatedAsync(JuegoForCreateDTO juegoForCreate, CancellationToken cancelToken = default)
        {
            var finalJuego = _mapper.Map<Juegos>(juegoForCreate);

            await _repositoryManager.Juego.Insert(finalJuego);

            await _repositoryManager.Works.SaveCHangesAsync(cancelToken);

            return _mapper.Map<JuegoDTO>(finalJuego);

        }

        public Task<JuegoDTO> DeleteAsync(int Id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<JuegoDTO> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            var juego = await _repositoryManager.Juego.GetByIdAsync(name, cancellationToken);

            return _mapper.Map<JuegoDTO>(juego);
        }

        public async Task<IEnumerable<JuegoDTO>> GetJuegosAsync(CancellationToken cancellationToken = default)
        {
           var juegos = await _repositoryManager.Juego.GetAllAsync(cancellationToken).ConfigureAwait(false);

            return _mapper.Map<IEnumerable<JuegoDTO>>(juegos);

        }

        public async Task<bool> JuegoExistAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _repositoryManager.Juego.JuegosExistAsync(name, cancellationToken);
        }

        public async Task<JuegoDTO> UpdateAsync(string name,JuegoForUpdateDTO juegoForUpdate, CancellationToken cancellationToken = default)
        {
            var juegoEntity = await _repositoryManager.Juego.GetByIdAsync(name, cancellationToken);

            _mapper.Map(juegoForUpdate, juegoEntity);

            await _repositoryManager.Works.SaveCHangesAsync(cancellationToken).ConfigureAwait(false);

            var juego = await _repositoryManager.Juego.GetByIdAsync(name,cancellationToken).ConfigureAwait(false); 
            
            return _mapper.Map<JuegoDTO>(juego);


        }
    }
}
