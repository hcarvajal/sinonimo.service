using AutoMapper;
using Domain.Entities;
using Models.RepositoryManager;
using Models.UserDTO;
using Service.Abstraction;


namespace Services
{
    internal sealed class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UserService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        public async Task<bool> UserExist(string username, CancellationToken cancellationToken = default)
        {
            return await _repositoryManager.User.UserExistAsync(username,cancellationToken);

        }

        public async Task<IEnumerable<UserDTO>> GetUsersAsync(CancellationToken cancellation = default)
        {
            var users = await _repositoryManager.User.GetAllAsync(cancellation);

            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }


        public async Task<UserDTO> GeByIdAsync(string username, CancellationToken cancellation = default)
        {
            var user = await _repositoryManager.User.GetByIdAsync(username, cancellation);

            return _mapper.Map<UserDTO>(user);

        }

        public async Task<UserDTO> CreateAsync(UserForCreateDTO userForCreateDTO, CancellationToken cancellationToken = default)
        {
            var finalUser = _mapper.Map<User>(userForCreateDTO);

            await _repositoryManager.User.Insert(finalUser);

            await _repositoryManager.Works.SaveCHangesAsync(cancellationToken);

            return _mapper.Map<UserDTO>(finalUser);


        }

        public async Task<UserDTO> ValidateUserCredentials(string username, string password, CancellationToken cancellationToken = default)
        {

            var user = await _repositoryManager.User.ValidateUser(username, password, cancellationToken);

            if (user == null)
            {
                return new UserDTO(
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "");

            }


            return _mapper.Map<UserDTO>(user);

        }

       

        public async Task<UserDTO> UpdateAsync(string username, UserForUpdateDTO userForUpdateDTO, CancellationToken cancellation = default)
        {
            var userEntity = await _repositoryManager.User.GetByIdAsync(username, cancellation);
            
            _mapper.Map(userForUpdateDTO,userEntity);

            await _repositoryManager.Works.SaveCHangesAsync(cancellation);

            var user = await _repositoryManager.User.GetByIdAsync(username);

            return _mapper.Map<UserDTO>(user);

        }


        public async Task<UserForUpdateDTO> PartialyUpdateAsync(string username , CancellationToken cancellation = default)
        {
            var userEntity = await _repositoryManager.User.GetByIdAsync(username, cancellation);

            return _mapper.Map<UserForUpdateDTO>(userEntity);

        }

        public Task<UserDTO> DeleteAsync(int id, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Method is using configure await to continue while the SaveChanges is completed.
        /// </summary>
        /// <param name="userForUpdate"></param>
        /// <param name="user"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public async Task<bool> PartialyUpdateSaveAsync(String username, UserForUpdateDTO userForUpdate, CancellationToken cancellation = default)
        {

            var userEntity = await _repositoryManager.User.GetByIdAsync(username, cancellation);


           _mapper.Map(userForUpdate,userEntity);

           var saved = await _repositoryManager.Works.SaveCHangesAsync(cancellation).ConfigureAwait(false);

            return saved;
        }
    }
}
