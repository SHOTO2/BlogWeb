using System;
using System.Collections.Generic;

namespace BlogWeb.Models;

public partial class Posts
{
    public int PostId { get; set; }

    public string Title { get; set; } = null!;

    public string Contant { get; set; } = null!;

    public int UserId { get; set; }

    public virtual ICollection<Comments> Comments { get; set; } = new List<Comments>();

    public virtual Users User { get; set; } = null!;
}
