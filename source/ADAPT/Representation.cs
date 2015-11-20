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
    public abstract class Representation
    {
        protected Representation()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
        }

        public CompoundIdentifier Id { get; set; }

        public RepresentationCodeSourceEnum CodeSource { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public string LongDescription { get; set; }
    }
}