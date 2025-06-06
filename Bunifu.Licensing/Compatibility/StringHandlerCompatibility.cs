#if NETFRAMEWORK || NET5_0 || NET5_0_OR_NETFRAMEWORK
using System;
using System.Text;

namespace System.Runtime.CompilerServices
{
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public struct DefaultInterpolatedStringHandler
    {
        private StringBuilder _builder;

        public DefaultInterpolatedStringHandler(int literalLength, int formattedCount)
        {
            _builder = new StringBuilder(literalLength + formattedCount * 11);
        }

        public string ToStringAndClear()
        {
            string result = _builder.ToString();
            _builder.Clear();
            return result;
        }

        public void AppendLiteral(string value)
        {
            _builder.Append(value);
        }

        public void AppendFormatted<T>(T value)
        {
            _builder.Append(value?.ToString() ?? string.Empty);
        }

        public void AppendFormatted<T>(T value, string format)
        {
            if (value is IFormattable formattable)
            {
                _builder.Append(formattable.ToString(format, null));
            }
            else
            {
                _builder.Append(value?.ToString() ?? string.Empty);
            }
        }
    }
}
#endif 