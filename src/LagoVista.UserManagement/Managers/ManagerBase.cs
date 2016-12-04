using LagoVista.Core.Exceptions;
using LagoVista.Core;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.PlatformSupport;
using LagoVista.Core.Resources;
using LagoVista.UserManagement.Interfaces;
using LagoVista.UserManagement.Interfaces.Repos.Account;
using LagoVista.Core.Validation;
using System;

namespace LagoVista.UserManagement.Managers
{
    public class ManagerBase
    {
        readonly ILogger _logger;
        readonly IAccountRepo _accountRepo;
        readonly IAppConfig _appConfig;

        public ManagerBase(IAccountRepo accountRepo, ILogger logger, IAppConfig appConfig)
        {
            _appConfig = appConfig;
            _accountRepo = accountRepo;
            _logger = logger;
        }

        public IAppConfig AppConfig { get { return _appConfig; } }
        public ILogger Logger { get { return _logger; } }
        public IAccountRepo AccountRepo { get { return _accountRepo; } }

        protected void SetCreatedBy(IAuditableEntity entity, IEntityHeader user)
        {
            var date = DateTime.Now.ToJSONString();
            entity.CreatedBy = EntityHeader.Create(user.Id, user.Text);
            entity.LastUpdatedBy = EntityHeader.Create(user.Id, user.Text);
            entity.CreationDate = date;
            entity.LastUpdatedDate = date;
        }

        protected void SetLastUpdated(IAuditableEntity entity, IEntityHeader user)
        {
            var date = DateTime.Now.ToJSONString();
            entity.LastUpdatedBy = EntityHeader.Create(user.Id, user.Text);
            entity.LastUpdatedDate = date;
        }

        protected void ConcurrencyCheck(IAuditableEntity fromRepo, string updatedDateStamp)
        {
            if(fromRepo.LastUpdatedDate != updatedDateStamp)
            {
                throw new ValidationException(ValidationResource.Concurrency_Error, new System.Collections.Generic.List<Core.Validation.ValidationMessage>()
                {
                    new Core.Validation.ValidationMessage(
                        ValidationResource.Concurrency_ErrorMessage
                            .Replace(Tokens.VALIDATION_USER_FULL_NAME, fromRepo.LastUpdatedBy.Text)
                            .Replace(Tokens.VALIDATION_DATESTAMP, fromRepo.LastUpdatedDate),
                        false)
                });
            }
        }

        protected void ValidationCheck(IValidateable entity, Actions action)
        {
            var result = Validator.Validate(entity, action);
            if(!result.IsValid)
            {
                throw new ValidationException("Invalid Data", result.Errors);
            }
        }
    }
}
