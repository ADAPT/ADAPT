/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Keith Reimer - initial API and implementation and/or initial documentation
  *******************************************************************************/

using System;
using System.IO;

namespace AgGateway.ADAPT.Representation.Resources
{
    public static class ResourcePathUtil
    {
        public const string ResourcesFolder = "Resources";

        public static string FullResourcePath(string fileName)
        {
            var codeBase = typeof(ResourcePathUtil).Assembly.CodeBase;
            var codeBaseUrl = new Uri(codeBase);
            var assemblyDir = Path.GetDirectoryName(codeBaseUrl.LocalPath);

            return Path.Combine(assemblyDir, ResourcesFolder, fileName);
        }
    }
}
