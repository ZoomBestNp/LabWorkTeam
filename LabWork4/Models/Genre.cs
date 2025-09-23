using System;
using System.Collections.Generic;

namespace LabWork4.Models;

public partial class Genre
{
    public int GenreId { get; set; }

    public string GenreName { get; set; } = null!;

    public virtual ICollection<Film> Films { get; set; } = new List<Film>();
}
