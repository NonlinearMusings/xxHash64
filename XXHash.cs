using System;

/// <summary>
/// * SQLCLR SAFE compliant:
///     * remove System.Buffers.Binary dependencies.
///     * remove System.Runtime.CompilerServices dependencies.
/// * Net effect is to make the code Little Endian only and lose AggressiveInlining on remaing methods.
/// * Removed XXHash3NET namespace.
/// </summary>
internal sealed class XXHash
{
    internal const uint XXH_PRIME32_1 = 0x9E3779B1U;
    internal const uint XXH_PRIME32_2 = 0x85EBCA77U;
    internal const uint XXH_PRIME32_3 = 0xC2B2AE3DU;
    internal const uint XXH_PRIME32_4 = 0x27D4EB2FU;
    internal const uint XXH_PRIME32_5 = 0x165667B1U;

    internal const ulong XXH_PRIME64_1 = 0x9E3779B185EBCA87UL;
    internal const ulong XXH_PRIME64_2 = 0xC2B2AE3D27D4EB4FUL;
    internal const ulong XXH_PRIME64_3 = 0x165667B19E3779F9UL;
    internal const ulong XXH_PRIME64_4 = 0x85EBCA77C2B2AE63UL;
    internal const ulong XXH_PRIME64_5 = 0x27D4EB2F165667C5UL;

    internal const int XXH_STRIPE_LEN = 64;
    internal const int XXH_SECRET_CONSUME_RATE = 8;

    // -------------- UTILITY METHODS -------------- \\
    internal static ulong RotLeft64(ulong value, int shift) =>
        (value << shift) | (value >> (64 - shift));

    internal static ulong RotRight64(ulong value, int shift) =>
        (value << (64 - shift)) | (value >> shift);

    internal static byte _mm_shuffle(byte p3, byte p2, byte p1, byte p0) =>
        (byte)((p3 << 6) | (p2 << 4) | (p1 << 2) | p0);
 }