﻿namespace DoctorVisitReservation.Application.Models.Identity;

public abstract class UserBase
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}