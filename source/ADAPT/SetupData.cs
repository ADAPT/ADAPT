using System.Collections.Generic;
using System.ComponentModel;

namespace AgGateway.ADAPT.ApplicationDataModel
{
    public class SetupData
    {
        public string Name;

        public List<TimeScope> TimeScopes;

        public List<PersonRole> Persons;

        public List<Container> Containers;

        public List<FieldBoundary> FieldBoundaries;

        public List<Note> Notes;

        public List<Grower> Growers;

        public List<Farm> Farms;

        public List<Field> Fields;

        public List<CropZone> CropZones;
    }
}
