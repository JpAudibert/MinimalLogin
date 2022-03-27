using Microsoft.EntityFrameworkCore;
using MinimalLogin.Users.EFCore;
using MinimalLogin.Users.Factories;
using MinimalLogin.Users.InputModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("postgre");
builder.Services.AddDbContext<UsersContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseCors();

bool authenticated = false;

app.MapPost("/login", async (UsersContext usersContext, LoginInputModel loginInputModel) =>
{
    var user = await usersContext.Users.Where(user => user.UserName == loginInputModel.UserName && user.Password == loginInputModel.Password).FirstOrDefaultAsync();

    if (user == null)
        return Results.Unauthorized();

    authenticated = true;

    return Results.Ok();
});

app.MapGet("/users", async (UsersContext usersContext) =>
{
    if (!authenticated)
        return Results.Unauthorized();

    return Results.Json(await usersContext.Users.ToListAsync());
});

app.MapGet("/users/{id}", async (UsersContext usersContext, string id) =>
{
    if (!authenticated)
        return Results.Unauthorized();

    return Results.Json(await usersContext.Users.Where(user => user.Id == id).ToListAsync());
});

app.MapPost("/users", async (UsersContext usersContext, UserInputModel userInputModel) =>
{
    var usersCount = usersContext.Users.Count();

    if (usersCount > 0)
    {
        if (!authenticated)
            return Results.Unauthorized();
    }

    var newUser = UserFactory.DefaultFactory(userInputModel);

    await usersContext.Users.AddAsync(newUser);

    await usersContext.SaveChangesAsync();

    return Results.Ok(newUser);
});

app.MapPut("/users/{id}", async (UsersContext usersContext, UserInputModel userInputModel, string id) =>
{
    if (!authenticated)
        return Results.Unauthorized();

    var user = await usersContext.Users.FindAsync(id);

    if (user == null)
    {
        return Results.NoContent();
    }

    user.Name = userInputModel.Name;
    user.Birthday = userInputModel.Birthday;
    user.Gender = userInputModel.Gender;
    user.PreferedProgramingLanguage = userInputModel.PreferedProgramingLanguage;
    user.UserName = userInputModel.UserName;
    user.Password = userInputModel.Password;

    await usersContext.SaveChangesAsync();

    return Results.Ok(user);
});

app.MapDelete("/users/{id}", async (UsersContext usersContext, string id) =>
{
    if (!authenticated)
        return Results.Unauthorized();

    var user = await usersContext.Users.FindAsync(id);

    if (user == null)
    {
        return Results.NoContent();
    }

    usersContext.Users.Remove(user);

    await usersContext.SaveChangesAsync();

    return Results.Ok();
});

app.Run();