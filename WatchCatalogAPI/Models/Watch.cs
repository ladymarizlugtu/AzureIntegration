using System;
using System.Collections.Generic;

namespace WatchCatalogAPI.Models;

public partial class Watch
{
    public int WatchId { get; set; }

    public string? WatchName { get; set; }

    public double? Price { get; set; }

    public string? WatchDescription { get; set; }
}
