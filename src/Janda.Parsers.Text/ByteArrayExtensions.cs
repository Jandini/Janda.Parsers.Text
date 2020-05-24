using System.Runtime.CompilerServices;
using System.Text;

namespace Common.Extensions.Parsing
{
    public static class ByteArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ReadAsCStringToString(this byte[] buffer, Encoding encoding)
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] != 0) continue;

                return encoding.GetString(buffer, 0, i);
            }

            return encoding.GetString(buffer);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ReadAsCStringToString(this byte[] buffer, int max, Encoding encoding)
        {
            for (int i = 0; i < max; i++)
            {
                if (buffer[i] != 0) continue;

                return encoding.GetString(buffer, 0, i);
            }

            return encoding.GetString(buffer, 0, max);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ReadAsCStringToString(this byte[] buffer, int index, int max, Encoding encoding)
        {
            for (int i = index, count = index + max; i < count; i++)
            {
                if (buffer[i] != 0) continue;
                return encoding.GetString(buffer, index, i - index);
            }

            return encoding.GetString(buffer, index, max);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ReadAsPascalStringToString(this byte[] buffer, int offset, Encoding encoding)
        {
            return encoding.GetString(buffer, offset + 1, buffer[offset]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ReadAsPascalStringToString(this byte[] buffer, ref int offset, Encoding encoding)
        {
            int length = buffer[offset];

            offset++;
            string result = encoding.GetString(buffer, offset, length);
            offset += length;

            return result;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ReadAsCStringToInt16(this byte[] buffer, int index, int count, Encoding encoding, int defaultValue = 0)
        {
            int result = defaultValue;
            string value = null;

            for (int i = index, max = index + count; i < max; i++)
            {
                if (buffer[i] != 0) continue;
                value = encoding.GetString(buffer, index, i - index);
                break;
            }

            if (value != null)
                int.TryParse(value, out result);

            return result;
        }       
    }
}
