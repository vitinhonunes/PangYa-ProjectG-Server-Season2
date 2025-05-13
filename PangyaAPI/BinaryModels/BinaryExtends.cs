using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PangyaAPI
{
    public static class BinaryExtends
    {
        public static byte[] ToByteArray<T>(this T obj)
        {
            return ToByteArray2(obj, typeof(T));
        }

        private static byte[] ToByteArray2(object obj, Type type)
        {
            List<byte> byteList = new List<byte>();

            // Processa os campos da classe base primeiro
            if (type.BaseType != null && type.BaseType != typeof(object))
            {
                byteList.AddRange(ToByteArray2(obj, type.BaseType));
            }

            foreach (FieldInfo field in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Where(f => f.DeclaringType == type))
            {
                object value = field.GetValue(obj);

                if (value is IEnumerable<byte> byteArray)
                {
                    byteList.AddRange(byteArray);
                }
                else if (field.FieldType.IsEnum)
                {
                    Type enumType = Enum.GetUnderlyingType(field.FieldType);

                    if (enumType == typeof(byte))
                        byteList.Add((byte)value);
                    else if (enumType == typeof(int))
                        byteList.AddRange(BitConverter.GetBytes((int)value));
                    else if (enumType == typeof(uint))
                        byteList.AddRange(BitConverter.GetBytes((uint)value));
                    else
                        throw new Exception("tipo de enum não implementado (binaryExtends)");
                }
                else if (field.FieldType == typeof(float[]))
                {
                    float[] floatArray = (float[])value;
                    foreach (float floatValue in floatArray)
                    {
                        byte[] floatBytes = BitConverter.GetBytes(floatValue);
                        byteList.AddRange(floatBytes);
                    }
                }
                else if (field.FieldType == typeof(int[]))
                {
                    int[] intArray = (int[])value;
                    foreach (int intValue in intArray)
                    {
                        byte[] intBytes = BitConverter.GetBytes(intValue);
                        byteList.AddRange(intBytes);
                    }
                }
                else if (field.FieldType == typeof(uint[]))
                {
                    uint[] intArray = (uint[])value;
                    foreach (uint intValue in intArray)
                    {
                        byte[] intBytes = BitConverter.GetBytes(intValue);
                        byteList.AddRange(intBytes);
                    }
                }
                else if (field.FieldType == typeof(long[]))
                {
                    long[] intArray = (long[])value;
                    foreach (long intValue in intArray)
                    {
                        byte[] intBytes = BitConverter.GetBytes(intValue);
                        byteList.AddRange(intBytes);
                    }
                }
                else if (field.FieldType == typeof(short[]))
                {
                    short[] intArray = (short[])value;
                    foreach (short intValue in intArray)
                    {
                        byte[] intBytes = BitConverter.GetBytes(intValue);
                        byteList.AddRange(intBytes);
                    }
                }

                else if (field.FieldType.IsValueType || field.FieldType == typeof(string))
                {
                    byteList.AddRange(SetFieldValue(value));
                }
                else if (field.FieldType.IsClass)
                {
                    byteList.AddRange(ToByteArray2(value, field.FieldType));
                }
                else
                {
                    throw new NotSupportedException($"Field type '{field.FieldType}' is not supported.");
                }
            }

            return byteList.ToArray();
        }

        private static byte[] SetFieldValue(object obj)
        {
            int size = Marshal.SizeOf(obj);
            byte[] bytes = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(obj, ptr, false);
                Marshal.Copy(ptr, bytes, 0, size);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            return bytes;
        }


        /// <summary>
        /// Converte um array de bytes para string
        /// </summary>
        /// <param name="stopAtNullByte">Indica se a leitura da string deve parar no primeiro byte nulo encontrado. (Padrão: false)</param>
        /// <returns>A string lida a partir dos bytes.</returns>
        public static string xToString(this byte[] bytes, bool stopAtNullByte = false)
        {
            if (stopAtNullByte)
                bytes = bytes.TakeWhile(b => b != 0x00).ToArray();

            var encoding = new ASCIIEncoding();
            return encoding.GetString(bytes);
        }
    }
}


//BACKUP FUNCIONANDO
//static byte[] ToByteArray<T>(T obj)
//{
//    return ToByteArray2(obj, typeof(T));
//}

//static byte[] ToByteArray2(object obj, Type type)
//{
//    List<byte> byteList = new List<byte>();

//    // Processa os campos da classe base primeiro
//    if (type.BaseType != null && type.BaseType != typeof(object))
//    {
//        byteList.AddRange(ToByteArray2(obj, type.BaseType));
//    }

//    foreach (FieldInfo field in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Where(f => f.DeclaringType == type))
//    {
//        object value = field.GetValue(obj);

//        if (value is IEnumerable<byte> byteArray)
//        {
//            byteList.AddRange(byteArray);
//        }
//        else if (field.FieldType.IsValueType || field.FieldType == typeof(string))
//        {
//            byteList.AddRange(SetFieldValue(value));
//        }
//        else if (field.FieldType.IsClass)
//        {
//            byteList.AddRange(ToByteArray2(value, field.FieldType));
//        }
//        else
//        {
//            throw new NotSupportedException($"Field type '{field.FieldType}' is not supported.");
//        }
//    }

//    return byteList.ToArray();
//}

//static byte[] SetFieldValue(object obj)
//{
//    int size = Marshal.SizeOf(obj);
//    byte[] bytes = new byte[size];
//    IntPtr ptr = Marshal.AllocHGlobal(size);

//    try
//    {
//        Marshal.StructureToPtr(obj, ptr, false);
//        Marshal.Copy(ptr, bytes, 0, size);
//    }
//    finally
//    {
//        Marshal.FreeHGlobal(ptr);
//    }

//    return bytes;
//}