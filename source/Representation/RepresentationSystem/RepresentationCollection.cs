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
    public class RepresentationCollection<T> : IEnumerable<T> where T : Representation
    {
        private readonly Dictionary<string, T> _domainIdRepresentations;
        private readonly Dictionary<long, T> _domainTagRepresentations;

        public int Count
        {
            get
            {
                return _domainIdRepresentations.Count;
            }
        }

        public T this[long domainTag]
        {
            get
            {
                if (!_domainTagRepresentations.ContainsKey(domainTag))
                    return default(T);

                return _domainTagRepresentations[domainTag];
            }
        }

        public T this[string domainId]
        {
            get
            {
                if (!_domainIdRepresentations.ContainsKey(domainId))
                    return default(T);

                return _domainIdRepresentations[domainId];
            }
        }

        public RepresentationCollection()
            : this(new List<T>())
        {

        }

        public RepresentationCollection(IEnumerable<T> representations)
        {
            _domainIdRepresentations = new Dictionary<string, T>();
            _domainTagRepresentations = new Dictionary<long, T>();

            foreach (var representation in representations)
            {
                if (!_domainIdRepresentations.ContainsKey(representation.DomainId)
                    && !_domainTagRepresentations.ContainsKey(representation.DomainTag))
                {
                    _domainIdRepresentations.Add(representation.DomainId, representation);
                    _domainTagRepresentations.Add(representation.DomainTag, representation);
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
