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
 *    Tarak Reddy - Added implement id 
 *    Kathleen Oneal - removed ImplementTypeId
 *    Justin Sliekers - implement device element changes
 *******************************************************************************/

using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ApplicationDataModel.Equipment
{
    public class ImplementConfiguration : DeviceElementConfiguration
    {
        public NumericRepresentationValue Width { get; set; }
        
        public NumericRepresentationValue TrackSpacing { get; set; }
        
        public NumericRepresentationValue PhysicalWidth { get; set; }
        
        public NumericRepresentationValue InGroundTurnRadius { get; set; }
        
        public NumericRepresentationValue ImplementLength { get; set; }
        
        public NumericRepresentationValue YOffset { get; set; }
        
        public NumericRepresentationValue VerticalCuttingEdgeZOffset { get; set; }
        
        public ReferencePoint ControlPoint { get; set; }
        
        public ReferencePoint GpsReceiverOffset { get; set; }
    }
}
