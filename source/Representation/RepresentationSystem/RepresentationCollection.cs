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

namespace AgGateway.ADAPT.Representation.RepresentationSystem
{
    public class RepresentationCollection<T> : IEnumerable<T> where T : ApplicationDataModel.Representation
    {
        private readonly Dictionary<int, T> _domainIdRepresentations;

        public int Count
        {
            get
            {
                return _domainIdRepresentations.Count;
            }
        }

        public T this[int id]
        {
            get
            {
                if (!_domainIdRepresentations.ContainsKey(id))
                    return default(T);

                return _domainIdRepresentations[id];
            }
        }

        public RepresentationCollection()
            : this(new List<T>())
        {

        }

        public RepresentationCollection(IEnumerable<T> representations)
        {
            _domainIdRepresentations = new Dictionary<int, T>();

            foreach (var representation in representations)
            {
                if (!_domainIdRepresentations.ContainsKey(representation.Id))
                {
                    _domainIdRepresentations.Add(representation.Id, representation);
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _domainIdRepresentations.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
