using Person.Models;
using Person.Data;
using Microsoft.EntityFrameworkCore;

namespace Person.Routes;
public static class PersonRoutes
{
    public static void MapPersonRoutes(this WebApplication app)
    {
        var route = app.MapGroup("person");
        route.MapPost("", async (PersonRequest req, PersonContext context) =>
        {
            var person = new PersonModel(req.name);
            await context.AddAsync(person);
            await context.SaveChangesAsync();
        });

        route.MapGet("", async (PersonContext context) =>
        {
             // inferência de tipo com var (List<PeopleModel>)
            var peopleList = await context.People.ToListAsync(); //espera o context fazer a requisição no BD e armazena numa variavel do tipo var (inferencia de tipo)
            return Results.Ok(peopleList);
        });

        //app.MapGet("/person/{id}", async (Guid id, PersonContext context) =>
        //{
        //    var person = await context.People.FindAsync(id);
        //    if (person == null)
        //        return Results.NotFound();

        //    return Results.Ok(person);
        //});

        route.MapPut("{id:guid}", async (Guid id, PersonRequest req, PersonContext context) =>
        {
            var person = await context.People.FirstOrDefaultAsync(x=> x.Id == id);
            if (person == null)
                return Results.NotFound();
            person.ChangeName(req.name);
            await context.SaveChangesAsync();
            return Results.Ok(person);
        });


        route.MapDelete("{id:guid}", async (Guid id, PersonContext context) =>
        {
            var person = await context.People.FirstOrDefaultAsync(x => x.Id == id);
            if (person == null)
                return Results.NotFound();
            person.SetInactive();
            await context.SaveChangesAsync();
            return Results.Ok(person);
        });

    }
}