using System.Runtime.InteropServices;

namespace PangyaAPI.BinaryModels
{
    public class PangyaBitReader<T>
    {
        private T _data;
        private int _position;

        public PangyaBitReader(T data)
        {
            _data = data;
            _position = 0;
        }

        public bool ReadBit()
        {
            ulong value = Convert.ToUInt64(_data);
            bool bit = ((value >> _position) & 0x1) != 0;
            _position++;
            return bit;
        }


        public TReturn[] ReadArray<TReturn>(int total)
        {
            if (total <= 0)
                throw new ArgumentException("Total length must be greater than zero.");

            TReturn[] result = new TReturn[total];

            for (int i = 0; i < total; i++)
            {
                TReturn value = ReadBits<TReturn>(1);
                result[i] = value;
            }

            return result;
        }


        public TReturn ReadBits<TReturn>(int count)
        {
            uint value = Convert.ToUInt32(_data);
            int size = Marshal.SizeOf(typeof(T)) * 8; // Multiplica por 8 para obter o número de bits

            if (count > size)
                throw new ArgumentException("O número de bits a serem lidos é maior que o tamanho do tipo de dados.");

            uint result = 0;
            for (int i = 0; i < count; i++)
            {
                result |= (uint)((ReadBit() ? 1 : 0) << i);
            }

            return (TReturn)Convert.ChangeType(result, typeof(TReturn));
        }
    }
}
