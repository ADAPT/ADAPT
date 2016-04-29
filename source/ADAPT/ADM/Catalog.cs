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
  *    Kathleen Oneal, Joseph Ross - Added Ingredients
 *   Tarak Reddy - Added guidance group and Guidance Allocation
 *   Tarak Reddy - Moved WorkItems and WorkItemsOperations to Documents
 *   Tarak Reddy - Moved GuidanceAllocations to Documents
 *   Joseph ross - Added Prescriptions to Catalog
 *   Kathleen Oneal - added equipmentConfigs and renamed Name to Description
 *   Kathleen Oneal - added manufactures list
  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Equipment;
using AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries;
using AgGateway.ADAPT.ApplicationDataModel.Guidance;
using AgGateway.ADAPT.ApplicationDataModel.Logistics;
using AgGateway.ADAPT.ApplicationDataModel.Prescriptions;
using AgGateway.ADAPT.ApplicationDataModel.Products;

namespace AgGateway.ADAPT.ApplicationDataModel.ADM
{
    public class Catalog
    {
        public List<Brand> Brands { get; set; }

        public List<Connector> Connectors { get; set; }

        public List<ContactInfo> ContactInfo { get; set; }

        public List<Container> Containers { get; set; } 

        public List<Crop> Crops { get; set; }

        public List<CropProtectionProduct> CropProtectionProducts { get; set; }

        public List<CropVariety> CropVarieties { get; set; }

        public List<CropZone> CropZones { get; set; }

        public string Description { get; set; }

        public List<EquipmentConfig> EquipmentConfigs { get; set; }

        public List<Farm> Farms { get; set; }
        
        public List<FertilizerProduct> FertilizerProducts { get; set; }

        public List<Field> Fields { get; set; }

        public List<FieldBoundary> FieldBoundaries { get; set; }

        public List<Grower> Growers { get; set; }

        public List<GuidancePattern> GuidancePatterns { get; set; }

        public List<GuidanceGroup> GuidanceGroups { get; set; }

        public List<Implement> Implements { get; set; } 

        public List<ImplementModel> ImplementModels { get; set; }

        public List<ImplementType> ImplementTypes { get; set; } 

        public List<ImplementConfiguration> ImplementConfigurations { get; set; } 

        public List<Ingredient> Ingredients { get; set; } 

        public List<Machine> Machines { get; set; }

        public List<MachineModel> MachineModels { get; set; }

        public List<MachineSeries> MachineSeries { get; set; }

        public List<MachineType> MachineTypes { get; set; } 

        public List<MachineConfiguration> MachineConfigurations { get; set; }

        public List<Manufacturer> Manufacturers { get; set; }

        public List<Person> Persons { get; set; } 

        public List<PersonRole> PersonRoles { get; set; }
        
        public IEnumerable<Prescription> Prescriptions { get; set; }

        public List<ProductMix> ProductMixes { get; set; }

        public List<TimeScope> TimeScopes { get; set; }
    }
}