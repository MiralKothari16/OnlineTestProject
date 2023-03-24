using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnlineTest.Model;
using OnlineTest.Model.Interface;
using OnlineTest.Model.Repository;
using OnlineTest.Services.Interface;
using OnlineTest.Services.Services;
using OnlineTest.Services.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using OnlineTest.Services.AutoMapperProfile;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var connectionstring = builder.Configuration.GetConnectionString("SQLAuth");
//builder.Services.AddDbContext<OnlineTestContext>(x=>x.UseSqlServer(connectionstring));
//builder.Services.AddDbContext<OnlineTestContext>(x=>x.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddDbContext<OnlineTestContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLAuth"), b => b.MigrationsAssembly("OnlineTest.Model"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITechnologyService,TechnologyService>();
builder.Services.AddScoped<ITechnologyRepository,TechnologyRepository>();
builder.Services.AddScoped<ITestService,TestService>();
builder.Services.AddScoped<ITestRepository, TestRepository>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IAnswerService, AnswerService>();
builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
builder.Services.AddScoped<IQuestionAnswerMappingRepository, QuestionAnswerMappingRepository>();
builder.Services.AddScoped<ITestEmailLinkRepository, TestEmailLinkRepository>();
builder.Services.AddScoped<IHasherService,HasherService>();
builder.Services.AddScoped<IUserRoleRepository,UserRoleRepository>();
builder.Services.AddScoped<IUserRoleService,UserRoleService>();




builder.Services.Configure<JWTConfigDTO>(builder.Configuration.GetSection("JWTConfig"));
builder.Services.AddScoped<IRTokenRepository, RTokenRepository>();
builder.Services.AddScoped<IRTokenService, RTokenService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OnlineTest", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                        Enter 'Bearer' [space] and then your token in the text input below.
                        \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        { new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
            {
                    Type=ReferenceType.SecurityScheme,
                    Id ="Bearer",
            },
            Scheme="oauth2",
            Name="Bearer",
            In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});
  ConfigureJwtAuthService(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
void ConfigureJwtAuthService(IServiceCollection services)
{
    var audienceConfig = builder.Configuration.GetSection("JWTConfig");
    var symmetricKeyAsBase64 = audienceConfig["SecretKey"];
    var keyByteArray=Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
    var signingKey = new SymmetricSecurityKey(keyByteArray);

    var TokenvalidationParameter = new TokenValidationParameters
    {
        // The signing key must match!
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = signingKey,

        // Validate the JWT Issuer (iss) claim
        ValidateIssuer = true,
        ValidIssuer = audienceConfig["Issuer"],

        //Validate the JWT Audiance (Audo) claim
        ValidateAudience= true,
        ValidAudience = audienceConfig["Aud"],

        //validate the token expire
        ValidateLifetime = true,

        ClockSkew=TimeSpan.Zero   
    };

    services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(o =>
    {
        o.RequireHttpsMetadata = false;
        o.SaveToken = true;
        o.TokenValidationParameters = TokenvalidationParameter;
    });
}