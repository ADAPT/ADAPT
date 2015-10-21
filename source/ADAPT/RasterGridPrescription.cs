/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Justin Sliekers - initial API and implementation
  *******************************************************************************/

namespace AgGateway.ADAPT.ApplicationDataModel
{
    public class RasterGridPrescription : SpatialPrescription
    {
        public Point Origin { get; set; }

        public int RowCount { get; set; }

        public int ColumnCount { get; set; }

        public NumericRepresentationValue CellWidth { get; set; }

        public NumericRepresentationValue CellHeight { get; set; }

        public RxRates[,] Rates { get; set; }
    }
}
