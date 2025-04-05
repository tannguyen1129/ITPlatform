using AutoMapper;
using BusinessObjects;
using ITPlatformUMT.DTOs.Clients;
using ITPlatformUMT.DTOs.Freelancers;
using ITPlatformUMT.DTOs.Projects;
using ITPlatformUMT.DTOs.Milestones;
using ITPlatformUMT.DTOs.Submittions;
using ITPlatformUMT.DTOs.Skills;
using ITPlatformUMT.DTOs.Applications;
using ITPlatformUMT.DTOs.ExpertiseProfiles;
using ITPlatformUMT.DTOs.Certifications;
using ITPlatformUMT.DTOs.Locations;
using ITPlatformUMT.DTOs.Subscriptions;
using ITPlatformUMT.DTOs.SkillRequirements;
using ITPlatformUMT.DTOs.SkillInProfiles;
using ITPlatformUMT.DTOs.Packages;
using ITPlatformUMT.DTOs.Accounts;
using ITPlatformUMT.DTOs.Chat;
using ITPlatformUMT.DTOs.Messages;



namespace Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<AccountCreateDTO, Account>();
            CreateMap<AccountUpdateDTO, Account>();


            // Mapping cho Client
            CreateMap<ClientCreateDTO, Client>()
                .ForMember(dest => dest.LocationList, opt => opt.Ignore())
                .ForMember(dest => dest.ProjectList, opt => opt.Ignore())
                .ForMember(dest => dest.SubscriptionList, opt => opt.Ignore());

            CreateMap<ClientUpdateDTO, Client>()
                .ForMember(dest => dest.ClientID, opt => opt.Ignore())
                .ForMember(dest => dest.AccountID, opt => opt.Ignore())
                .ForMember(dest => dest.LocationList, opt => opt.Ignore())
                .ForMember(dest => dest.ProjectList, opt => opt.Ignore())
                .ForMember(dest => dest.SubscriptionList, opt => opt.Ignore());

           
            CreateMap<FreelancerCreateDTO, Freelancer>()
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.BirthDate, DateTimeKind.Utc)));
            CreateMap<FreelancerUpdateDTO, Freelancer>()
                .ForMember(dest => dest.FreelancerID, opt => opt.Ignore()); 

            CreateMap<ProjectCreateDTO, Project>()
                .ForMember(dest => dest.MilestoneList, opt => opt.Ignore())
                .ForMember(dest => dest.ApplicationList, opt => opt.Ignore())
                .ForMember(dest => dest.SkillRequirementList, opt => opt.Ignore())
                .ForMember(dest => dest.Client, opt => opt.Ignore());

            CreateMap<ProjectUpdateDTO, Project>()
                .ForMember(dest => dest.ProjectID, opt => opt.Ignore())
                .ForMember(dest => dest.ClientID, opt => opt.Ignore())
                .ForMember(dest => dest.MilestoneList, opt => opt.Ignore())
                .ForMember(dest => dest.ApplicationList, opt => opt.Ignore())
                .ForMember(dest => dest.SkillRequirementList, opt => opt.Ignore())
                .ForMember(dest => dest.Client, opt => opt.Ignore());

            CreateMap<MilestoneCreateDTO, Milestone>()
                .ForMember(dest => dest.Project, opt => opt.Ignore())
                .ForMember(dest => dest.SubmittionList, opt => opt.Ignore());

            CreateMap<MilestoneUpdateDTO, Milestone>()
                .ForMember(dest => dest.MilestoneID, opt => opt.Ignore())
                .ForMember(dest => dest.Project, opt => opt.Ignore())
                .ForMember(dest => dest.SubmittionList, opt => opt.Ignore());

            CreateMap<SubmittionCreateDTO, Submittion>()
                .ForMember(dest => dest.Freelancer, opt => opt.Ignore())
                .ForMember(dest => dest.Milestone, opt => opt.Ignore());

            CreateMap<SubmittionUpdateDTO, Submittion>()
                .ForMember(dest => dest.SubmittionID, opt => opt.Ignore())
                .ForMember(dest => dest.Freelancer, opt => opt.Ignore())
                .ForMember(dest => dest.Milestone, opt => opt.Ignore());
            
            CreateMap<SkillCreateDTO, Skill>();
            CreateMap<SkillUpdateDTO, Skill>();

            CreateMap<ApplicationCreateDTO, Application>();
            CreateMap<ApplicationUpdateDTO, Application>();

            CreateMap<ExpertiseProfileCreateDTO, ExpertiseProfile>()
                .ForMember(dest => dest.CertificationList, opt => opt.Ignore())
                .ForMember(dest => dest.SkillInProfileList, opt => opt.Ignore());

            CreateMap<ExpertiseProfileUpdateDTO, ExpertiseProfile>()
                .ForMember(dest => dest.CertificationList, opt => opt.Ignore())
                .ForMember(dest => dest.SkillInProfileList, opt => opt.Ignore());
            
            CreateMap<CertificationCreateDTO, Certification>();
            CreateMap<CertificationUpdateDTO, Certification>()
                .ForMember(dest => dest.CertID, opt => opt.Ignore());

            CreateMap<LocationCreateDTO, Location>()
                .ForMember(dest => dest.LocationID, opt => opt.Ignore())
                .ForMember(dest => dest.Client, opt => opt.Ignore());

            CreateMap<LocationUpdateDTO, Location>()
                .ForMember(dest => dest.LocationID, opt => opt.Ignore())
                .ForMember(dest => dest.Client, opt => opt.Ignore());

            CreateMap<SubscriptionCreateDTO, Subscription>();
            CreateMap<SubscriptionUpdateDTO, Subscription>();

            CreateMap<SkillRequirementCreateDTO, SkillRequirement>()
                .ForMember(dest => dest.Skill, opt => opt.Ignore())
                .ForMember(dest => dest.Project, opt => opt.Ignore());

            CreateMap<SkillRequirementUpdateDTO, SkillRequirement>()
                .ForMember(dest => dest.Skill, opt => opt.Ignore())
                .ForMember(dest => dest.Project, opt => opt.Ignore());

            CreateMap<SkillInProfileCreateDTO, SkillInProfile>();
            CreateMap<SkillInProfileUpdateDTO, SkillInProfile>();

            CreateMap<PackageCreateDTO, Package>();
            CreateMap<PackageUpdateDTO, Package>();

             // Chat Mapping
            CreateMap<Chat, ChatResponseDTO>();
            CreateMap<ChatCreateDTO, Chat>();

        // Message Mapping
            CreateMap<Message, MessageResponseDTO>();
            CreateMap<MessageCreateDTO, Message>();
            CreateMap<MessageUpdateDTO, Message>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));


        }
    }
}
