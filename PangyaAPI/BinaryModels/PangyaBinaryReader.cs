using System.Collections;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace PangyaAPI.BinaryModels
{
    public class PangyaBinaryReader : BinaryReader
    {
        #region Construtores

        public PangyaBinaryReader(Stream baseStream) : base(baseStream) { }

        public PangyaBinaryReader(byte[] result) : base(new MemoryStream(result)) { }

        #endregion

        #region Leitura de string

        public string ReadPStr()
        {
            return ReadPStr(new ASCIIEncoding());
        }
        public string ReadPStr(Encoding encoding)
        {
            int size = ReadInt16();

            if (Int16.MaxValue < size)
                return String.Empty;

            var result = ReadBytes(size);

            return encoding.GetString(result);
        }

        #endregion

        #region Leitura de objetos

        public T Read<T>() where T : class, new()
        {
            return ReadType(typeof(T), Activator.CreateInstance<T>()) as T ?? new T();
        }

        private object ReadType(Type type, object obj)
        {
            // Processa os campos da classe base primeiro
            if (type.BaseType != null && type.BaseType != typeof(object))
            {
                obj = ReadType(type.BaseType, obj);
            }

            foreach (FieldInfo field in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                if (field.DeclaringType == type)
                {
                    //&& field.FieldType.GetElementType() == typeof(byte)
                    if (field.FieldType.IsArray)
                    {
                        int arraySize = ((Array)field.GetValue(obj)).Length;

                        var fieldType = field.FieldType.GetElementType();

                        if (fieldType == typeof(byte))
                        {
                            byte[] arrayBytes = new byte[arraySize];
                            BaseStream.Read(arrayBytes, 0, arrayBytes.Length);
                            field.SetValue(obj, arrayBytes);
                        }
                        else if (fieldType == typeof(int))
                        {
                            int[] arrayInt = new int[arraySize];

                            for (int i = 0; i < arraySize; i++)
                                arrayInt[i] = ReadInt32();

                            field.SetValue(obj, arrayInt);
                        }

                        else if (fieldType == typeof(uint))
                        {
                            uint[] arrayInt = new uint[arraySize];

                            for (int i = 0; i < arraySize; i++)
                                arrayInt[i] = ReadUInt32();

                            field.SetValue(obj, arrayInt);
                        }
                        else if (fieldType == typeof(short))
                        {
                            short[] arrayInt = new short[arraySize];

                            for (int i = 0; i < arraySize; i++)
                                arrayInt[i] = ReadInt16();

                            field.SetValue(obj, arrayInt);
                        }
                        else if (fieldType == typeof(long))
                        {
                            long[] arrayInt = new long[arraySize];

                            for (int i = 0; i < arraySize; i++)
                                arrayInt[i] = ReadInt64();

                            field.SetValue(obj, arrayInt);
                        }
                        else if (fieldType == typeof(Vector2))
                        {
                            if (field.FieldType == typeof(Vector2[,]))
                            {
                                //object fieldValue = field.GetValue(obj);

                                //Array vector2Array = (Array)fieldValue;

                                //int tamanhoDimensao1 = vector2Array.GetLength(0); // Tamanho da primeira dimensão (2)
                                //int tamanhoDimensao2 = vector2Array.GetLength(1); // Tamanho da segunda dimensão (3)

                                // Obtem o valor do campo
                                object fieldValue = field.GetValue(obj);

                                // Verifica se o valor do campo é um array multidimensional de Vector2
                                if (fieldValue != null && fieldValue.GetType().IsArray && fieldValue.GetType().GetElementType() == typeof(Vector2))
                                {
                                    // Converte o valor para um array multidimensional de Vector2
                                    Vector2[,] vector2Array = (Vector2[,])fieldValue;

                                    // Obtém os tamanhos das dimensões do array multidimensional
                                    int tamanhoDimensao1 = vector2Array.GetLength(0); // Tamanho da primeira dimensão
                                    int tamanhoDimensao2 = vector2Array.GetLength(1); // Tamanho da segunda dimensão

                                    // Faça a leitura de cada elemento do array multidimensional
                                    for (int i = 0; i < tamanhoDimensao1; i++)
                                    {
                                        for (int j = 0; j < tamanhoDimensao2; j++)
                                        {
                                            // Faça a leitura de cada elemento do array multidimensional aqui
                                            // Por exemplo:
                                            vector2Array[i, j] = ReadVector2();
                                        }
                                    }

                                    // Define o valor do campo com o array multidimensional lido
                                    field.SetValue(obj, vector2Array);
                                }
                                else
                                {
                                    throw new Exception("Tipo de array multidimensional não suportado em PangyaBinaryReader");
                                }

                            }
                            else
                            {
                                var arrayVector2 = new Vector2[arraySize];

                                for (int i = 0; i < arraySize; i++)
                                    arrayVector2[i] = ReadVector2();

                                field.SetValue(obj, arrayVector2);
                            }
                        }
                        else
                        {
                            throw new Exception("Tipo de array não mapeado em PangyaBinaryReader");
                        }
                    }
                    else if (field.FieldType.IsEnum)
                    {
                        Type underlyingType = Enum.GetUnderlyingType(field.FieldType);
                        object enumValue = ReadFieldValue(underlyingType);
                        field.SetValue(obj, Enum.ToObject(field.FieldType, enumValue));
                    }
                    else if (field.FieldType.IsValueType || field.FieldType == typeof(string))
                    {
                        object value = ReadFieldValue(field.FieldType);
                        field.SetValue(obj, value);
                    }
                    else if (field.FieldType.IsClass)
                    {
                        object fieldValue = Activator.CreateInstance(field.FieldType);
                        fieldValue = ReadType(field.FieldType, fieldValue);
                        field.SetValue(obj, fieldValue);
                    }
                    else
                    {
                        throw new NotSupportedException($"Field type '{field.FieldType}' is not supported.");
                    }
                }
            }

            return obj;
        }

        private object ReadFieldValue(Type fieldType)
        {
            int size = fieldType == typeof(byte) ? 1 :
                       fieldType == typeof(short) ? 2 :
                       fieldType == typeof(ushort) ? 2 :
                       fieldType == typeof(int) ? 4 :
                       fieldType == typeof(uint) ? 4 :
                       fieldType == typeof(long) ? 8 :
                       fieldType == typeof(ulong) ? 8 :
                       fieldType == typeof(float) ? 4 :
                       fieldType == typeof(double) ? 8 :
                       fieldType == typeof(Vector2) ? 8 :
                       fieldType == typeof(Vector3) ? 12 :
                       throw new NotSupportedException($"Field type '{fieldType}' is not supported.");

            byte[] bytes = new byte[size];

            if (fieldType == typeof(byte))
                return ReadByte();

            if (fieldType == typeof(short))
                return ReadInt16();

            if (fieldType == typeof(ushort))
                return ReadUInt16();

            if (fieldType == typeof(int))
                return ReadInt32();

            if (fieldType == typeof(uint))
                return ReadUInt32();

            if (fieldType == typeof(long))
                return ReadInt64();

            if (fieldType == typeof(ulong))
                return ReadUInt64();

            if (fieldType == typeof(float))
                return ReadSingle();

            if (fieldType == typeof(double))
                return ReadDouble();

            if (fieldType == typeof(Vector2))
                return ReadVector2();

            if (fieldType == typeof(Vector3))
                return ReadVector3();

            BaseStream.Read(bytes, 0, size);

            return Convert.ChangeType(bytes[0], fieldType);
        }

        #endregion

        #region Leitura de outros tipos (ex. Vector3)

        public Vector2 ReadVector2()
        {
            return new Vector2()
            {
                X = ReadSingle(),
                Y = ReadSingle(),
            };
        }

        public Vector3 ReadVector3()
        {
            return new Vector3()
            {
                X = ReadSingle(),
                Y = ReadSingle(),
                Z = ReadSingle(),
            };
        }

        #endregion

        #region Leitura do buffer

        public byte[] GetBytes()
        {
            using (var memoryStream = new MemoryStream())
            {
                memoryStream.GetBuffer();
                BaseStream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        #endregion

    }
}