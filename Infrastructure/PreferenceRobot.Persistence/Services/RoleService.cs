using Microsoft.AspNetCore.Identity;
using PreferenceRobot.Application.Interfaces.Services;
using PreferenceRobot.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Persistence.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleService(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> CreateRole(string name)
        {
            IdentityResult result= await _roleManager.CreateAsync(new() { Id=Guid.NewGuid().ToString(), Name=name});
            return result.Succeeded;
        }

        public async Task<bool> DeleteRole(string id)
        {
            Role role=await _roleManager.FindByIdAsync(id);
            IdentityResult result= await _roleManager.DeleteAsync(role);
            return result.Succeeded;
        }

        public(object, int) GetAllRoles()
        {
            var query = _roleManager.Roles;

            return (query.Select(r => new { r.Id, r.Name }), query.Count());
        }

        public async Task<(string id, string name)> GetRoleById(string id)
        {
            string role = await _roleManager.GetRoleIdAsync(new() { Id = id });
            return (id, role);

        }

        public async Task<bool> UpdateRole(string id, string name)
        {
            Role role = await _roleManager.FindByIdAsync(id);
            role.Name = name;
            IdentityResult result= await _roleManager.UpdateAsync(role);
            return result.Succeeded;
        }
    }
}
