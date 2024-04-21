using System;
using System.Collections.Generic;

namespace HaberSitesi.Models;

public partial class KullaniciTuruYetki
{
    public int KullaniciTuruYetkiId { get; set; }

    public int KullaniciTuruId { get; set; }

    public int YetkiId { get; set; }

    public virtual KullaniciTuru KullaniciTuru { get; set; } = null!;

    public virtual Yetki Yetki { get; set; } = null!;
}
