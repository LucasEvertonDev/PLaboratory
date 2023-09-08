﻿using MS.Libs.Core.Domain.Models.Base;
using System.ComponentModel;

namespace PLaboratory.Core.Domain.Models.Users;

public class CreateUserModel : BaseModel
{
    [DefaultValue("lcseverton")]
    public string Username { get; set; }
    [DefaultValue("123456")]
    public string Password { get; set; }
    [DefaultValue("F97E565D-08AF-4281-BC11-C0206EAE06FA")]
    public string UserGroupId { get; set; }
    [DefaultValue("Lucas Everton Santos de Oliveira")]
    public string Name { get; set; }
    [DefaultValue("lcseverton@gmail.com")]
    public string Email { get; set; }
}

public class CreatedUserModel : BaseModel
{
    [DefaultValue("F97E565D-08AF-4281-FC11-C0206EAE06FA")]
    public string Id { get; set; }

    [DefaultValue("lcseverton")]
    public string Username { get; set; }

    [DefaultValue("F97E565D-08AF-4281-BC11-C0206EAE06FA")]
    public string UserGroupId { get; set; }
    [DefaultValue("Lucas Everton Santos de Oliveira")]
    public string Name { get; set; }
    [DefaultValue("lcseverton@gmail.com")]
    public string Email { get; set; }
}
