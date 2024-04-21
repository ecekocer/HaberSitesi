using System;
using System.Collections.Generic;

namespace HaberSitesi.Models;

public partial class Yetki
{
    public int YetkiId { get; set; }

    public string? YetkiAdi { get; set; }

    public virtual ICollection<KullaniciTuruYetki> KullaniciTuruYetkis { get; set; } = new List<KullaniciTuruYetki>();
}
