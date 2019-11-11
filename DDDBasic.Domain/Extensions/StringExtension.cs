
namespace DDDBasic.Domain.Extensions
{
    public static class StringExtension
    {
        public static string Obter(this string mensagem, params string[] strings)
        {
            return string.Format(mensagem, strings);
        }
        
    }
}
