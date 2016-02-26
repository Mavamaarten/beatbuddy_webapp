﻿using BB.BL.Domain.Organisations;
using BB.BL.Domain.Users;
using System.Collections.Generic;

namespace BB.BL
{
    public interface IUserManager
    {
        //User
        User CreateUser(string email, string lastname, string firstname, string nickname, string imageUrl);
        User UpdateUser(User user);
        User ReadUser(long userId);
        User ReadUser(string email);
        User ReadUser(string lastname, string firstname);
        User ReadOrganiserFromOrganisation(Organisation organisation);
        IEnumerable<User> ReadUsers();
        void DeleteUser(long userId);

        //UserRole
        UserRole CreateUserRole(long userId, long organisationId, Role role);
        IEnumerable<UserRole> ReadUserRolesForOrganisation(Organisation organisation);
        IEnumerable<UserRole> ReadOrganisationsForUser(long userId);
    }
}
