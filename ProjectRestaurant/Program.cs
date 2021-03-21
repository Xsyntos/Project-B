using System;



namespace ProjectRestaurant
{
    class Program
    {
        static void Main(string[] args)
        {
        json_reservation.reservationInit();
        json_customer.customerinit();
            //  json_table.getFreeTable(new DateTime(2021, 3, 20, 12, 0, 0));
            menuReg.mainMenu();
        //menuReg.reservationMenu1(0)();

           //var a = json_table.getFreeTable(new DateTime(2021, 3, 20, 12, 0, 0));
           //foreach (var x in json_reservation.reservationsofdate(new DateTime(2021, 3, 20, 12, 0, 0))) {
          //  Console.WriteLine(x.Id); }
            //    json_customer.customerinit();
            //   json_table.tableInit();
            //    json_reservation.reservationInit();
            //   json_customer.newUser("Steven", "pass", "123");
            //   json_reservation.makeReservation(new DateTime(2021, 12, 3, 12, 0, 0), json_customer.getUserlist()[0], json_table.getTableList()[0]);
            //   json_customer.displayUser();
            //  json_table.displayTable();
            // json_reservation.displayReservation();
            // json_customer.displayUser();
            // Registration.RegistrationFirstVersion();

        }

    }
}
