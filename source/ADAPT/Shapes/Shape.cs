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
  *    Marco Bettini - added ContextItems
  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;

namespace AgGateway.ADAPT.ApplicationDataModel.Shapes
{
    public abstract class Shape
    {
        protected Shape()
        {
            ContextItems = new List<ContextItem>();
        }

        public int Id { get; set; }

        public ShapeTypeEnum Type { get; protected set; }

        public List<ContextItem> ContextItems { get; set; }
    }
}
