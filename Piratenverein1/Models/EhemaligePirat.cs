using System;
using System.Collections.Generic;

namespace Piratenverein1.Models;

public partial class EhemaligePirat
{
    public int Id { get; set; }

    public string Vorname { get; set; } = null!;

    public string Nachname { get; set; } = null!;

    public int? Alt { get; set; }
}
