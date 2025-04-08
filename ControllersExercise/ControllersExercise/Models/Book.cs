using Microsoft.AspNetCore.Mvc;

namespace ControllersExercise.Models
{
    public class Book
    {
        [FromRoute]
        public int BookId { get; set; }
        [FromQuery]
        public string? Author { get; set; }

        public override string ToString()
        {
            return $"The book id is: {BookId}, the author is: {Author}";
        }
    }
}
