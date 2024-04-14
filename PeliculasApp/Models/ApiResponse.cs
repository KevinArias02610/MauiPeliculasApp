namespace PeliculasApp.Models
{
    public class ApiResponse
    {
        public int Page { get; set; }
        public List<Movie> Results { get; set; }
    }
}
