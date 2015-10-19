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

using System.Collections.Generic;

namespace AgGateway.ADAPT.Representation.RepresentationSystem
{
    public class RepresentationManager
    {
        private static RepresentationManager _instance;
        private Dictionary<int, ApplicationDataModel.Representation> _representations;
        private static readonly object Threadlock = new object();

        public static RepresentationManager Instance
        {
            get
            {
                if (_instance == null)
                    lock (Threadlock)
                    {
                        if(_instance == null)
                            _instance = new RepresentationManager();
                    }
                return _instance;
            }
        }

        public Dictionary<int, ApplicationDataModel.Representation> Representations {
            get { return _representations; }
        }

        private RepresentationManager()
        {
            _representations = new RepresentationLoader().Load();
        }


    }
}
