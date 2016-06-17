using System.Text;

namespace AgGateway.ADAPT.RepresentationTest.ClassGenerators
{
    public class RepresentationTagListGenerator : ClassGenerator
    {
        private const string RepresentationTagListPattern = "        public const int {0} = {1};";

        protected override string Name
        {
            get
            {
                return "RepresentationTagList";
            }
        }

        protected override bool IsEnum
        {
            get
            {
                return false;
            }
        }

        protected override void Append(Representation.RepresentationSystem.EnumeratedRepresentation definedRepresentation, StringBuilder stringBuilder)
        {
            Append(definedRepresentation, stringBuilder);
        }

        protected override void Append(Representation.RepresentationSystem.NumericRepresentation representation, StringBuilder stringBuilder)
        {
            Append(representation, stringBuilder);
        }

        private void Append(Representation.RepresentationSystem.Representation representation, StringBuilder stringBuilder)
        {
            string representationName = representation.DomainId.Replace("\r", "")
                .Replace("[", "")
                .Replace("]", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("-", "")
                .Replace("–", "")
                .Replace(" ", "");
            stringBuilder.AppendFormat(RepresentationTagListPattern, representationName, representation.DomainTag);
            stringBuilder.Append("\n\n");
        }
    }
}