namespace FittsLibrary
{
    public enum ColorMode
    {
        StaticRed,
        StaticGreen,
        StaticBlue,
        Space
    }

    public enum DisplayMode
    {
        ConstantPixelSize,
        ConstantUnitSize
    }

    public enum DistanceMode
    {
        Random,
        EqualDistance,
        LinRegOptimised
    }

    public enum TargetMode
    {
        Framed,
        Frameless
    }

    public enum RequestType
    {
        UserList,
        ColorRanges
    }

    public enum ColorBlindness
    {
        None,
        Partial,
        Full,
        Tetrachromat
    }

    public enum DeviceClass
    {
        Phone,
        Phtablet,
        Tablet,
        Screen
    }
}