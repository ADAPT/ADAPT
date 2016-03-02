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

namespace AgGateway.ADAPT.ApplicationDataModel.Common
{
    public class CompoundIdentifierFactory
    {
        private static CompoundIdentifierFactory _instance;
        private static int _lowestReferenceId;
        private static readonly object InstanceThreadLock = new object();
        private static readonly object CreateThreadLock = new object();

        private CompoundIdentifierFactory()
        {
            _lowestReferenceId = 0;
        }

        public static CompoundIdentifierFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (InstanceThreadLock)
                    {
                        if (_instance == null)
                            _instance = new CompoundIdentifierFactory();
                    }
                }
                return _instance;
            }
        }

        public CompoundIdentifier Create()
        {
            int referenceId;
            lock (CreateThreadLock)
            {
                _lowestReferenceId--;
                referenceId = _lowestReferenceId;
            }
            return new CompoundIdentifier(referenceId)
            {
                UniqueIds = new List<UniqueId>()
            };
        }
    }
}
