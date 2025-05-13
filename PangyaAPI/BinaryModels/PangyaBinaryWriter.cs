using System.Numerics;

namespace PangyaAPI.BinaryModels
{
    public class PangyaBinaryWriter : BinaryWriter
    {
        #region  Construtores 
        public PangyaBinaryWriter(Stream output) : base(output) { }
        public PangyaBinaryWriter() : base(new MemoryStream()) { }
        public PangyaBinaryWriter(byte[] dados) : base(new MemoryStream())
        {
            Write(dados);
        }

        public PangyaBinaryWriter(params object[] values)
        {
            this.OutStream = new MemoryStream();

            WriteParams(values);
        }


        #endregion


        #region Escrita de string

        /// <summary>
        /// Escreve String no Formato Pangya { 00, 00 (tamanho), data (valor)  } e avança a posição atual pelo número de bytes escritos
        /// </summary>
        public void WritePStr(string data)
        {
            int size = data.Length;

            if (size >= short.MaxValue)
                return;

            Write((short)size);

            Write(data.ToCharArray());
        }

        /// <summary>
        /// Escreve String no Formato Pangya { 00, 00 (tamanho), data (valor)  } e avança a posição atual pelo número de bytes escritos
        /// </summary>
        public void WriteStr(string data)
        {
            int size = data.Length;

            if (size >= short.MaxValue)
                return;

            Write(data.ToCharArray());
        }

        public void WriteStr(string message, int length)
        {
            message = message.PadRight(length, (char)0x00);
            Write(message.Select(Convert.ToByte).ToArray());
        }


        #endregion

        #region Escrita de números

        public void WriteUInt32(UInt32 src)
        {
            byte[] result = BitConverter.GetBytes(src);
            Write(result);
        }
        public void WriteUInt16(ushort src)
        {
            byte[] result = BitConverter.GetBytes(src);
            Write(result);
        }

        #endregion

        public void Write(Vector3 model)
        {
            Write(model.X);
            Write(model.Y);
            Write(model.Z);
        }

        #region Public Methods

        /// <summary>
        /// Obtém o array de bytes da stream
        /// </summary>
        public byte[] GetBytes()
        {
            if (OutStream is MemoryStream)
                return ((MemoryStream)OutStream).ToArray();


            using (var memoryStream = new MemoryStream())
            {
                memoryStream.GetBuffer();
                OutStream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public void WriteParams(params object[] values)
        {
            foreach (var value in values)
            {
                switch (Type.GetTypeCode(value.GetType()))
                {
                    case TypeCode.Boolean: Write((bool)value); break;
                    case TypeCode.Char: Write((char)value); break;
                    case TypeCode.SByte: Write((sbyte)value); break;
                    case TypeCode.Byte: Write((byte)value); break;
                    case TypeCode.Int16: Write((short)value); break;
                    case TypeCode.UInt16: Write((ushort)value); break;
                    case TypeCode.Int32: Write((int)value); break;
                    case TypeCode.UInt32: Write((uint)value); break;
                    case TypeCode.Int64: Write((long)value); break;
                    case TypeCode.UInt64: Write((ulong)value); break;
                    case TypeCode.Single: Write((Single)value); break;
                    case TypeCode.Double: Write((double)value); break;
                    case TypeCode.Decimal: Write((decimal)value); break;
                    //case TypeCode.DateTime: Write(ToPangyaDateTime((DateTime)value)); break;
                    case TypeCode.String: WritePStr((string)value); break;

                    case TypeCode.Empty:
                    case TypeCode.Object:
                    case TypeCode.DBNull:
                    default: throw new Exception("Tipo não implementado");
                }
            }
        }
        #endregion

    }
}