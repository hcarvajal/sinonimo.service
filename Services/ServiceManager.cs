using System;
using Models.RepositoryManager;
using Service.Abstraction;
using AutoMapper;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> _lazyUserService;
        private readonly Lazy<IJuegoService> _lazyJuegoService;
        private readonly Lazy<ISubJuegoService> _lazySubJuegoService;
        private readonly Lazy<IBoletoService> _lazyBoletoService;
        private readonly IMapper _mapper;

        public ServiceManager(IRepositoryManager repository, IMapper mapper)
        {
            _mapper = mapper;
            _lazyUserService = new Lazy<IUserService>(() => new UserService(repository,mapper));
            _lazyJuegoService = new Lazy<IJuegoService>(() => new JuegoService(repository, mapper));
            _lazySubJuegoService = new Lazy<ISubJuegoService>(() => new SubJuegoService(repository, mapper));
            _lazyBoletoService = new Lazy<IBoletoService>(() => new BoletoService(repository, mapper));
        }
        public IUserService UserService => _lazyUserService.Value;

        public IJuegoService JuegoService => _lazyJuegoService.Value;

        public ISubJuegoService SubJuegoService => _lazySubJuegoService.Value;
        public  IBoletoService BoletoService => _lazyBoletoService.Value;
    }
}
