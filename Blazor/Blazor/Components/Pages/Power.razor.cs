namespace Blazor.Components.Pages
{
    public partial class Power
    {
        double a = 0;
        double b = 0;
        double c = 0;
        public void power()
        {
            c = Math.Pow(a, b);
        }
    }
}
