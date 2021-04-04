using System;



namespace ProjectRestaurant
{
    class Program
    {
        static void Main(string[] args)
        {
        json_reservation.reservationInit();
        json_customer.customerinit();
        json_table.tableInit();

        json_reservation.clearOldreservation();
        menuReg.mainMenu();

        }

    }
}
