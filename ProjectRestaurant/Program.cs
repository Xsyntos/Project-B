using System;



namespace ProjectRestaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            json_customer.customerinit();
            json_table.tableInit();
            json_reservation.reservationInit();
         //   json_customer.newUser("Steven", "pass", "123");
         //   json_reservation.makeReservation(new DateTime(2021, 12, 3, 12, 0, 0), json_customer.getUserlist()[0], json_table.getTableList()[0]);
            json_customer.displayUser();
            json_table.displayTable();
            json_reservation.displayReservation();
            // json_customer.displayUser();
        }
    }
}
