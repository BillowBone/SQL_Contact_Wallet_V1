namespace Annuaire_V1
{
    public class StringLib
    {
        public static int GetStringLenght(string str)
        {
            int len = 0;

            foreach (char c in str)
                len++;
            return (len);
        }
    }
}
