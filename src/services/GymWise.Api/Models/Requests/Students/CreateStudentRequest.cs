﻿using GymWise.Student.Domain.Entities;

namespace GymWise.Api.Models.Requests.Students
{
    public record CreateStudentRequest(
        Guid Id,
        string FirstName,
        string LastName,
        string UserName,
        string Email,
        string PhoneNumber,
        DateTime DateOfBirth,
        string Document,
        Gender Gender)
    {
    }
}
