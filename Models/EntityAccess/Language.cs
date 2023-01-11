using HasB4bBase.Models.Helper;

namespace HasB4bBase.Models
{
    public class Language : BaseModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public bool IsActive { get; set; }
        public string Location { get; set; }

        public Language()
        {
            this.Id = 1;
            this.Name = "Türkçe";
            this.Status = true;
            this.IsActive = true;
            this.Location = "Turkey";
        }
    }
}