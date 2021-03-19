using System;
using System.Collections.Generic;
using System.Text;



namespace ProjectRestaurant
{
    class Menu
    {

        public void start()
        {
           // Title = "Example of the restaurant menu";



            RunMainMenu();

        }
        private void RunMainMenu()
        {
            string prompt = @"

                                           
 _____         _                       _   
| __  |___ ___| |_ ___ _ _ ___ ___ ___| |_ 
|    -| -_|_ -|  _| .'| | |  _| .'|   |  _|
|__|__|___|___|_| |__,|___|_| |__,|_|_|_|  
                                           
Welcome to our restaurant  ";

            //  string prompt = "Welcome to our restaurant";
            string[] options = { "Log-In", "Sign-up", "As gast", "Exit" };
            Game mainMenu = new Game(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    login();
                    break;
                case 1:
                    Signup();
                    break;
                case 2:
                    ContineuAsGuest();
                    break;
                case 3:
                    Exit();
                    break;
                default:
                    break;
            }

        }
        private void Exit()
        {
            Console.WriteLine("Press a key to close the application");
        }
        private void Signup()
        {
            Console.WriteLine("Signin");
        }
        private void ContineuAsGuest()
        {
            Console.WriteLine("Gast");
        }
        private void login()
        {
            Console.WriteLine("Login");

        }
    }

}

     
    
