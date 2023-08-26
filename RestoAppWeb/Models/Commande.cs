using System;
using System.Collections.Generic;

namespace RestoAppWeb.Models;

public partial class Commande
{
    public int Id { get; set; }

    public string Numero { get; set; } = null!;

    public string ModePayement { get; set; } = null!;

    public int Total { get; set; }

    public int ClientId { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<CommandeDetail> CommandeDetails { get; set; } = new List<CommandeDetail>();
}
