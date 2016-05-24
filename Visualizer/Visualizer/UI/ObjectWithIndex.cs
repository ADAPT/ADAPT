using System;

namespace AgGateway.ADAPT.Visualizer.UI
{
    internal class ObjectWithIndex
    {
        public ObjectWithIndex()
        {
            
        }

        public ObjectWithIndex(int applicationDataModelIndex, Object element)
        {
            ApplicationDataModelIndex = applicationDataModelIndex;
            Element = element;
        }
        public int ApplicationDataModelIndex { get; set; }

        public Object Element { get; set; }
    }
}