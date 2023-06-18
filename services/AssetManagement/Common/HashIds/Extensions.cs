using HashidsNet;

namespace Common.HashIds
{
    public static class Extensions
    {
        public static string ToHashId(this int number, string hashSecurityPass) =>
            GetHasher(hashSecurityPass).Encode(number);

        public static int FromHashId(this string encoded, string hashSecurityPass) =>
            GetHasher(hashSecurityPass).Decode(encoded).FirstOrDefault();

        private static Hashids GetHasher(string hashSecurityPass) => new(hashSecurityPass, 10);
    }
}
