namespace Academy.Models.VievModels
{
    public class DirectionsGroupsStudents
    {
        public IEnumerable<Direction> Directions { get; set; }
        public IEnumerable<Group> Groups { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
