/*******************************************************************************
  * Copyright (C) 2015-16, 2018 AgGateway and ADAPT Contributors
  * Copyright (C) 2015-16 Deere and Company
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
 *   Justin Sliekers - implement device element changes
 *   Joseph Ross - added EquipmentConfigurationGroups
 *   R. Andres Ferreyra - added Facilities, DeviceSeries, IrrSystemModels,
 *                        IrrSystemConfigurations, IrrSectionConfigurations, 
 *                        EndgunConfigurations.
  *******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        public Catalog()
        {
            Brands = new List<Brand>();
            Connectors = new List<Connector>();
            ContactInfo = new List<ContactInfo>();
            Crops = new List<Crop>();
            CropZones = new List<CropZone>();
            EquipmentConfigurations = new List<EquipmentConfiguration>();
            EquipmentConfigurationGroups = new List<EquipmentConfigurationGroup>();
            Farms = new List<Farm>();
            Fields = new List<Field>();
            FieldBoundaries = new List<FieldBoundary>();
            GeoPoliticalContexts = new List<GeoPoliticalContext>();
            Growers = new List<Grower>();
            GuidancePatterns = new List<GuidancePattern>();
            GuidanceGroups = new List<GuidanceGroup>();
            Ingredients = new List<Ingredient>();
            Manufacturers = new List<Manufacturer>();
            Persons = new List<Person>();
            PersonRoles = new List<PersonRole>();
            Prescriptions = new List<Prescription>();
            Products = new List<Product>();
            TimeScopes = new List<TimeScope>();
            DeviceElementConfigurations = new List<DeviceElementConfiguration>();
            DeviceModels = new List<DeviceModel>();
            DeviceElements = new List<DeviceElement>();
            HitchPoints = new List<HitchPoint>();
            Companies = new List<Company>();
            Products = new List<Product>();
        }

        public List<Brand> Brands { get; set; }

        public List<Company> Companies { get; set; }

        public List<Connector> Connectors { get; set; }

        public List<ContactInfo> ContactInfo { get; set; }

        public List<Crop> Crops { get; set; }

        public List<CropZone> CropZones { get; set; }

        public string Description { get; set; }

        public List<DeviceElement> DeviceElements { get; set; }

        public List<DeviceModel> DeviceModels { get; set; }

        public List<IrrSystemModel> IrrSystemModels { get; set; }

        public List<DeviceSeries> DeviceSeries { get; set; }

        public List<DeviceElementConfiguration> DeviceElementConfigurations { get; set; }

        public List<EquipmentConfiguration> EquipmentConfigurations { get; set; }

        public List<EquipmentConfigurationGroup> EquipmentConfigurationGroups { get; set; }

        public List<Farm> Farms { get; set; }
        
        public List<Field> Fields { get; set; }

        public List<FieldBoundary> FieldBoundaries { get; set; }

        public List<GeoPoliticalContext> GeoPoliticalContexts { get; set; }
        
        public List<Grower> Growers { get; set; }

        public List<GuidancePattern> GuidancePatterns { get; set; }

        public List<GuidanceGroup> GuidanceGroups { get; set; }

        public List<HitchPoint> HitchPoints { get; set; } 

        public List<Ingredient> Ingredients { get; set; } 

        public List<Manufacturer> Manufacturers { get; set; }

        public List<Person> Persons { get; set; } 

        public List<PersonRole> PersonRoles { get; set; }
        
        public IEnumerable<Prescription> Prescriptions { get; set; }

        public List<Product> Products { get; set; } 

        public List<TimeScope> TimeScopes { get; set; }

        public List<Facility> Facilities { get; set; }

        public List<IrrSystemConfiguration> IrrSystemConfigurations { get; set; }

        public List<IrrSectionConfiguration> IrrSectionConfigurations { get; set; }

        public List<EndgunConfiguration> EndgunConfigurations { get; set; }

    }
}
