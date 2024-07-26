using System;
using System.Collections.Generic;

namespace Infrastructure.SqlServer;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string SharedEmail { get; set; } = null!;
}
