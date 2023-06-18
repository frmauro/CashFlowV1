using Azure.Core;
using CashFlow.Domain;
using CashFlow.Infrastructure.Database;
using System;

namespace CashFlow.Application.Configuration.Data
{
    public class SeedData
    {
        private readonly MovementContext context;

        public SeedData(MovementContext appdbContext)
        {
            context = appdbContext;
        }

        public void Seed()
        {
            if (!context.Movements.Any())
            {
                for (int i = 0; i < 40; i++)
                {
                    // Credits
                    var entity = new Movement
                    {
                        Value = 100,
                        Data = i < 20 ? DateTime.Now.Date : DateTime.Now.AddDays(3).Date,
                        Type = MovementType.Credit,
                        Person = new Person()
                    };
                    entity.Person.Type = PersonType.Customers;
                    entity.Person.Name = $"Customer_000{i + 1}";
                    context.Movements.AddRange(entity);
                }

                //Debts
                for (int i = 0; i < 6; i++)
                {
                    // Debt
                    var entity = new Movement
                    {
                        Value = -300,
                        Data = i < 3 ? DateTime.Now.Date : DateTime.Now.AddDays(3).Date,
                        Type = MovementType.Debt,
                        Person = new Person()
                    };
                    entity.Person.Type = PersonType.Supplier;
                    entity.Person.Name = $"Supplier_000{i + 1}";
                    entity.Person.Data = DateTime.Now;
                    context.Movements.AddRange(entity);
                }
            }

            context.SaveChanges();
        }
    }
}
