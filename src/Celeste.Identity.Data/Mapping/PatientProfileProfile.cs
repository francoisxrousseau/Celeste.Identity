namespace Celeste.Identity.Data.Mapping;

using AutoMapper;
using Celeste.Identity.Core.Domain;
using Celeste.Identity.Data.Documents;

/// <summary>
///     The AutoMapper profile for PatientProfile mapping.
/// </summary>
public class PatientProfileProfile : Profile
{
    /// <summary>
    ///     Initialize a new instance of the <see cref="PatientProfileProfile"/> class.
    /// </summary>
    public PatientProfileProfile()
    {
        //<-- Document to Domain Model Mapping -->
        CreateMap<UserDocument, User>().ReverseMap();
    }
}
