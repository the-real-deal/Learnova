using System;
using System.Collections.Generic;

namespace Learnova.Entities;

public partial class TipiAccount
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
