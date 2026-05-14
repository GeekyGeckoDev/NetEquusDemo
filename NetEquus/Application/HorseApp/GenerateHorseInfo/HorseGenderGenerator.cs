using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp.GenerateHorseInfo
{
    public class HorseGenderGenerator
    {
        public HorseSex horseSex {  get; set; }

        public int sex
        {
            get =>(int)horseSex;
            set => horseSex = (HorseSex)value;
        }

        public HorseSex RandomSex()
        {
            Random rnd = new Random();
            int sexValue = rnd.Next(0, 2);
            return (HorseSex)sexValue;
        }
    }
}
