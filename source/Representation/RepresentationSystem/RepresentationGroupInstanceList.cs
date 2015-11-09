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
namespace AgGateway.ADAPT.Representation.RepresentationSystem
{
    public class RepresentationGroupInstanceList 
    {
        public static readonly RepresentationGroup rgHarvestMoisture = RepresentationGroups.Instance.GetGroup(RepresentationGroupList.rgHarvestMoisture);

        public static readonly RepresentationGroup rgHarvestYield = RepresentationGroups.Instance.GetGroup(RepresentationGroupList.rgHarvestYield);

        public static readonly RepresentationGroup rgHarvestData = RepresentationGroups.Instance.GetGroup(RepresentationGroupList.rgHarvestData);

        public static readonly RepresentationGroup rgSeedsPerPackageSeeds = RepresentationGroups.Instance.GetGroup(RepresentationGroupList.rgSeedsPerPackageSeeds);

        public static readonly RepresentationGroup rgSeedsMeasuredQuantity = RepresentationGroups.Instance.GetGroup(RepresentationGroupList.rgSeedsMeasuredQuantity);

        public static readonly RepresentationGroup rgSeedsPerPackageWeight = RepresentationGroups.Instance.GetGroup(RepresentationGroupList.rgSeedsPerPackageWeight);

        public static readonly RepresentationGroup rgFunctionValues = RepresentationGroups.Instance.GetGroup(RepresentationGroupList.rgFunctionValues);

        public static readonly RepresentationGroup rgHarvestForage = RepresentationGroups.Instance.GetGroup(RepresentationGroupList.rgHarvestForage);

        public static readonly RepresentationGroup rgHarvestYieldMaximum = RepresentationGroups.Instance.GetGroup(RepresentationGroupList.rgHarvestYieldMaximum);

        public static readonly RepresentationGroup rgApplicationMassData = RepresentationGroups.Instance.GetGroup(RepresentationGroupList.rgApplicationMassData);

        public static readonly RepresentationGroup rgApplicationVolumeData = RepresentationGroups.Instance.GetGroup(RepresentationGroupList.rgApplicationVolumeData);

        public static readonly RepresentationGroup rgSeedingSeedsData = RepresentationGroups.Instance.GetGroup(RepresentationGroupList.rgSeedingSeedsData);

        public static readonly RepresentationGroup rgSeedingMassData = RepresentationGroups.Instance.GetGroup(RepresentationGroupList.rgSeedingMassData);

        public static readonly RepresentationGroup rgHarvestElevation = RepresentationGroups.Instance.GetGroup(RepresentationGroupList.rgHarvestElevation);

        public static readonly RepresentationGroup rgPricePerSeedPackage = RepresentationGroups.Instance.GetGroup(RepresentationGroupList.rgPricePerSeedPackage);

        public static readonly RepresentationGroup rgPricePerEquipment = RepresentationGroups.Instance.GetGroup(RepresentationGroupList.rgPricePerEquipment);

        public static readonly RepresentationGroup rgPricePerOperator = RepresentationGroups.Instance.GetGroup(RepresentationGroupList.rgPricePerOperator);

        public static readonly RepresentationGroup rgPricePerCotton = RepresentationGroups.Instance.GetGroup(RepresentationGroupList.rgPricePerCotton);

        public static readonly RepresentationGroup rgPricePerForage = RepresentationGroups.Instance.GetGroup(RepresentationGroupList.rgPricePerForage);

        public static readonly RepresentationGroup rgPricePerGrain = RepresentationGroups.Instance.GetGroup(RepresentationGroupList.rgPricePerGrain);

        public static readonly RepresentationGroup rgPricePerGrainForage = RepresentationGroups.Instance.GetGroup(RepresentationGroupList.rgPricePerGrainForage);

        public static readonly RepresentationGroup rgPricePerMiscellaneousItem = RepresentationGroups.Instance.GetGroup(RepresentationGroupList.rgPricePerMiscellaneousItem);

    }
}