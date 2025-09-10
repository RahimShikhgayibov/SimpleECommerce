using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minio;
using Minio.AspNetCore.HealthChecks;

namespace SimpleECommerce.Application;

public static class ServiceExtensions
{
    public static void RegisterCustomServices(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterServices(services);
        RegisterValidators(services);
        RegisterMappers(services);
        RegisterHelpers(services, configuration);
    }
    
    private static void RegisterHelpers(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddTransient<IJwtHelper, JwtHelper>();
        //services.AddTransient<ICacheHelper, CacheHelper>();
        //services.AddTransient<IStorageHelper, StorageHelper>();
        //
        //services.AddAuthentication("Bearer")
        //    .AddScheme<BasicAuthenticationOptions, CustomAuthenticationHandler>("Bearer", null);
        //
        //services.AddDistributedMemoryCache();
        //
        //services.AddTransient<IMailHelper, MailHelper>();
        //services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
        //
        //MinIoSettings settings = configuration.GetSection("MinIO").Get<MinIoSettings>()!;
        //
        //services.AddSingleton(_ => new MinioClient()
        //    .WithEndpoint(settings.EndPoint)
        //    .WithCredentials(settings.AccessKey, settings.SecretKey)
        //    .Build());
        
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddHealthChecks()
            .AddMinio(sp => sp.GetRequiredService<IMinioClient>());
        
        services.AddSignalR();
        //services.AddTransient<NotificationHub>();
        //services.AddTransient<TicketHub>();
    }

    private static void RegisterServices(IServiceCollection services)
    {
        //services.AddTransient<ISubjectService, SubjectService>();
        //services.AddTransient<ISubjectPlanService, SubjectPlanService>();
        //services.AddTransient<IUserService, UserService>();
        //services.AddTransient<IRoleService, RoleService>();
        //services.AddTransient<IObjectService, ObjectService>();
        //services.AddTransient<IPermissionService, PermissionService>();
        //services.AddTransient<IPositionService, PositionService>();
        //services.AddTransient<INotificationService, NotificationService>();
        //services.AddTransient<ITicketService, TicketService>();
        //services.AddTransient<ITicketService, TicketService>();
        //services.AddTransient<IFaqService, FaqService>();
    }

    private static void RegisterValidators(IServiceCollection services)
    {
        // #region Users
        //
        // services.AddTransient<IValidator<UserCreateDto>, UserCreateValidator>();
        // services.AddTransient<IValidator<UserUpdateProfileDto>, UserUpdateProfileValidator>();
        // services.AddTransient<IValidator<UserUpdateDto>, UserUpdateValidator>();
        // services.AddTransient<IValidator<UserResetDto>, UserResetValidator>();
        // services.AddTransient<IValidator<UserChangePasswordDto>, UserChangePasswordValidator>();
        // services.AddTransient<IValidator<UserSubjectCreateDto>, UserSubjectCreateValidator>();
        // services.AddTransient<IValidator<UserSubjectUpdateDto>, UserSubjectUpdateValidator>();
        // services.AddTransient<IValidator<UserSignInDto>, UserSignInValidator>();
        //
        // #endregion

        //services.AddTransient<IValidator<UserSessionCreateDto>, UserSessionCreateValidator>();

        //services.AddTransient<IValidator<RoleCreateDto>, RoleCreateValidator>();
        //services.AddTransient<IValidator<RoleUpdateDto>, RoleUpdateValidator>();
        
        //services.AddTransient<IValidator<PositionCreateDto>, PositionCreateValidator>();
        //services.AddTransient<IValidator<PositionUpdateDto>, PositionUpdateValidator>();
        //services.AddTransient<IValidator<NotificationCreateDto>, NotificationCreateValidator>();
        //services.AddTransient<IValidator<NotificationRequestCreateDto>, NotificationRequestCreateValidator>();
        //services.AddTransient<IValidator<NotificationTicketCreateDto>, NotificationTicketCreateValidator>();
        //services.AddTransient<IValidator<NotificationObjectCreateDto>, NotificationObjectCreateValidator>();
        //services.AddTransient<IValidator<TicketCreateDto>, TicketCreateValidator>();
        //services.AddTransient<IValidator<TicketMessageCreateDto>, TicketMessageCreateValidator>();
        //services.AddTransient<IValidator<FaqItemCreateDto>, FaqItemCreateValidator>();
        //services.AddTransient<IValidator<FaqItemUpdateDto>, FaqItemUpdateValidator>();
    }

    private static void RegisterMappers(IServiceCollection services)
    {
         // MapperConfiguration mappingConfig = new MapperConfiguration(mc =>
         // {
         //     //mc.AddProfile(new UserMapper());
         //     //mc.AddProfile(new RoleMapper());
         //     //mc.AddProfile(new PositionMapper());
         //     //mc.AddProfile(new NotificationMapper());
         //     //mc.AddProfile(new RequestMapper());
         //     //mc.AddProfile(new TicketMapper());
         //     //mc.AddProfile(new FaqMapper());
         // });

        //IMapper mapper = mappingConfig.CreateMapper();
        //services.AddSingleton(mapper);
    }
}