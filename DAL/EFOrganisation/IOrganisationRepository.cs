﻿using BB.BL.Domain.Organisations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.DAL.EFOrganisation
{
    public interface IOrganisationRepository
    {
        //Organisation
        Organisation CreateOrganisation(Organisation organisation);
        Organisation UpdateOrganisation(Organisation organisation);
        List<Organisation> ReadOrganisations();
        Organisation ReadOrganisation(long organisationId);
        void DeleteOrganisation(long organisationId);

        //DashboardBlock
        DashboardBlock CreateDashboardBlock(DashboardBlock dashboardBlock);
        DashboardBlock UpdateDashboardBlock(DashboardBlock block);
        List<DashboardBlock> ReadDashboardBlocks(Organisation organisation);
        void DeleteDashboardBlock(long blockId);
    }
}