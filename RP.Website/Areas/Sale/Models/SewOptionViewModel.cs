namespace RP.Website.Models
{
    public class SewOptionViewModel
    {
        public string Id { get; set; }
        public string PatternName { get; set; }
        public string PatternImagePath { get; set; }
        public string PositionName { get; set; }
        public string Remark { get; set; }

        public int SelectedOption { get; set; }
        public string PatternId { get; set; }
        public string PositionId { get; set; }
    }
}