namespace Blazor.Components.Pages
{
    public partial class Fibonacci
    {
        double a = 0;
        double b = 0;
        double c = 0;
        double d = 0;
        string result;
        public void power()
        {
            if (a == 1)
            {
                result = null;
                result += '0';
            }
            if (a == 2)
            {
                result = null;
                result += "0,1";
            }
            if (a == 3)
            {
                result = null;
                result += "0,1,1";
            }
            if (a > 3)
            {
                result = null;
                result += "0,1,1";
                b = 1;
                c = 1;
                for (int i = 3; i < a; i++)
                {
                    d = b;
                    b += c;
                    c = d;
                    result += $",{Convert.ToString(b)}";
                }
            }
        }
    }
}
