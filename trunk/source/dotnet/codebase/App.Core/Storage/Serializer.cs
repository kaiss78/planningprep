using System.IO;
using System.Runtime.Serialization;

namespace App.Core.Storage
{
    public static class Serializer
    {
        /// <summary>
        /// Toes the binary.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o">The o.</param>
        /// <returns></returns>
        public static byte[] ToBinary<T>(this T o) where T : class, new()
        {
            byte[] bytes;
            var dc = new DataContractSerializer(typeof(T));

            using (var ms = new MemoryStream())
            {
                //formatter.Serialize(ms, value);
                dc.WriteObject(ms, o);
                ms.Seek(0, 0);
                bytes = ms.ToArray();
            }

            return bytes;
        }

        /// <summary>
        /// Froms the binary.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="input">The input.</param>
        /// <param name="bits">The bits.</param>
        /// <returns></returns>
        public static TResult FromBinary<TResult>(this TResult input, byte[] bits) where TResult : class, new()
        {
            TResult result;
            var dc = new DataContractSerializer(typeof(TResult));
            //IFormatter formatter = new BinaryFormatter();
            using (var ms = new MemoryStream(bits))
            {
                result = (TResult)dc.ReadObject(ms);
            }

            return result;
        }
    }
}