﻿namespace svc.system.center.domain.Models.Dtos.Comman;

public class LoginUserDto
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required string Email { get; set; }

    public required string Surname { get; set; }

    public required string MobileNo { get; set; }

}
