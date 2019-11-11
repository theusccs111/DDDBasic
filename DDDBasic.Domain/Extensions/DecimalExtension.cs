
namespace DDDBasic.Domain.Extensions
{
    public static class DecimalExtension
    {
        public static bool Between(this decimal input, decimal decimal1, decimal decimal2)
        {
            return (input > decimal1 && input < decimal2);
        }
    }
}
