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
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace AgGateway.ADAPT.Representation.RepresentationSystem
{
  public class RepresentationManager
  {
    private static RepresentationManager _instance;
    private static readonly object BlueThreadLock = new Object();

    private static string _representationSystemDataLocation = null;

    public static string RepresentationSystemDataLocation
    {
      get
      {
        if (_representationSystemDataLocation == null)
        {
          var assemblyLocation = AppDomain.CurrentDomain.BaseDirectory;
          var repSystemXml = Path.Combine(assemblyLocation, "Resources", "RepresentationSystem.xml");
          return repSystemXml;
        }
        else
        {
          return _representationSystemDataLocation;
        }
      }
      set { _representationSystemDataLocation = value; }
    }

    public static RepresentationManager Instance
    {
      get
      {
        if (_instance == null)
          lock (BlueThreadLock)
          {
            if (_instance == null)
              _instance = new RepresentationManager();
          }
        return _instance;
      }
    }

    public RepresentationCollection<Representation> Representations { get; private set; }

    private RepresentationManager()
    {
      var representationSystem = DeserializeRepresentationSystem();
      Representations = GetRepresentations(representationSystem);
    }

    private static RepresentationCollection<Representation> GetRepresentations(Generated.RepresentationSystem representationSystem)
    {
      var numericRepresentations = representationSystem.Representations.NumericRepresentation.Select(v => new NumericRepresentation(v));
      var enumeratedRepresentations = representationSystem.Representations.EnumeratedRepresentation.Select(d => new EnumeratedRepresentation(d));
      var allRepresentations = numericRepresentations.Union<Representation>(enumeratedRepresentations);
      return new RepresentationCollection<Representation>(allRepresentations);
    }

    private static Generated.RepresentationSystem DeserializeRepresentationSystem()
    {
      var serializer = new XmlSerializer(typeof(Generated.RepresentationSystem));

      var xmlStringBytes = File.ReadAllBytes(RepresentationSystemDataLocation);
      using (var stream = new MemoryStream(xmlStringBytes))
      {
        return (Generated.RepresentationSystem)serializer.Deserialize(stream);
      }
    }
  }
}
