using System;
using System.Collections.Generic;

namespace LabWork4.Models;

public partial class Film
{
    public int FilmId { get; set; }

    public string FilmName { get; set; } = null!;

    public int? GenreId { get; set; }

    public string? AgeRating { get; set; }

    public int Rating { get; set; }

    public virtual Genre? Genre { get; set; }
}
