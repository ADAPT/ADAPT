/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Tim Shearouse - initial API and implementation
  *******************************************************************************/

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AgGateway.ADAPT.ApplicationDataModel
{
    public class Properties
    {
        private readonly Dictionary<string, string> _properties = new Dictionary<string, string>();

        public void SetProperty(string key, string value)
        {
            if (_properties.ContainsKey(key))
            {
                _properties[key] = value;
            }
            else
            {
                _properties.Add(key, value);
            }
        }

        public string GetProperty(string key)
        {
            if (!_properties.ContainsKey(key))
                return null;
            return _properties[key];
        }

        public ReadOnlyDictionary<string, string> GetAllProperties()
        {
            return new ReadOnlyDictionary<string, string>(_properties);
        }
    }
}