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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AgGateway.ADAPT.PluginManager
{

    public interface IAssemblyResolver
    {
        string PluginDirectory { get; set; }
        Assembly LoadFromPluginDirectory(object sender, ResolveEventArgs args);
    }

    public class AssemblyResolver : IAssemblyResolver
    {
        public string PluginDirectory { get; set; }

        public Assembly LoadFromPluginDirectory(object sender, ResolveEventArgs args)
        {
            var assemblyName = new AssemblyName(args.Name).Name;
            var assemblyLocation = new List<string>(Directory.EnumerateFiles(PluginDirectory, assemblyName + ".dll", SearchOption.AllDirectories)).FirstOrDefault();
            if (assemblyLocation == null || !File.Exists(assemblyLocation))
            {
                return null;
            }
            return Assembly.LoadFrom(assemblyLocation);
        }
    }
}