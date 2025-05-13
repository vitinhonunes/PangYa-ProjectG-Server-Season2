using PangyaAPI.BinaryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PangyaAPI.Models
{
    public class BitFlag<TNumeric, TBitMap>
        where TNumeric : struct
        where TBitMap : class
    {
        public TNumeric Flag;

        public void Write(TBitMap model)
        {
            Flag = new PangyaBitWriter<TNumeric>().Write(GetProperties(model));
        }

        private bool[] GetProperties(TBitMap model)
        {
            var result = new List<bool>();

            PropertyInfo[] properties = model.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType == typeof(bool))
                {
                    var value = (bool)property.GetValue(this);
                    result.Add(value);
                }
                else if (property.PropertyType == typeof(bool[]))
                {
                    bool[] arrayValue = (bool[])property.GetValue(this);
                    result.AddRange(arrayValue);

                }
            }

            return result.ToArray();
        }
    }
}
