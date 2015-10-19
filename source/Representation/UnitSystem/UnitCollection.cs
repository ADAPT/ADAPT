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

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AgGateway.ADAPT.Representation.UnitSystem
{
    public class UnitCollection<T> : IEnumerable<T> where T : IUnit
    {
        private readonly Hashtable _units;

        public virtual T this[string domainId]
        {
            get
            {
                return (T)_units[domainId];
            }
        }

        public int Count
        {
            get
            {
                return _units.Count;
            }
        }

        public UnitCollection()
            : this(new List<T>())
        {

        }

        public UnitCollection(IEnumerable<T> units)
        {
            _units = new Hashtable();
            foreach (var unit in units)
            {
                Add(unit.DomainID, unit);
            }
        }

        public bool Contains(string domainId)
        {
            return _units.ContainsKey(domainId);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _units.Values.Cast<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        protected void Add(string domainId, T value)
        {
            _units[domainId] = value;
        }
    }
}
