using System;
using System.Collections.Generic;

namespace SmartFridgeAPI.Models;

public partial class Холодильники
{
    public int IdХолодильника { get; set; }

    public string КодДоступа { get; set; } = null!;

    public virtual ICollection<Пользователи> Пользователиs { get; set; } = new List<Пользователи>();

    public virtual ICollection<ПродуктыВХолодильнике> ПродуктыВХолодильникеs { get; set; } = new List<ПродуктыВХолодильнике>();
}
