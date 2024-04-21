using System;
using System.Collections.Generic;

namespace HaberSitesi.Models;

public partial class Kategori
{
    public int KategoriId { get; set; }

    public string KategoriAdi { get; set; } = null!;

    public virtual ICollection<Haber> Habers { get; set; } = new List<Haber>();
}
