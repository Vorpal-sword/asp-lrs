using System.Text;

namespace asp_lrs
{
    public class Company
    {
        public string Name { get; set; }
        public string Industry { get; set; }
        public string Location { get; set; }

        public string GetAllProperties()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Industry: {Industry}");
            sb.AppendLine($"Location: {Location}");
            return sb.ToString();
        }
    }
}
