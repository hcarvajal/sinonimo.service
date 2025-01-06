using Domain.Repository_Interfaces;
using Domain.Repository_Interfaces.Boleto;
using Domain.Repository_Interfaces.Juego;
using Domain.Repository_Interfaces.SubJuegos;
using Models.RepositoryManager;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private SinonimoContext _context;
        private IUserRepository? _userRepository;
        private IJuegoRepository? _juegoRepository;
        private ISinonimoWorks? _sinonimoworks;
        private ISubJuegosRepository? _subJuegosRepository;
        private IBoletoRepository? _boletoRepository;

        public RepositoryManager(SinonimoContext _dbContext)
        {
            _context = _dbContext;
        }
        public IUserRepository User
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }

                return _userRepository;
            }

        }

        public IJuegoRepository Juego
        {
            get
            {
                if(_juegoRepository == null)
                {
                    _juegoRepository = new JuegoRepository(_context);
                }

                return _juegoRepository;
            }
        }

        public ISinonimoWorks Works
        {
            get
            {
                if (_sinonimoworks == null)
                {
                    _sinonimoworks = new SinonimoWorks(_context);
                }

                return _sinonimoworks;
            }
        }

        public ISubJuegosRepository SubJuegos
        {
            get
            {
                if(_subJuegosRepository == null)
                {
                    _subJuegosRepository = new SubJuegosRepository(_context);
                }

                return _subJuegosRepository;
            }
        }

        public IBoletoRepository Boletos
        {
            get
            {
                if(_boletoRepository == null)
                {
                    _boletoRepository = new BoletoRepository(_context);
                }

                return _boletoRepository;
            }
        }
    }
}
