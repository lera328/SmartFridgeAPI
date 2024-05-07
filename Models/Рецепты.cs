using System;
using System.Collections.Generic;

namespace SmartFridgeAPI.Models;

public partial class Рецепты
{
    public int IdРецепта { get; set; }

    public string Наименование { get; set; } = null!;

    public string ПоследовательностьДействий { get; set; } = null!;

    public int IdПользователя { get; set; }

    public virtual Пользователи IdПользователяNavigation { get; set; } = null!;

    public virtual ICollection<НаборыПродуктов> НаборыПродуктовs { get; set; } = new List<НаборыПродуктов>();
}
