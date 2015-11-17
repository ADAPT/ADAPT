/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Tim Shearouse - initial API and implementation
  *******************************************************************************/
namespace AgGateway.ADAPT.ApplicationDataModel.PluginProperties
{
    public class LatencySettings
    {
        public double RecordingOnTransitionDelay { get; set; }
        public double RecordingOffTransitionDelay { get; set; }
        public double HarvestYieldDelay { get; set; }
        public double HarvestMoistureDelay { get; set; }
        public double ForageYieldDelay { get; set; }
        public double ForageMoistureDelay { get; set; }
        public bool ApplyLatency { get; set; }
        public bool DisperseYield { get; set; }
    }
}
