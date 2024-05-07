namespace DevFreela.Application.InputModel
{
    public class UpdateProjectInputModel
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal TotalCost { get; private set; }
    }
}