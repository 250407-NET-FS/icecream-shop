using IcecreamShopAPI.Services;
using IcecreamShopAPI.Services.Interfaces;
using IcecreamShopAPI.Models;
using IcecreamShopAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using IcecreamShopAPI.Repositories;
using IcecreamShopAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IIcecreamRepo, IceCreamRepo>();
builder.Services.AddSingleton<ICashierRepo, CashierRepo>();
builder.Services.AddSingleton<ICustomerRepo, CustomerRepo>();
builder.Services.AddSingleton<ITransactionRepo, TransactionRepo>();

builder.Services.AddSingleton<IIcecreamService, IcecreamService>();
builder.Services.AddSingleton<ICashierService, CashierService>();
builder.Services.AddSingleton<ICustomerService, CustomerService>();
builder.Services.AddSingleton<ITransactionService, TransactionService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "Cart's Icecream Shop";
    config.Title = "icecreamShopAPI";
    config.Version = "v0.5";
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "Cart's Icecream Shop";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
}
app.MapGet("/", () => "Hello, and Welcome to Cart's Icecream Shop!");
// Icecream Endpoints
app.MapGet("/icecreams", (IIcecreamService icecreamService) => {
    try {
        return Results.Ok(icecreamService.GetIcecreamList());
    }
    catch (Exception ex) {
        return Results.Problem(ex.Message, statusCode: 500);
    }
}); 

app.MapPost("/icecreams", ([FromBody] Icecream icecream, IIcecreamService icecreamService) => {
    try {
        return Results.Created("/icecreams{icecream.Id}", icecreamService.AddIcecream(icecream));
    }
    catch (ArgumentException ex) {
        return Results.Problem(ex.Message, statusCode: 400);
    }
    catch (Exception ex) {
        return Results.Problem(ex.Message, statusCode: 500);
    }
});

app.MapPatch("/icecreams/{id}", ([FromBody] Icecream icecream, int id, IIcecreamService icecreamService) => {
    try {
        return Results.Ok(icecreamService.UpdateIcecream(icecream, id));
    }
    catch (ArgumentException ex) {
        return Results.Problem(ex.Message, statusCode: 400);
    }
    catch (Exception ex) {
        return Results.Problem(ex.Message, statusCode: 500);
    }
});

app.MapDelete("/icecreams{id}", (int id, IIcecreamService icecreamService) => {
    try {
        return Results.Ok(icecreamService.DeleteIcecream(id));
    }
    catch (ArgumentException ex) {
        return Results.Problem(ex.Message, statusCode: 400);
    }
    catch (Exception ex) {
        return Results.Problem(ex.Message, statusCode: 500);
    }
});
// Cashier Endpoints
app.MapGet("/cashiers/{phone}", (string phone, ICashierService cashierService) => {
    try {
        return Results.Ok(cashierService.GetCashierByPhone(phone));
    }
    catch (ArgumentException ex) {
        return Results.Problem(ex.Message, statusCode: 400);
    }
    catch (Exception ex) {
        return Results.Problem(ex.Message, statusCode: 500);
    }
});

app.MapGet("/cashiers", (ICashierService cashierService) => {
    try {
        return Results.Ok(cashierService.GetCashierList());
    }
    catch (Exception ex) {
        return Results.Problem(ex.Message, statusCode: 500);
    }
});

app.MapPost("/cashiers", ([FromBody] Cashier cashier, ICashierService cashierService) => {
    try {
        return Results.Created("/cashiers/{cashier.PhoneNumber}", cashierService.AddCashier(cashier));
    }
    catch (ArgumentException ex) {
        return Results.Problem(ex.Message, statusCode: 400);
    }
    catch (Exception ex) {
        return Results.Problem(ex.Message, statusCode: 500);
    }
});

app.MapPatch("/cashiers", ([FromBody] Cashier cashier, ICashierService cashierService) => {
    try {
        return Results.Ok(cashierService.UpdateCashier(cashier));
    }
    catch (ArgumentException ex) {
        return Results.Problem(ex.Message, statusCode: 400);
    }
    catch (Exception ex) {
        return Results.Problem(ex.Message, statusCode: 500);
    }
});

app.MapDelete("/cashiers", ([FromBody] Cashier cashier, ICashierService cashierService) => {
    try {
        return Results.Ok(cashierService.DeleteCashier(cashier));
    }
    catch (ArgumentException ex) {
        return Results.Problem(ex.Message, statusCode: 400);
    }
    catch (Exception ex) {
        return Results.Problem(ex.Message, statusCode: 500);
    }
});
// Customer Endpoints
app.MapGet("/customers", (ICustomerService customerService) => {
    try {
        return Results.Ok(customerService.GetCustomerList());
    }
    catch (Exception ex) {
        return Results.Problem(ex.Message, statusCode: 500);
    }
});

app.MapPost("/customers", ([FromBody] Customer customer, ICustomerService customerService) => {
    try {
        return Results.Ok(customerService.AddCustomer(customer));
    }
    catch (ArgumentException ex) {
        return Results.Problem(ex.Message, statusCode: 400);
    }
    catch (Exception ex) {
        return Results.Problem(ex.Message, statusCode: 500);
    }
});

app.MapPatch("/customers", ([FromBody] Customer customer, ICustomerService customerService) => {
    try {
        return Results.Created("/customers/{customer.Email}", customerService.UpdateCustomer(customer));
    }
    catch (ArgumentException ex) {
        return Results.Problem(ex.Message, statusCode: 400);
    }
    catch (Exception ex) {
        return Results.Problem(ex.Message, statusCode: 500);
    }
});

app.MapDelete("/customers/{email}", (string email, ICustomerService customerService) => {
    try {
        return Results.Ok(customerService.DeleteCustomer(email));
    }
    catch (ArgumentException ex) {
        return Results.Problem(ex.Message, statusCode: 400);
    }
    catch (Exception ex) {
        return Results.Problem(ex.Message, statusCode: 500);
    }
});
// Transaction endpoints
app.MapGet("/transactions", (ITransactionService transactionService) => {
    try {
        return Results.Ok(transactionService.GetTransactions());
    }
    catch (Exception ex) {
        return Results.Problem(ex.Message, statusCode: 500);
    }
}); 

app.MapPost("/transactions", ([FromBody] TransactionRequestDTO transactionRequest, ITransactionService transactionService) => {
    try {
        var transaction = transactionService.MakeTransaction(transactionRequest);
        return Results.Created("/customers/{transaction.Id}", transaction);
    }
    catch (ArgumentException ex) {
        return Results.Problem(ex.Message, statusCode: 400);
    }
    catch (Exception ex) {
        return Results.Problem(ex.Message, statusCode: 500);
    }
});

app.MapPatch("/transactions/{id}", ([FromBody] Transaction transaction, int id, ITransactionService transactionService) => {
    try {
        return Results.Ok(transactionService.UpdateTransaction(transaction, id));
    }
    catch (ArgumentException ex) {
        return Results.Problem(ex.Message, statusCode: 400);
    }
    catch (Exception ex) {
        return Results.Problem(ex.Message, statusCode: 500);
    }
});

app.MapDelete("/transactions/{id}", (int id, ITransactionService transactionService) => {
    try {
        return Results.Ok(transactionService.DeleteTransaction(id));
    }
    catch (ArgumentException ex) {
        return Results.Problem(ex.Message, statusCode: 400);
    }
    catch (Exception ex) {
        return Results.Problem(ex.Message, statusCode: 500);
    }
});

app.Run();
