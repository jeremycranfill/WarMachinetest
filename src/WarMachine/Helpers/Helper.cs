using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models.WarModels;

namespace WarMachine.Helpers
{
    public static class Helper
    {

     public static List<string> GetPropData(IList<string> Props, BaseModel Model)
        {

            List<string> propData = new List<string>();

            foreach (string prop in Props)
            {

                propData.Add(Model.GetType().GetProperty(prop).GetValue(Model, null).ToString());

            }


            return propData;


        }




        public static List<string> GetPropData(IList<string> Props, Weapon Model)
        {

            List<string> propData = new List<string>();

            foreach (string prop in Props)
            {

                propData.Add(Model.GetType().GetProperty(prop).GetValue(Model, null).ToString());

            }


            return propData;


        }


        public static List<string> GetPropData(IList<string> Props, Spell Model)
        {

            List<string> propData = new List<string>();

            foreach (string prop in Props)
            {

                propData.Add(Model.GetType().GetProperty(prop).GetValue(Model, null).ToString());

            }


            return propData;


        }

        public static List<string> GetPropData(IList<string> Props, Ability Model)
        {

            List<string> propData = new List<string>();

            foreach (string prop in Props)
            {

                propData.Add(Model.GetType().GetProperty(prop).GetValue(Model, null).ToString());

            }


            return propData;


        }




    }
}
