using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace Asagram
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>()
            .ForCtorParam("FullName",
                opt => opt.MapFrom(x => x.FirstName + " " + x.LastName))

            .ForCtorParam("RoleName",
                opt => opt.MapFrom(src =>
                    string.Join(", ", src.UserRoles.Select(x => x.Role.RoleName))));

            //.ForCtorParam("Status",
            //    opt => opt.MapFrom(src => src.RefreshTokenExpiryTime > DateTime.Now));

            CreateMap<User, UserPasswordDTO>();
            CreateMap<UserForUpdateDTO, User>().ReverseMap();
            CreateMap<UserForRegistrationDTO, User>();
            CreateMap<Province, ProvinceDTO>().ReverseMap();
            CreateMap<CreateCityDTO, City>();

            CreateMap<City, CityDTO>()
                .ForMember(d => d.ProvinceName, o => o.MapFrom(s => s.Province.Name));

            CreateMap<City, CityForUpdateDTO>().ReverseMap();
            CreateMap<BankAccountForCreateDTO, BankAccount>().ReverseMap();
            CreateMap<BankAccount, BankAccountDTO>();
            CreateMap<UploadFileDTO, AppFile>();
            CreateMap<AppFile, UploadFileResponseDTO>();
            CreateMap<CustomerForCreateDTO, Customer>()
                .ForMember(dest => dest.PhoneNumbers, opt => opt.MapFrom(s =>
                s.PhoneNumbers.Select(p => new PhoneNumbers
                {
                    PhoneNumber = p,
                    
                })));
            CreateMap<Customer, CustomerDTO>()
                .ForMember(dest => dest.Phones, opt => opt.MapFrom(
                    s => s.PhoneNumbers.Select(p => p.PhoneNumber)));

            CreateMap<ContactForCreateDTO, Contact>()
                .ForMember(dest => dest.PhoneNumbers, opt => opt.MapFrom(s =>
                s.Phones.Select(p => new PhoneNumbers
                {
                    PhoneNumber = p,
                })));

            CreateMap<Contact, ContactDTO>()
                .ForMember(dest => dest.Phones, opt => opt.MapFrom(
                    s => s.PhoneNumbers.Select(p => p.PhoneNumber)));
            CreateMap<ProjectDTO, Project>().ReverseMap();
            CreateMap<ProgramForCreateDTO, ProgramEntity>();
            CreateMap<ProgramEntity, ProgramResponseDTO>().ReverseMap();
            CreateMap<ProfileCreateDTO, User>();
            CreateMap<User, ProfileDTO>();
            CreateMap<Province, ProvinceresponseDTO>();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Project, ProjectResponseDTO>().ReverseMap();
            CreateMap<LeaveForCreateDTO, Leave>();
            CreateMap<Leave, LeaveResponseDTO>();
            CreateMap<Leave, AdminLeaveResponseDTO>()
                .ForMember(dest => dest.Fullname, opt => opt.MapFrom(x => x.User.FirstName + " " + x.User.LastName));
            CreateMap<Leave, UserLeaveResponseDTO>();
            CreateMap<OverTimeForCreateDTO, OverTime>();
            CreateMap<OverTime, OverTimeResponseDTO>();
        }
    }
}
