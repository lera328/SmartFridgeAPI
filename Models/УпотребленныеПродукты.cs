using System;
using System.Collections.Generic;

namespace SmartFridgeAPI.Models;

public partial class УпотребленныеПродукты
{
    public int IdУпотребленногоПродукта { get; set; }

    public int IdПользователя { get; set; }

    public int IdПродукта { get; set; }

    public int? Количество { get; set; }

    public DateOnly? Дата { get; set; }

    public int? IdПриемаПищи { get; set; }

    public virtual Пользователи IdПользователяNavigation { get; set; } = null!;

    public virtual ПриемыПищи? IdПриемаПищиNavigation { get; set; }

    public virtual ПродуктыВХолодильнике IdПродуктаNavigation { get; set; } = null!;
}
