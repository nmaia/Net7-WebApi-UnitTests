using Hotel.API.Helpers.Contracts;

namespace Hotel.API.Helpers
{
    public class StringHelper : IStringHelper
    {
        public bool HasOnlyNumbers(string str)
        {
            foreach (char c in str)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
    }
}
