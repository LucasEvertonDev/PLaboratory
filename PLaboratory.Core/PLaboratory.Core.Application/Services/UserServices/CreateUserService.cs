using PLaboratory.Core.Application.Services.Base;
using PLaboratory.Core.Domain.Contansts;
using PLaboratory.Core.Domain.DbContexts.Entities;
using PLaboratory.Core.Domain.DbContexts.Repositorys.Base;
using PLaboratory.Core.Domain.Models.Users;
using PLaboratory.Core.Domain.Plugins.Cryptography;
using PLaboratory.Core.Domain.Plugins.Validators;
using PLaboratory.Core.Domain.Services.UserServices;

namespace PLaboratory.Core.Application.Services.UserServices
{
    public class CreateUserService : BaseService<CreateUserModel>, ICreateUserService
    {
        private readonly ISearchRepository<User> _searchRepository;
        private readonly IPasswordHash _passwordHash;
        private readonly IValidatorModel<CreateUserModel> _createUserValidatorModel;
        private readonly ICreateRepository<User> _createRepository;

        public CreatedUserModel CreatedUser { get; set; }

        public CreateUserService(IServiceProvider serviceProvider,
            ISearchRepository<User> searchRepository,
            IPasswordHash passwordHash,
            IValidatorModel<CreateUserModel> createUserValidatorModel,
            ICreateRepository<User> createRepository) : base(serviceProvider)
        {
            _createRepository = createRepository;
            _searchRepository = searchRepository;
            _passwordHash = passwordHash;
            _createUserValidatorModel = createUserValidatorModel;
        }

        public override async Task ExecuteAsync(CreateUserModel param)
        {
            await OnTransactionAsync(async () =>
            {
                await ValidateAsync(param);

                var user = _imapper.Map<User>(param);

                user.PasswordHash = _passwordHash.GeneratePasswordHash();
                user.Password = _passwordHash.EncryptPassword(user.Password, user.PasswordHash);

                user = await _createRepository.CreateAsync(user);

                this.CreatedUser = _imapper.Map<CreatedUserModel>(user);
            });
        }

        protected override async Task ValidateAsync(CreateUserModel param)
        {
            if (_searchRepository.AsQueriable().Where(u => u.Username == param.Username).Any())
            {
                BusinessException(UserErrors.Business.ALREADY_USERNAME);
            }

            if (_searchRepository.AsQueriable().Where(u => u.Email == param.Email).Any())
            {
                BusinessException(UserErrors.Business.ALREADY_EMAIL);
            }

            await _createUserValidatorModel.ValidateModelAsync(param);
        }
    }
}
