using c_sharp_advanced_exam_Astijus_Skiecevičius.Entities;
using c_sharp_advanced_exam_Astijus_Skiecevičius.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_advanced_exam_Astijus_Skiecevičius
{
    public class Restaurant
    {
        public FoodMenuRepository FoodMenuRepository { get; set; }
        public DrinkMenuRepository DrinkMenuRepository { get; set; }
        public WaiterRepository WaiterRepository { get; set; }
        public TableRepository TableRepository { get; set; }
        public List<Order> Orders { get; set; }

        public Restaurant()
        {
            FoodMenuRepository = new FoodMenuRepository();
            DrinkMenuRepository = new DrinkMenuRepository();
            WaiterRepository = new WaiterRepository();
            TableRepository = new TableRepository();
        }

        public void Init()
        {
            Console.WriteLine("Welcome to the restaurant system");
            Console.ReadLine();
            var waiter = NewWaiter(WaiterRepository);
            List<FoodAndDrinks> menu = new List<FoodAndDrinks>();
            menu.AddRange(FoodMenuRepository.Food);
            menu.AddRange(DrinkMenuRepository.Drinks);
            DisplayUserInterface(waiter, menu);

        }

        public void DisplayUserInterface(Waiter waiter, List<FoodAndDrinks> menu)
        {
            Orders = new List<Order>();
            bool repeat = true;

            while (repeat)
            {
                Console.Clear();
                Console.WriteLine("[1] - New Order\n[2] - Unpaid Orders\n[3] - Add to order\n[4] - Complete order\n[q] - Log out");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        NewOrder(menu);
                        break;
                    case "2":
                        Console.Clear();
                        CurrentOrders(Orders);
                        break;
                    case "3":
                        Console.Clear();
                        AddToOrder(menu);
                        break;
                    case "4":
                        Console.Clear();
                        CompleteOrder(waiter);
                        break;
                    case "q":
                        Console.Clear();
                        repeat = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input");
                        Console.ReadLine();
                        break;
                }
            }
        }
        public static Waiter NewWaiter(WaiterRepository waiterRepository)
        {
            Console.Clear();
            Console.WriteLine("Please enter your ID");
            waiterRepository.DisplayAll();
            int waitersId = Convert.ToInt32(Console.ReadLine());
            var waiter = waiterRepository.GetById(waitersId);
            Console.Clear();
            Console.WriteLine("Waiter " + waiter.WaitersName + " has logged on");
            Console.ReadLine();
            return waiter;
        }
        public void NewOrder(List<FoodAndDrinks> food)
        {
            Console.WriteLine("Please select an available table");
            TableRepository.DisplaySelection(true);
            int tableId = Convert.ToInt32(Console.ReadLine());
            Orders.Add(new Order { TableId = tableId, Menu = new List<FoodAndDrinks>(), OrderSum = 0m });
            TableRepository.ChangeTableAvailability(tableId, false);

            Console.Clear();
            Console.WriteLine("If you want to add to order enter 0");
            if (Console.ReadLine() == "0")
            {
                SelectFood(tableId, food);
            }

        }

        public void CurrentOrders(List<Order> orders)
        {
            Console.WriteLine("Current orders:");
            foreach (var item in orders)
            {
                Console.WriteLine($"Table id: {item.TableId}, bill sum: {item.OrderSum} $");

            }
            Console.ReadLine();
        }

        public void AddToOrder(List<FoodAndDrinks> food)
        {
            Console.WriteLine("Please select which tables order to add to");
            TableRepository.DisplaySelection(false);
            int tableId = Convert.ToInt32(Console.ReadLine());

            if (Orders.Any(x => x.TableId == tableId))
            {
                SelectFood(tableId, food);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("The table is empty");
                Console.ReadLine();
            }
        }

        public void SelectFood(int tableId, List<FoodAndDrinks> food)
        {
            bool repeat = true;
            while (repeat)
            {
                Console.Clear();
                Console.WriteLine("[1] Food menu \n[2] Drinks Menu");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        FoodMenuRepository.DisplayAll();
                        Console.WriteLine("Please enter the id of the food item");
                        int foodId = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Please enter the amount");
                        int foodAmount = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < foodAmount; i++)
                        {
                            var order = Orders.FirstOrDefault(x => x.TableId == tableId);
                            var item = food.FirstOrDefault(x => x.Id == foodId);
                            order.Menu.Add(item);
                            order.OrderSum += item.Price;

                        }
                        Console.Clear();
                        Console.WriteLine("Please press 0 if you want to add to an order");
                        if (Console.ReadLine() != "0")
                        {
                            repeat = false;
                        }
                        break;
                    case "2":
                        Console.Clear();
                        DrinkMenuRepository.DisplayAll();
                        Console.WriteLine("Please enter the Id of the drink item");
                        int drinkId = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Please enter the amount");
                        int drinksAmount = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < drinksAmount; i++)
                        {
                            var order = Orders.FirstOrDefault(x => x.TableId == tableId);
                            var item = food.FirstOrDefault(x => x.Id == drinkId);
                            order.Menu.Add(item);
                            order.OrderSum += item.Price;
                        }
                        Console.Clear();
                        Console.WriteLine("Please press 0 if you want to add to an order");
                        if (Console.ReadLine() != "0")
                        {
                            repeat = false;
                        }
                        break;


                }
            }
        }
        public void CompleteOrder(Waiter waiter)
        {
            Console.WriteLine("Select the table to print the bill for");
            TableRepository.DisplaySelection(false);
            int tableId = Convert.ToInt32(Console.ReadLine());
            var order = Orders.First(x => x.TableId == tableId);
            PrintBill(order, waiter);
            Orders.Remove(Orders.First(x => x.TableId == tableId));
            TableRepository.ChangeTableAvailability(tableId, true);
        }

        public void PrintBill(Order order, Waiter waiter)
        {
            Console.Clear();
            string forRestaurant = PrintForRestaurant(order, waiter);
            string forClient = PrintForClient(order, waiter);

            var FilePath = ("C:\\Users\\Astijus\\Desktop\\CSV_Files\\Bill.csv");
            using (StreamWriter writer = new StreamWriter(new FileStream(FilePath,
            FileMode.Create, FileAccess.Write)))
            {
                writer.WriteLine(forRestaurant);
                Console.WriteLine("To print out the bill for the client press 1");
                if (Console.ReadLine() == "1")
                {
                    writer.WriteLine($"\n{forClient}");
                }
            }
        }

        public string PrintForRestaurant(Order order, Waiter waiter)
        {
            string billData = $"Data:{DateTime.Now}\nWaiter:{waiter.WaitersId}\n" +
                    $"Table number:{order.TableId}\nID:";
            foreach (var item in order.Menu)
            {
                billData += $"{item.Id}";
            }
            billData += $"\nTotal sum:{order.OrderSum}";
            return billData;
        }


        public string PrintForClient(Order order, Waiter waiter)
        {
            string billData = $"Table number:{order.TableId}\nId:  Order:  Price:\n" + 
                    $"Date:{DateTime.Now}\nYour waiter was: {waiter.WaitersName}\n";
            foreach (var item in order.Menu)
            {
                billData += $"{item.Id}  {item.Name},  {item.Price}";
            }
            billData += $"\nTotal price:{order.OrderSum}";
            return billData;
        }


    }
}
