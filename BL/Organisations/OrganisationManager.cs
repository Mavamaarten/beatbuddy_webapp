﻿using System.Collections.Generic;
using System.Linq;
using BB.BL.Domain.Organisations;
using BB.BL.Domain.Users;
using BB.BL.Domain;
using BB.BL.Domain.Playlists;
using BB.DAL.EFOrganisation;
using BB.DAL.EFUser;
using System;

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

        public Organisation CreateOrganisation(string name, string bannerUrl, User organisator)
        {
            Organisation organisation = new Organisation
            {
                Name = name,
                BannerUrl = bannerUrl,
                DashboardBlocks = new List<DashboardBlock>(),
                Playlists = new List<Playlist>(),
            };
            return organisationsRepository.CreateOrganisation(organisation, organisator);
        }

        public Organisation DeleteOrganisation(long organisationId)
        {
            return organisationsRepository.DeleteOrganisation(organisationId);
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

        public Organisation UpdateOrganisation(Organisation organisation)
        {
            return organisationsRepository.UpdateOrganisation(organisation);
        }

        public IEnumerable<Organisation> SearchOrganisations(string prefix)
        {
            return organisationsRepository.SearchOrganisations(prefix);
        }

        public double ReadTotalTimeOfPlaylistsInMinutes(long organisationId)
        {
            var playlists = organisationsRepository.ReadOrganisationWithPlaylistsAndTracks(organisationId).Playlists;
            var allTracks = playlists.SelectMany(p => p.PlaylistTracks.Select(pt => pt.Track));
            var sum = allTracks.Sum(t => t.Duration);
            
            return Math.Round(sum/60.0,1);
        }

        public double ReadTotalVotesForOrganisation(long organisationId)
        {
            var playlists = organisationsRepository.ReadOrganisationWithPlaylistsAndTracks(organisationId).Playlists;
            var allPlaylistTracks = playlists.SelectMany(p => p.PlaylistTracks);
            var sum = allPlaylistTracks.Sum(pt => pt.Votes.Count);

            return sum;
        }

    }
}
