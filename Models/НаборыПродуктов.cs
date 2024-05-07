using System;
using System.Collections.Generic;

namespace SmartFridgeAPI.Models;

public partial class НаборыПродуктов
{
    public int IdПродукта { get; set; }

    public int IdРецепта { get; set; }

    public string Наименование { get; set; } = null!;

    public int? Количество { get; set; }

    public int? IdЕдиницы { get; set; }

    public virtual Рецепты IdРецептаNavigation { get; set; } = null!;
}
