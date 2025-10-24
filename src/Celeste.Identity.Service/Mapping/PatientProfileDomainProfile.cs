namespace Celeste.Identity.Application.Mapping;

using Celeste.Identity.Common.Responses;
using Celeste.Identity.Core.Domain;
using AutoMapper;
using Celeste.Identity.Application.Features.Commands;

/// <summary>
///     The AutoMapper profile for PatientProfile domain mapping.
/// </summary>
public class PatientProfileDomainProfile : Profile
{
    /// <summary>
    ///     Initialize a new instance of the <see cref="PatientProfileDomainProfile"/> class.
    /// </summary>
    public PatientProfileDomainProfile()
    {
        //<-- Domain to Reponse Mapping -->
        CreateMap<User, UserResponse>().ReverseMap();

        //<-- Command to Domain Model Mapping -->
        CreateMap<CreateUserCommand, User>().ReverseMap();

    }
}
