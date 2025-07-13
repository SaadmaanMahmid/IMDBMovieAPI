// Author: Choudhury Saadmaan Mahmid
// Created: July 12, 2025
// Description: Data model for the Top_Movies_2025 table.

using System;
using System.Collections.Generic;

namespace IMDBMovieAPI.Models;

public partial class TopMovies2025
{
    public int Rank { get; set; }

    public string Title { get; set; } = null!;

    public double? ImdbRating { get; set; }
}
