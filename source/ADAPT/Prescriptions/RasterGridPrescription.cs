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
  *    Justin Sliekers - removing all properties
  *    Jason Roesbeke - changed List<RxRates> to List<RxCellLookup> because the class name has been changed
  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Representations;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;

namespace AgGateway.ADAPT.ApplicationDataModel.Prescriptions
{
   public class RasterGridPrescription : SpatialPrescription
   {
       public RasterGridPrescription()
       {
           Rates = new List<RxCellLookup>();
       }

      public Point Origin { get; set; }

      public int RowCount { get; set; }

      public int ColumnCount { get; set; }

      public NumericRepresentationValue CellWidth { get; set; }

      public NumericRepresentationValue CellHeight { get; set; }

      public List<RxCellLookup> Rates { get; set; }
   }
}
