using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;
using Core.Models.Entities.Base;

namespace Core.Helpers
{
    public static class AtlasHelperUtilities
    {
        public static string SplitByDashes(this string text, int textToTake = 4)
        {
            string newString = string.Empty;

            for (int i = 0; i < text.Length; i += textToTake) {
                string part = new string( text.Skip(i).Take(textToTake).ToArray() );
                newString += $"{part}-";
            }
            return newString.Substring(0, newString.Length - 1);
        }
        
        public static string CreateNLengGUID(int number = 12)
        {
            string guid = Guid.NewGuid().ToString("N");

            return guid.Substring(0,number);
        }



        public static IEnumerable<DtoKeyValue> MapBaseEntityToKeyValue<TOut>(this IEnumerable<TOut> collection, string valueName) where TOut : BaseEntity
        {
            List<DtoKeyValue> mappedCollection = new List<DtoKeyValue>();
            foreach (var item in collection)
            {
                if (item != null)
                {
                    var type = item.GetType() ?? throw new Exception("");
                    var prop = type.GetProperty(valueName) ?? throw new Exception("");
                    var value = (string)prop.GetValue(item) ?? throw new Exception("");

                    mappedCollection.Add(new DtoKeyValue() { Id = item.Id, Value = value });
                }
            }

            return mappedCollection;
        }
        
        public static IEnumerable<DtoKeyValue> MapBaseEntityToExplicitKeyValue<TOut>(this IEnumerable<TOut> collection, string idToUse, string explicitValue) where TOut : BaseEntity
        {
            List<DtoKeyValue> mappedCollection = new List<DtoKeyValue>();
            foreach (var item in collection)
            {
                if (item != null)
                {
                    var type = item.GetType() ?? throw new Exception("");
                    var prop = type.GetProperty(idToUse) ?? throw new Exception("");
                    var value = prop.GetValue(item) ?? throw new Exception("");

                    mappedCollection.Add(new DtoKeyValue() { Id = Convert.ToInt32( value ), Value = explicitValue });
                }
            }
            
            return mappedCollection;
        }
    }
}