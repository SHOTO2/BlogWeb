using System;
using System.Collections.Generic;

namespace BlogWeb.Models;

public partial class Comments
{
    public int CommentId { get; set; }

    public string Contant { get; set; } = null!;

    public int UserId { get; set; }

    public int PostsId { get; set; }

    public virtual Posts Posts { get; set; } = null!;

    public virtual Users User { get; set; } = null!;
}
