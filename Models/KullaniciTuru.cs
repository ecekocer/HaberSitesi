using System;
using System.Collections.Generic;

namespace HaberSitesi.Models;

public partial class KullaniciTuru
{
    public int KullaniciTuruId { get; set; }

    public string KullaniciTuruAdi { get; set; } = null!;

    public virtual ICollection<KullaniciTuruYetki> KullaniciTuruYetkis { get; set; } = new List<KullaniciTuruYetki>();

    public virtual ICollection<Kullanici> Kullanicis { get; set; } = new List<Kullanici>();
}
