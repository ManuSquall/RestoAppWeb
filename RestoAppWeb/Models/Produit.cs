using System;
using System.Collections.Generic;

namespace RestoAppWeb.Models;

public partial class Produit
{
    public int Id { get; set; }

    public string Libelle { get; set; } = null!;

    public int Prix { get; set; }

    public virtual ICollection<CommandeDetail> CommandeDetails { get; set; } = new List<CommandeDetail>();
}
