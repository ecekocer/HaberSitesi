using System;
using System.Collections.Generic;

namespace HaberSitesi.Models;

public partial class Menu
{
    public int MenuId { get; set; }

    public string MenuAdi { get; set; } = null!;

    public int MenuTuruId { get; set; }

    public string Icon { get; set; } = null!;

    public string Url { get; set; } = null!;

    public virtual MenuTuru MenuTuru { get; set; } = null!;
}
