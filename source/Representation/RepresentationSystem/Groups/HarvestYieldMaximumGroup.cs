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
    public class HarvestYieldMaximumGroup : RepresentationGroup
    {
        public HarvestYieldMaximumGroup()
            : base(RepresentationGroupList.rgHarvestYieldMaximum)
        {
            Add(RepresentationInstanceList.vrYieldVolumeMaximum);
            Add(RepresentationInstanceList.vrYieldVolumePerAreaMaximum);
            Add(RepresentationInstanceList.vrYieldMassMaximum);
            Add(RepresentationInstanceList.vrYieldMassPerAreaMaximum);
            Add(RepresentationInstanceList.vrYieldWetMassMaximum);
            Add(RepresentationInstanceList.vrYieldWetMassPerAreaMaximum);
            Add(RepresentationInstanceList.vrYieldWetVolumeMaximum);
            Add(RepresentationInstanceList.vrYieldWetVolumePerAreaMaximum);
            Add(RepresentationInstanceList.vrYieldBaleMaximum);
            Add(RepresentationInstanceList.vrYieldMassMaxForage);
            Add(RepresentationInstanceList.vrYieldMassPerAreaMaxForage);
            Add(RepresentationInstanceList.vrYieldWetMassMaxForage);
            Add(RepresentationInstanceList.vrYieldWetMassPerAreaMaxForage);
        }
    }
}
