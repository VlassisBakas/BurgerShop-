namespace beeftechee.Database.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<beeftechee.Database.BeeftecheeDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(beeftechee.Database.BeeftecheeDb context)
        {
            context.Veggies.AddOrUpdate(x => x.Id,
                new Veggie() { Id = 1, Name = "Tomato", Price = 0.30m },
                new Veggie() { Id = 2, Name = "Onion", Price = 0.2m },
                new Veggie() { Id = 3, Name = "Lettuce", Price = 0.4m }
                );
            context.Sauces.AddOrUpdate(x => x.Id,
              new Sauce() { Id = 1, Name = "Ketcup", Price = 0.4m },
              new Sauce() { Id = 2, Name = "Mustard", Price = 0.5m },
              new Sauce() { Id = 3, Name = "Mayo", Price = 0.4m }
              );
            context.Cheeses.AddOrUpdate(x => x.Id,
             new Cheese() { Id = 1, Name = "Cheddar", Price = 0.8m },
             new Cheese() { Id = 2, Name = "Gouda", Price = 0.6m },
             new Cheese() { Id = 3, Name = "Edam", Price = 0.6m }
             );

            context.Breads.AddOrUpdate(x => x.Id,
             new Bread() { Id = 1, Name = "Brioche", Price = 1.1m },
             new Bread() { Id = 2, Name = "Bread pan", Price = 0.9m }
             );

            context.Meats.AddOrUpdate(x => x.Id,
             new Meat() { Id = 1, Name = "Beef", Price = 1.8m },
             new Meat() { Id = 2, Name = "Chicken", Price = 2.0m },
             new Meat() { Id = 3, Name = "Turkey", Price = 2.3m }
             );

            context.Burgers.AddOrUpdate(x => x.Name,
                new Entities.Burger { Name = "Hangover", Price = 4.40m, BreadId = 1, VeggieId = 1, SauceId = 1, MeatId = 1, CheeseId = 1, ImageUrl = "106-Hangover.jpg" },
                new Entities.Burger { Name = "Truffle-Mayo", Price = 4.20m, BreadId = 2, VeggieId = 2, SauceId = 2, MeatId = 2, CheeseId = 2, ImageUrl = "438-Truflle-Mayo.jpg" },
                new Entities.Burger { Name = "Classic Burger", Price = 4.80m, BreadId = 1, VeggieId = 3, SauceId = 3, MeatId = 3, CheeseId = 3, ImageUrl = "76-Classic-Burger.jpg" },
                new Entities.Burger { Name = "Cheeseburger", Price = 4.80m, BreadId = 2, VeggieId = 1, SauceId = 2, MeatId = 3, CheeseId = 1, ImageUrl = "77-Cheeseburger.jpg" },
                new Entities.Burger { Name = "Cheese-Bacon", Price = 4.10m, BreadId = 1, VeggieId = 2, SauceId = 1, MeatId = 1, CheeseId = 2, ImageUrl = "78-Cheese-Bacon.jpg" },
                new Entities.Burger { Name = "Hollywood", Price = 4.20m, BreadId = 2, VeggieId = 3, SauceId = 2, MeatId = 1, CheeseId = 2, ImageUrl = "81-Hollywood.jpg" },
                new Entities.Burger { Name = "Texas BBQ", Price = 4.50m, BreadId = 2, VeggieId = 1, SauceId = 1, MeatId = 3, CheeseId = 3, ImageUrl = "82-Texas-BBQ.jpg" }
                );

            context.Drinks.AddOrUpdate(x => x.Id,
             new Drink() { Id = 1, Name = "Coca Cola", Litre = 1.25m, Price = 2m, ImageUrl = "Coke_1.25L_large.jpg " },
             new Drink() { Id = 6, Name = "Coca Cola", Litre = 0.33m, Price = 1.2m, ImageUrl = "Coke_Can.jpg " },
             new Drink() { Id = 2, Name = "Fanta Orange", Litre = 1.25m, Price = 2m, ImageUrl = "Fanta_Orange_1.25L2_large.jpg" },
             new Drink() { Id = 7, Name = "Fanta Orange", Litre = 0.33m, Price = 1.2m, ImageUrl = "Fanta_Can.jpg" },
             new Drink() { Id = 3, Name = "Red Bull", Litre = 0.5m, Price = 2m, ImageUrl = "RedBull_473.jpg" },
             new Drink() { Id = 4, Name = "Sprite", Litre = 1.25m, Price = 2m, ImageUrl = "Sprite_1.25L_large.jpg" },
             new Drink() { Id = 5, Name = "Sprite", Litre = 0.33m, Price = 1.2m, ImageUrl = "Sprite_Can.jpg" }
             );


            var Orders = new List<Order>
            {
                new Order{Id=1,Address="Panepistimiou 39",City="Athens",ContactPhone="6905554545",PostalCode=11111,OrderDate=new DateTime(2019,10,12),TotalPrice=4.6m },
                new Order{Id=2,Address="Panepistimiou 39",City="Athens",ContactPhone="6905554545",PostalCode=11111,OrderDate=new DateTime(2019,10,16),TotalPrice=13.2m },
                new Order{Id=3,Address="Panepistimiou 39",City="Athens",ContactPhone="6905554545",PostalCode=11111,OrderDate=new DateTime(2019,10,16),TotalPrice=3m },
                new Order{Id=4,Address="Rodou 39",City="Athens",ContactPhone="6905554545",PostalCode=10441,OrderDate=new DateTime(2019,10,16),TotalPrice=11.2m },
                new Order{Id=5,Address="Kifisias 31",City="Athens",ContactPhone="6905554545",PostalCode=11551,OrderDate=new DateTime(2019,10,18),TotalPrice=5.8m }

            };

            Orders.ForEach(o => context.Orders.AddOrUpdate(p => p.Id, o));
            context.SaveChanges();


            var orderDrinks = new List<OrderDrink>
            {
                new OrderDrink{Id=1,Name="Coca cola",Litre=1.25m,Quantity=2,Price=1.8m,OrderId=1},
                new OrderDrink{Id=2,Name="Sprite",Litre=0.33m,Quantity=3,Price=1.2m,OrderId=1},
                new OrderDrink{Id=3,Name="Red Bull",Litre=0.5m,Quantity=1,Price=2.0m,OrderId=2},
                new OrderDrink{Id=4,Name="Red Bull",Litre=0.5m,Quantity=1,Price=2.0m,OrderId=4},
                new OrderDrink{Id=5,Name="Fanta Orange",Litre=1.25m,Quantity=1,Price=1.8m,OrderId=5}
            };
            orderDrinks.ForEach(x => context.OrderDrinks.AddOrUpdate(i => i.Name, x));
            context.SaveChanges();




            var OrderBurgers = new List<OrderBurger>
            {
                new OrderBurger{Id=1,Name="Cheeseburger",BreadName="Bread Pan",MeatName="Beef",CheeseName="Cheddar",VeggieName="Tomato",Quantity=2,SauceName="Ketchup",Price=2.3m,OrderId=1},
                new OrderBurger{Id=2,Name="Hangover",BreadName="Brioche",MeatName="Beef",CheeseName="Gouda",VeggieName="Onion",Quantity=3,SauceName="Mayo",Price=4.4m,OrderId=2},
                new OrderBurger{Id=3,Name="Classic Burger",BreadName="Bread Pan",MeatName="Beef",CheeseName="Cheddar",VeggieName="Tomato",Quantity=1,SauceName="Mustard",Price=3m,OrderId=3},
                new OrderBurger{Id=4,Name="Cheese bacon",BreadName="Brioche",MeatName="Beef",CheeseName="Cheddar",VeggieName="Tomato",Quantity=4,SauceName="Ketchup",Price=2.8m,OrderId=4},
                new OrderBurger{Id=5,Name="Crispy Chicken",BreadName="Bread Pan",MeatName="Chicken",CheeseName="Gouda",VeggieName="Lettuce",Quantity=2,SauceName="Mayo",Price=2.9m,OrderId=5}


            };

            OrderBurgers.ForEach(x => context.OrderBurgers.AddOrUpdate(i => i.Name, x));
            context.SaveChanges();




        }
    }
}
