using System;
using System.Collections.Generic;

namespace HaberSitesi.Models;

public partial class MenuTuru
{
    public int MenuTuruId { get; set; }

    public string MenuTuruAdi { get; set; } = null!;

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();
}
