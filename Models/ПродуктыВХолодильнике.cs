using System;
using System.Collections.Generic;

namespace SmartFridgeAPI.Models;

public partial class ПродуктыВХолодильнике
{
    public int IdПродукта { get; set; }

    public int? IdХолодильника { get; set; }

    public string? Наименование { get; set; }

    public int IdЕдиницы { get; set; }

    public int Остаток { get; set; }

    public DateOnly? ДатаДобавления { get; set; }

    public int? СрокГодности { get; set; }

    public int Б { get; set; }

    public int Ж { get; set; }

    public int У { get; set; }

    public int Кк { get; set; }

    public virtual Холодильники? IdХолодильникаNavigation { get; set; }

    public virtual ICollection<УпотребленныеПродукты> УпотребленныеПродуктыs { get; set; } = new List<УпотребленныеПродукты>();
}
