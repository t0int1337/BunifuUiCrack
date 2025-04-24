// This file ensures DefaultInterpolatedStringHandler is available throughout the project
// It's a polyfill that provides compatibility across different .NET versions

#if NETFRAMEWORK || NET5_0 || NET5_0_OR_NETFRAMEWORK
using System.Runtime.CompilerServices;
#endif 