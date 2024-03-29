namespace OnlineElectronicsStore.Domain.Helpers;

public struct Triple<TFirst, TSecond, TThird>
{
    public TFirst First { get; set; }
    public TSecond Second { get; set; }
    public TThird Third { get; set; }

    public Triple(TFirst first, TSecond second, TThird third)
    {
        First = first;
        Second = second;
        Third = third;
    }
}