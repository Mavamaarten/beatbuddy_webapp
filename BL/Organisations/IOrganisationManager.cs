﻿using BB.BL.Domain.Organisations;
using BB.BL.Domain.Users;
using System.Collections.Generic;

namespace BB.BL
{
    public interface IOrganisationManager
    {
        //Organisation
        Organisation CreateOrganisation(string name, string bannerUrl, User organisator);
        Organisation UpdateOrganisation(Organisation organisation);
        IEnumerable<Organisation> ReadOrganisations();
        
        Organisation ReadOrganisation(long organisationId);
        Organisation ReadOrganisation(string organisationName);
        Organisation DeleteOrganisation(long organisationId);
        Organisation ReadOrganisationForPlaylist(long playlistId);
        IEnumerable<Organisation> SearchOrganisations(string prefix);
        IEnumerable<Organisation> ReadOrganisationsForUser(long userId);
        double ReadTotalTimeOfPlaylistsInMinutes(long organisationId);
        double ReadTotalVotesForOrganisation(long organisationId);
        //DashboardBlock

    }
}
