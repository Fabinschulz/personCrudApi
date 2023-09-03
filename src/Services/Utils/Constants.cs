namespace Crud.API.src.Services.Utils
{
    public class Constants
    {
        public static class Regex
        {
            public const string email = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-A-Za-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[A-Za-z0-9][\w\.-]*[A-Za-z0-9]\.[A-Za-z][A-Za-z\.]*[A-Za-z]$";
            public const string telefone = @"^(\+\d{2}\s?)?\(?\d{2}\)?\s?9\d{4,5}-?\d{4}$";
            public const string nome = @"^[A-zÀ-ÿ']+\s([A-zÀ-ÿ']\s?)*[A-zÀ-ÿ']+$";
        }
    }
}
