using System;
using System.Collections.Generic;

namespace HaberSitesi.Models;

public partial class Haber
{
    public int HaberId { get; set; }

    public string Baslik { get; set; } = null!;

    public int KategoriId { get; set; }

    public DateTime Tarih { get; set; }

    public string Gorsel { get; set; } = null!;

    public string Metin { get; set; } = null!;

    public virtual Kategori Kategori { get; set; } = null!;
}
