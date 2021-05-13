using System;



namespace ProjectRestaurant
{
    class Program
    {
        static void Main(string[] args)
        {
        json_reservation.reservationInit();
        json_customer.customerinit();
        json_dish.dishInit();
        json_table.tableInit();
        json_takeaway.takeawayInit();
        client_variable.dish_catagory = new System.Collections.Generic.List<string>(); 

        new MenuHandler().mainMenu();

        }

    }
}
