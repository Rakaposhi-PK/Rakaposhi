var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Add authentication for validating Token
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    var key = System.Text.Encoding.UTF8.GetBytes("This is the private key");
    o.SaveToken = true;
    o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "http://maazk9119.github.io/",
        ValidAudience = "maazk9119.github.io",
        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key)
    };
});

builder.Services.AddSingleton<Rakaposhi.API.Core.JWTauthentication.IJWTManagerRepository, Rakaposhi.API.Core.JWTauthentication.JWTManagerRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    //c.SwaggerDoc(Rakaposhi.API.Core.Global.APIVERSION, new Microsoft.OpenApi.Models.OpenApiInfo
    //{
    //    Title = "Rakaposhi.Core.API",
    //    Version = Rakaposhi.API.Core.Global.APIVERSION,
    //    Description = "An open source Retail System",
    //    //TermsOfService = new Uri("maazk9119.github.io"),
    //    Contact = new Microsoft.OpenApi.Models.OpenApiContact
    //    {
    //        Name = "Maaz Khan",
    //        Email = "maaz.adil@systemsltd.com",
    //        Url = new Uri("https://twitter.com/maazk9119"),
    //    },
    //    License = new Microsoft.OpenApi.Models.OpenApiLicense
    //    {
    //        Name = "The MIT License (MIT)",
    //        Url = new Uri("http://opensource.org/licenses/mit-license.php"),
    //    }
    //});

    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme 
    { 
        Description = "JWT Token user Bearer {Insert required token}", 
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
             new string[]{}
        }

    });

});

//Inject Instance -Repository Factory
builder.Services.AddTransient<Rakaposhi.Business.Core.BaseRepository.IRepositoryFactory, Rakaposhi.Business.Core.DBRepository.DBRepositoryFactory>();

//Inject services: get all classes implementing IService
System.Reflection.Assembly assembly = typeof(Rakaposhi.Business.Core.Services.IService).Assembly;

IEnumerable<Type> iservice = assembly.GetTypes().
    Where(x => !x.IsAbstract &&
          x.IsClass          && 
          x.GetInterfaces().
          Contains(typeof(Rakaposhi.Business.Core.Services.IService)));

foreach(Type s in iservice)
{
    builder.Services.Add(new ServiceDescriptor(s, s, ServiceLifetime.Transient));
}


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

app.UseDeveloperExceptionPage();

app.Run();

