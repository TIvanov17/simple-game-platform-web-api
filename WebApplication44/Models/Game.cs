using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication44.Models
{
    public class Game
    {
        
        private static int counter = 1;

        private int _id;
        private string _region;

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string Name { get; set; }

        public Currency Price { get; set; }

        public string Region
        {
            get 
            {
                return _region; 
            }
            set
            {
                if(value == null)
                {
                    _region = null;
                }

                if (value.Equals("USA"))
                {
                    _region = value;
                }
                else
                {
                    _region = "Europe";
                }
            }
        }

        public Game(string name)
        {
            Name = name;
            ID = counter++;
        }
    }
}