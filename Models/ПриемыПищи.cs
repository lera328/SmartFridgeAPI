using System;
using System.Collections.Generic;

namespace SmartFridgeAPI.Models;

public partial class ПриемыПищи
{
    public int IdПриемаПищи { get; set; }

    public string Наименование { get; set; } = null!;

    public virtual ICollection<УпотребленныеПродукты> УпотребленныеПродуктыs { get; set; } = new List<УпотребленныеПродукты>();
}
