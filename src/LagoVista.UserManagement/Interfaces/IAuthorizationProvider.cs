using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.UserManagement.Security;

namespace LagoVista.UserManagement.Interfaces
{
    /* 
     * This is responsible for two things
     * 1) Ensure the user has access to the entity that they want to edit.
     * 2) They have permissions to perform the behavior.
     * 
     */
    public interface IAuthorizationProvider
    {
     //   AuthorizationResult AuthorizeAsync(IOwnedEntity entity, EntityHeader org, EntityHeader user);
    }
}
