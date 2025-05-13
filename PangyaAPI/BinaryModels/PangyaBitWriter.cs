using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PangyaAPI.BinaryModels
{
    public class PangyaBitWriter<T>
    {
        private T _data;
        private int _position;

        public PangyaBitWriter()
        {
            _data = default(T);
            _position = 0;
        }

        public T Write(bool bit)
        {
            uint value = Convert.ToUInt32(_data);
            uint mask = (uint)(1 << _position);
            if (bit)
                value |= mask;
            else
                value &= ~mask;
            _data = (T)Convert.ChangeType(value, typeof(T));
            _position++;

            return _data;
        }

        public T Write(bool[] bit)
        {
            foreach (var item in bit)
            {
                Write(item);
            }

            return _data;
        }

        public T GetResult()
        {
            return _data;
        }
    }
}
