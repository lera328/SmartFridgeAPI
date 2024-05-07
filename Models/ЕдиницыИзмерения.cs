using System;
using System.Collections.Generic;

namespace SmartFridgeAPI.Models;

public partial class ЕдиницыИзмерения
{
    public int IdЕдиницы { get; set; }

    public string Наименование { get; set; } = null!;
}
