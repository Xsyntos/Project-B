﻿using System;
using System.Collections.Generic;
using System.Text;



namespace ProjectRestaurant
{
    class Menu
    {
        public option[] options { get; set; }
        public string prefix { get; set; }

        public void RunMenu()
        {
            string prompt = @$"

                                           
 _____         _                       _   
| __  |___ ___| |_ ___ _ _ ___ ___ ___| |_ 
|    -| -_|_ -|  _| .'| | |  _| .'|   |  _|
|__|__|___|___|_| |__,|___|_| |__,|_|_|_|  
                                           
{prefix}  ";
            string[] optionText = new string[options.Length];
            for(int i = 0; i < options.Length; i++)
            {
                optionText[i] = options[i].printToConsole;
            }

            Game mainMenu = new Game(prompt, optionText);
            int selectedIndex = mainMenu.Run();
            options[selectedIndex].func();
        }
    }

    class option
    {
        public string printToConsole { get; set; }
        public Action func { get; set; }
    }


}

     
    
