using System;
using System.Collections.Generic;

namespace SmartFridgeAPI.Models;

public partial class Пользователи
{
    public int IdПользователя { get; set; }

    public string Email { get; set; } = null!;

    public string Пароль { get; set; } = null!;

    public int IdХолодильника { get; set; }

    public virtual Холодильники IdХолодильникаNavigation { get; set; } = null!;

    public virtual ICollection<Рецепты> Рецептыs { get; set; } = new List<Рецепты>();

    public virtual ICollection<УпотребленныеПродукты> УпотребленныеПродуктыs { get; set; } = new List<УпотребленныеПродукты>();
}
