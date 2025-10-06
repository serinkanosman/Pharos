using System;
using Pharos.Domain.Common;

namespace Pharos.Domain.Entities;

public class User : EntityBase
{
    public string FullName { get; set; }
    public string Email { get; set; }
    protected User() { }
    public User(string fullName, string email)
    {
        FullName = fullName;
        Email = email;
    }

    public List<Photo> Photos { get; set; }
    public List<Comment> Comments { get; set; }
 


}
