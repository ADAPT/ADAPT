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
  *    Kathleen Oneal - delete threePoint, RearTwoPoing, Drawbar, RearPivotWagonHitch, FrontRigidThreePoint
  *******************************************************************************/  

namespace AgGateway.ADAPT.ApplicationDataModel.Equipment
{
    public enum HitchTypeEnum
    {
        Unkown,
        ISO64893TractorDrawbar,
        ISO730ThreePointHitchSemiMounted,
        ISO730ThreePointHitchMounted,
        ISO64891HitchHook,
        ISO64892ClevisCoupling40,
        ISO64894PitonTypeCoupling,
        ISO56922PivotWagonHitch,
        ISO24347BallTypeHitch,
    }
}
