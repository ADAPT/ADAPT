/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Tarak Reddy, Tim Shearouse - initial API and implementation
  *******************************************************************************/
using System.Collections.Generic;
using AgGateway.ADAPT.Representation.RepresentationSystem.Groups;

namespace AgGateway.ADAPT.Representation.RepresentationSystem
{
    public class RepresentationGroups
    {
        private static RepresentationGroups _instance;
        private readonly Dictionary<RepresentationGroupList, RepresentationGroup> _representationGroups; 

        public static RepresentationGroups Instance
        {
            get { return _instance ?? (_instance = new RepresentationGroups()); }
        }

        private RepresentationGroups()
        {
            _representationGroups = new Dictionary<RepresentationGroupList, RepresentationGroup>();
            _representationGroups.Add(RepresentationGroupList.rgHarvestMoisture, new HarvestMoistureGroup());
            _representationGroups.Add(RepresentationGroupList.rgHarvestElevation, new HarvestElevationGroup());
            _representationGroups.Add(RepresentationGroupList.rgHarvestForage, new HarvestForageGroup());
            _representationGroups.Add(RepresentationGroupList.rgHarvestYield, new HarvestYieldGroup());
            _representationGroups.Add(RepresentationGroupList.rgHarvestYieldMaximum, new HarvestYieldMaximumGroup());
            _representationGroups.Add(RepresentationGroupList.rgHarvestData, new HarvestDataGroup());
            _representationGroups.Add(RepresentationGroupList.rgApplicationMassData, new ApplicationMassDataGroup());
            _representationGroups.Add(RepresentationGroupList.rgApplicationVolumeData, new ApplicationVolumeDataGroup());
            _representationGroups.Add(RepresentationGroupList.rgSeedingSeedsData, new SeedingSeedsDataGroup());
            _representationGroups.Add(RepresentationGroupList.rgSeedingMassData, new SeedingMassDataGroup());
            _representationGroups.Add(RepresentationGroupList.rgSeedsPerPackageSeeds, new SeedsPerPackageSeedsGroup());
            _representationGroups.Add(RepresentationGroupList.rgSeedsMeasuredQuantity, new SeedsMeasuredQuantityGroup());
            _representationGroups.Add(RepresentationGroupList.rgSeedsPerPackageWeight, new SeedsPerPackageWeightGroup());
            _representationGroups.Add(RepresentationGroupList.rgFunctionValues, new FunctionValueGroup());
            _representationGroups.Add(RepresentationGroupList.rgPricePerSeedPackage, new PricePerSeedPackageGroup());
            _representationGroups.Add(RepresentationGroupList.rgPricePerEquipment, new PricePerEquipmentGroup());
            _representationGroups.Add(RepresentationGroupList.rgPricePerOperator, new PricePerOperatorGroup());
            _representationGroups.Add(RepresentationGroupList.rgPricePerCotton, new PricePerCottonGroup());
            _representationGroups.Add(RepresentationGroupList.rgPricePerForage, new PricePerForageGroup());
            _representationGroups.Add(RepresentationGroupList.rgPricePerGrain, new PricePerGrainGroup());
            _representationGroups.Add(RepresentationGroupList.rgPricePerGrainForage, new PricePerGrainForage());
            _representationGroups.Add(RepresentationGroupList.rgPricePerMiscellaneousItem, new PricePerMiscellaneousItemGroup());
        }

        public RepresentationGroup GetGroup(RepresentationGroupList group)
        {
            return _representationGroups[group];
        }
    }
}
