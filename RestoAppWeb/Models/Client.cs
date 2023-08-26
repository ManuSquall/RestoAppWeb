using System;
using System.Collections.Generic;

namespace RestoAppWeb.Models;

public partial class Client
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Telephone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();
}
