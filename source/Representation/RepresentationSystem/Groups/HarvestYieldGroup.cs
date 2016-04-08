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
namespace AgGateway.ADAPT.Representation.RepresentationSystem.Groups
{
    public class HarvestYieldGroup : RepresentationGroup
    {
        public HarvestYieldGroup()
            : base(RepresentationGroupList.rgHarvestYield)
        {
            Add(RepresentationInstanceList.vrYieldVolume);
            Add(RepresentationInstanceList.vrYieldVolumePerArea);
            Add(RepresentationInstanceList.vrYieldMass);
            Add(RepresentationInstanceList.vrYieldMassPerArea);
            Add(RepresentationInstanceList.vrYieldWetMassFlow);
            Add(RepresentationInstanceList.vrYieldWetMassPerArea);
            Add(RepresentationInstanceList.vrYieldWetVolume);
            Add(RepresentationInstanceList.vrYieldWetVolumePerArea);
            Add(RepresentationInstanceList.vrYieldBale);
            Add(RepresentationInstanceList.vrYieldBalePerArea);
            Add(RepresentationInstanceList.vrYieldMassForage);
            Add(RepresentationInstanceList.vrYieldMassFrgPerArea);
            Add(RepresentationInstanceList.vrYieldWetMassForage);
            Add(RepresentationInstanceList.vrYieldWetMassFrgPerArea);
        }
    }
}