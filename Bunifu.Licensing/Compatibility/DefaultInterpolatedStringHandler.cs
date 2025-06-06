#if NET5_0_OR_NETFRAMEWORK
using System;
using System.Text;

namespace System.Runtime.CompilerServices
{
    // A minimal DefaultInterpolatedStringHandler implementation for .NET 5.0 and .NET Framework
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    internal struct DefaultInterpolatedStringHandler
    {
        private StringBuilder _builder;

        public DefaultInterpolatedStringHandler(int literalLength, int formattedCount)
        {
            _builder = new StringBuilder(literalLength + formattedCount * 11);
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

        public void AppendFormatted(string value)
        {
            _builder.Append(value ?? string.Empty);
        }

        public void AppendFormatted(int value)
        {
            _builder.Append(value);
        }

        public void AppendFormatted<T>(T value, int alignment)
        {
            string str = value?.ToString() ?? string.Empty;
            if (alignment != 0)
            {
                if (alignment < 0)
                {
                    _builder.Append(str.PadRight(-alignment));
                }
                else
                {
                    _builder.Append(str.PadLeft(alignment));
                }
            }
            else
            {
                _builder.Append(str);
            }
        }

        public void AppendFormatted<T>(T value, int alignment, string format)
        {
            string str;
            if (value is IFormattable formattable)
            {
                str = formattable.ToString(format, null);
            }
            else
            {
                str = value?.ToString() ?? string.Empty;
            }

            if (alignment != 0)
            {
                if (alignment < 0)
                {
                    _builder.Append(str.PadRight(-alignment));
                }
                else
                {
                    _builder.Append(str.PadLeft(alignment));
                }
            }
            else
            {
                _builder.Append(str);
            }
        }

        public string ToStringAndClear()
        {
            string result = _builder.ToString();
            _builder.Clear();
            return result;
        }
    }
}
#endif 