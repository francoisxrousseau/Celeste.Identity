namespace Celeste.Identity.Data.Mapping;

using AutoMapper;
using Celeste.Identity.Core.Domain;
using Celeste.Identity.Data.Documents;

/// <summary>
///     The AutoMapper profile for PatientProfile database mapping.
/// </summary>
public class PatientProfileDocumentProfile : Profile
{
    /// <summary>
    ///     Initialize a new instance of the <see cref="PatientProfileDocumentProfile"/> class.
    /// </summary>
    public PatientProfileDocumentProfile()
    {
        //<-- Document to Domain Model Mapping -->
        CreateMap<UserDocument, User>().ReverseMap();
    }
}
