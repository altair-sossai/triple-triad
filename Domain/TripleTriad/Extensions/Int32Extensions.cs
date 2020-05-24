using System;

namespace TripleTriad.Extensions
{
    public static class Int32Extensions
    {
        public static Guid ToGuid(this int value)
        {
            var bytes = new byte[16];

            BitConverter.GetBytes(value).CopyTo(bytes, 0);

            return new Guid(bytes);
        }
    }
}