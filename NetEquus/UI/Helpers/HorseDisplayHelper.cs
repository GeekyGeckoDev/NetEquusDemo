namespace UI.Helpers
{
    public static class HorseDisplayHelper
    {
        public static string GetSex(int sex) => sex switch
        {
            0 => "Mare",
            1 => "Stallion",
            2 => "Gelding",
            _ => "Unknown"
        };
    }
}
