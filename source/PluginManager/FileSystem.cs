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

namespace Adapt.PluginManager
{
    public interface IFileSystem
    {
        IList<string> GetFiles(string directoryLocation, string searchPattern);
        IList<string> GetSubDirectories(string parentDirectory);
    }

    public class FileSystem : IFileSystem
    {
        public IList<string> GetFiles(string directoryLocation, string searchPattern)
        {
            if (!Directory.Exists(directoryLocation))
                return new List<string>();

            return Directory.EnumerateFiles(directoryLocation, searchPattern).ToList();
        }

        public IList<string> GetSubDirectories(string parentDirectory)
        {
            if (string.IsNullOrEmpty(parentDirectory)
                || !Directory.Exists(parentDirectory))
                return new List<string>();

            return Directory.GetDirectories(parentDirectory);
        }
    }
}
