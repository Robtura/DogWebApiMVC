namespace DogApiMVCProject.Models
{
    public class RegForm
    {
        public long Registrationid { get; set; }
        public string? DogName { get; set; }
        public string? DogBreed { get; set; }
        public string? DogAge { get; set; }
        public double DogHeight { get; set; }
        public double DogLength { get; set; }
        public int DogWeight { get; set; }
    }
}
