using System;
using System.Collections.Generic;

namespace HaberSitesi.Models;

public partial class Kullanici
{
    public int KullaniciId { get; set; }

    public string Email { get; set; } = null!;

    public string Parola { get; set; } = null!;

    public int KullaniciTuruId { get; set; }

    public DateTime KayitTarihi { get; set; }

    public virtual KullaniciTuru KullaniciTuru { get; set; } = null!;
}
