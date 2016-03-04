﻿using System.Collections.Generic;
using System.Linq;
using BB.BL.Domain.Organisations;
using BB.BL.Domain.Users;
using BB.BL.Domain;
using BB.BL.Domain.Playlists;
using BB.DAL.EFOrganisation;
using BB.DAL.EFUser;

namespace BB.BL
{
    public class OrganisationManager : IOrganisationManager
    {
        private readonly IOrganisationRepository organisationsRepository;

        public OrganisationManager(IOrganisationRepository organisationRepository)
        {
            this.organisationsRepository = organisationRepository;
        }
        

        public Organisation ReadOrganisationForPlaylist(long playlistId)
        {
            return organisationsRepository.ReadOrganisationForPlaylist(playlistId);
        }

        public IEnumerable<Organisation> ReadOrganisationsForUser(long userId)
        {
            return organisationsRepository.ReadOrganisationsForUser(userId);
        }

        public DashboardBlock CreateDashboardBlock(string blockName, int sequence)
        {
            DashboardBlock block = new DashboardBlock
            {
                BlockName = blockName,
                Sequence = sequence
            };
            return organisationsRepository.CreateDashboardBlock(block);
        }

        public Organisation CreateOrganisation(string name, string bannerUrl, string colorScheme, User organisator)
        {
            Organisation organisation = new Organisation
            {
                Name = name,
                BannerUrl = bannerUrl,
                ColorScheme = colorScheme,
                DashboardBlocks = new List<DashboardBlock>(),
                Playlists = new List<Playlist>(),
            };
            return organisationsRepository.CreateOrganisation(organisation, organisator);
        }

        public void DeleteDashboardBlock(long blockId)
        {
            organisationsRepository.DeleteDashboardBlock(blockId);
        }

        public Organisation DeleteOrganisation(long organisationId)
        {
            return organisationsRepository.DeleteOrganisation(organisationId);
        }

        public IEnumerable<DashboardBlock> ReadDashboardBlocks(Organisation organisation)
        {
            return organisationsRepository.ReadDashboardBlocks(organisation);
        }

        public Organisation ReadOrganisation(string organisationName)
        {
            return organisationsRepository.ReadOrganisation(organisationName);
        }

        public Organisation ReadOrganisation(long organisationId)
        {
            return organisationsRepository.ReadOrganisation(organisationId);
        }

        public IEnumerable<Organisation> ReadOrganisations()
        {
            return organisationsRepository.ReadOrganisations();
        }

        

        public DashboardBlock UpdateDashboardBlock(DashboardBlock block)
        {
            return organisationsRepository.UpdateDashboardBlock(block);
        }

        public Organisation UpdateOrganisation(Organisation organisation)
        {
            return organisationsRepository.UpdateOrganisation(organisation);
        }
    }
}
