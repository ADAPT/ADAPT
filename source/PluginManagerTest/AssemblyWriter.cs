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

namespace Adapt.PluginManagerTest
{
    public class AssemblyWriter
    {
        public static void WriteTestPlugin(string directory, string fileName)
        {
            WritePlugin(directory, fileName, Resources.Adapt_TestPlugin);
        }

        private static void WritePlugin(string directory, string fileName, byte[] plugin)
        {
            Directory.CreateDirectory(directory);
            var pluginFileName = Path.Combine(directory, fileName);

            File.WriteAllBytes(pluginFileName, plugin);
        }
    }
}
