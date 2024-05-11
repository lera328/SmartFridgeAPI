using System;
using System.Collections.Generic;

namespace SmartFridgeAPI.Models;

public partial class СпискиПокупок
{
    public int IdСпПродукта { get; set; }

    public int IdХолодильника { get; set; }

    public string Наименование { get; set; } = null!;

    public bool Статус { get; set; }
}
