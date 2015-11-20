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
    public enum RepresentationGroupList
    {
        /// <summary>
        /// Group for harvest moisture.
        /// </summary>
        rgHarvestMoisture = 1,
        /// <summary>
        /// Group for yieldVolume,yieldVolume/Area, yieldMass, yieldMass/Area, yieldWetMass,yieldWetMass/Area,
        /// yieldWetVolume,yieldWetVolume/Area,yieldBale,yieldBale/Area,  
        /// </summary>
        rgHarvestYield = 2,
        /// <summary>
        /// group for HarvestMoisture YieldVolume, YieldVolume/Area, YieldMass, YieldMass/Area, YieldWetMass, YieldWetMass/Area, YieldWetVolume
        ///YieldBale, YieldBale/Area
        /// </summary>
        rgHarvestData = 3,
        /// <summary>
        /// Group for seed/bag, seed/container, seed/sack
        /// </summary>
        rgSeedsPerPackageSeeds = 4,
        /// <summary>
        /// Group for bag, seed/bag, container, seed/container, sack, seed/sack, mass/bag, mass/container, mass/sack.
        /// </summary>
        rgSeedsMeasuredQuantity = 5,
        /// <summary>
        /// Group for mass/bag, mass/container, mass/sack.
        /// </summary>
        rgSeedsPerPackageWeight = 6,
        /// <summary>
        /// Group for function values
        /// </summary>
        rgFunctionValues = 7,
        /// <summary>
        /// Group for forage values
        /// </summary>
        rgHarvestForage = 8,
        /// <summary>
        /// Harvest yeild maximum representations.
        /// </summary>
        rgHarvestYieldMaximum,
        /// <summary>
        /// Application rate mass representations
        /// </summary>
        rgApplicationMassData,
        /// <summary>
        /// Application rate volume representations
        /// </summary>
        rgApplicationVolumeData,
        /// <summary>
        /// Seeding rate seeds representations
        /// </summary>
        rgSeedingSeedsData,
        /// <summary>
        /// Seeding rate mass representations
        /// </summary>
        rgSeedingMassData,
        /// <summary>
        /// Group for Elevation.
        /// </summary>
        rgHarvestElevation,
        /// <summary>
        /// Group for price per bag, sack and container.
        /// </summary>
        rgPricePerSeedPackage,
        /// <summary>
        /// Group for price per equipment.
        /// </summary>
        rgPricePerEquipment,
        /// <summary>
        /// Group for price per operator.
        /// </summary>
        rgPricePerOperator,
        /// <summary>
        /// Group for price per cotton crop.
        /// </summary>
        rgPricePerCotton,
        /// <summary>
        /// Group for price per forage crop.
        /// </summary>
        rgPricePerForage,
        /// <summary>
        /// Group for price per grain crop.
        /// </summary>
        rgPricePerGrain,
        /// <summary>
        /// Group for price per crop that are grain and forage.
        /// </summary>
        rgPricePerGrainForage,
        ///<summary>
        /// Group for price per miscellaneous item
        ///</summary>
        rgPricePerMiscellaneousItem,
    }
}
