using AutoMapper;
using Domain.Entities;
using Models.DTOBoleto;
using Models.RepositoryManager;
using Service.Abstraction;

namespace Services
{
    internal sealed class BoletoService : IBoletoService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        
        public BoletoService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager ?? throw new ArgumentNullException(nameof(repositoryManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<bool> BoletoExistAsync(string boletoId, CancellationToken cancellationToken = default)
        {
           return await _repositoryManager.Boletos.BoletoExistAsync(boletoId,cancellationToken);
        }

        public async Task<IEnumerable<BoletoDTO>> BoletoListAsync(CancellationToken cancellationToken = default)
        {
            var boletos = await _repositoryManager.Boletos.GetAllAsync(cancellationToken).ConfigureAwait(false);
            return _mapper.Map<IEnumerable<BoletoDTO>>(boletos);

        }

        public async Task<BoletoDTO> CreateAsync(BoletoForCreateDTO boloetoForCreate, CancellationToken cancellationToken = default)
        {
            var finalBoleto = _mapper.Map<Boletos>(boloetoForCreate);

            await _repositoryManager.Boletos.Insert(finalBoleto);

            await _repositoryManager.Works.SaveCHangesAsync(cancellationToken);

            return _mapper.Map<BoletoDTO>(finalBoleto);
        }

        public async Task<bool> DeleteAsync(string boletoId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<BoletoDTO> GetByNameAsync(string boletoId, CancellationToken cancellationToken = default)
        {
            var juego = await _repositoryManager.Boletos.GetByIdAsync(boletoId, cancellationToken).ConfigureAwait(false);

            return _mapper.Map<BoletoDTO>(juego);
        }

        public async Task<BoletoDTO> UpdateAsync(string boletoId, BoletoForUpdateDTO boletoForUpdate, CancellationToken cancellationToken = default)
        {
           var boletoEntity = await _repositoryManager.Boletos.GetByIdAsync(boletoId,cancellationToken).ConfigureAwait(false);

            _mapper.Map(boletoForUpdate, boletoEntity);

            await _repositoryManager.Works.SaveCHangesAsync(cancellationToken).ConfigureAwait(false);

            var boleto = await _repositoryManager.Boletos.GetByIdAsync(boletoId, cancellationToken).ConfigureAwait(false);

            return _mapper.Map<BoletoDTO>(boleto);


        }
    }
}
