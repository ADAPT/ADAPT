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

namespace AgGateway.ADAPT.ApplicationDataModel
{
    public enum HitchTypeEnum
    {
        Unkown = 0,
        ISO64893TractorDrawbar = 1,
        ISO730ThreePointHitchSemiMounted = 2,
        ISO730ThreePointHitchMounted = 3,
        ISO64891HitchHook = 4,
        ISO64892ClevisCoupling40 = 5,
        ISO64894PitonTypeCoupling = 6,
        ISO56922PivotWagonHitch = 7,
        ISO24347BallTypeHitch = 8,
        ThreePoint = 9,
        RearTwoPoint = 10,
        Drawbar = 11,
        RearPivotWagonHitch = 12,
        FrontRigidThreePoint = 13,        
    }
}
