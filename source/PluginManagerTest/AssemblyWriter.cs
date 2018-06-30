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

using System.IO;
using System.Reflection;

namespace AgGateway.ADAPT.PluginManagerTest
{
    public class AssemblyWriter
    {
        public static void WriteTestPlugin(string directory, string fileName)
        {
            WritePlugin(directory, fileName, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "AgGateway.ADAPT.TestPlugin.dll"));
        }

        private static void WritePlugin(string directory, string fileName, string source)
        {
            Directory.CreateDirectory(directory);
            var pluginFileName = Path.Combine(directory, fileName);

            File.Copy(source, pluginFileName);
        }
    }
}
