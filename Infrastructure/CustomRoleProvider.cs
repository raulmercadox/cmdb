using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using CMDBApplication.Repository;
using CMDBApplication.Models;

namespace CMDBApplication.Infrastructure
{
    public class CustomRoleProvider : RoleProvider
    {

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                return String.Empty;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            List<string> roles = new List<string>();
            UsuarioRepository usuarioRepository = new UsuarioRepository();
            Usuario usuario = usuarioRepository.Obtener(username);

            if (usuario.Administrador)
                roles.Add("Administrador");

            if (usuario.Operador)
                roles.Add("Operador");

            if (usuario.Lector)
                roles.Add("Lector");

            if (usuario.CM)
                roles.Add("CM");

            if (usuario.RM)
                roles.Add("RM");

            if (usuario.Ejecutor)
                roles.Add("Ejecutor");

            if (usuario.Test)
                roles.Add("Test");

            return roles.ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            List<Rol> roles = new RolRepository().ListarPorNombreUsuario(username);
            return roles.Exists(p => p.Nombre == roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
