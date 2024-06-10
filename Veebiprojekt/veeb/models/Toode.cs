using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace veeb.models;

public class Toode
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public double Rating { get; set; }
    public int Year { get; set; }

    public Toode(int id, string name, double rating, int year)
    {
        Id = id;
        Name = name;
        Rating = rating;
        Year = year;
    }
}
