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
  *    Kelly Nelson - Added Errors collection
  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.ADM;

namespace AgGateway.ADAPT.TestPlugin
{
   public class TestPlugin : IPlugin
   {
      public string Name
      {
         get
         {
            return "TestPlugin";
         }
      }

      public string Version { get; private set; }
      public string Owner { get; private set; }
      public void Initialize(string args = null)
      {
      }

      public bool IsDataCardSupported(string dataPath, Properties properties = null)
      {
         return true;
      }

      public IList<IError> ValidateDataOnCard(string dataPath, Properties properties = null)
      {
         return new List<IError>();
      }

      public IList<ApplicationDataModel.ADM.ApplicationDataModel> Import(string dataPath, Properties properties = null)
      {
          return new[] {new ApplicationDataModel.ADM.ApplicationDataModel()};
      }

      public void Export(ApplicationDataModel.ADM.ApplicationDataModel dataModel, string exportPath, Properties properties = null)
      {
      }

      public Properties GetProperties(string dataPath)
      {
         return new Properties();
      }

      public IList<IError> Errors { get { return new List<IError>(); } } 

    }
}
