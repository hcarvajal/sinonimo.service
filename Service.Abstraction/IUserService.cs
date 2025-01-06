using System;
using System.Threading.Tasks;
using Models.UserDTO;


namespace Service.Abstraction
{
    public interface IUserService
    {
        /// <summary>
        /// Esto es para devolver todos los usarios.
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        /// 

        Task<bool> UserExist(string username, CancellationToken cancellationToken = default);

        Task<IEnumerable<UserDTO>> GetUsersAsync(CancellationToken cancellation = default);

        Task<UserDTO> GeByIdAsync(string username, CancellationToken cancellation = default);

        Task<UserDTO> CreateAsync(UserForCreateDTO userForCreateDTO,CancellationToken cancellation = default);

        Task<UserDTO> ValidateUserCredentials(string username, string password, CancellationToken cancellationToken = default);
        Task<UserDTO> UpdateAsync(string username,UserForUpdateDTO userForUpdateDTO,CancellationToken cancellation = default);
        Task<UserForUpdateDTO> PartialyUpdateAsync(string username,CancellationToken cancellation=default);
        Task<bool> PartialyUpdateSaveAsync(string username,UserForUpdateDTO userForUpdate ,CancellationToken cancellation = default);

        Task<UserDTO> DeleteAsync(int id, CancellationToken cancellation = default);

    }
}
