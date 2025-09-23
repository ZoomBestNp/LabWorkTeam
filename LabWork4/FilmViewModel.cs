using LabWork4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork4
{
    public class FilmViewModel
    {
        public int FilmId { get; set; }

        public string FilmName { get; set; } = null!;


        public string? AgeRating { get; set; }

        public decimal? Rating { get; set; }

        public string? GenreName { get; set; } = null!;

    }
}
