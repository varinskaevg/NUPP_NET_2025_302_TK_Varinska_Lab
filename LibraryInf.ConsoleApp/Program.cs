using Library.Infrastructure;
using Library.Infrastructure.Models;
using Library.Infrastructure.Repositories;
using Library.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var options = new DbContextOptionsBuilder<LibraryContext>()
    .UseSqlite("Data Source=library.db")
    .Options;

// Ініціалізація контексту
using var context = new LibraryContext(options);

// Застосування міграцій
context.Database.Migrate();

// Створення репозиторію та сервісу
var memberRepository = new Repository<LibraryMemberModel>(context);
var memberService = new CrudServiceAsync<LibraryMemberModel>(memberRepository);

// ======= Операції з даними =======

// Чи є учасники?
var allMembers = await memberService.ReadAllAsync();
if (!allMembers.Any())
{
    var newMember = new LibraryMemberModel { Name = "Тестовий учасник (CRUD сервіс)" };
    await memberService.CreateAsync(newMember);
    Console.WriteLine($"Додано учасника з ID: {newMember.Id}");
}
else
{
    Console.WriteLine("Учасники вже є в базі:");
    foreach (var member in allMembers)
    {
        Console.WriteLine($"- {member.Name} (ID: {member.Id})");
    }
}

Console.WriteLine("Готово.");
