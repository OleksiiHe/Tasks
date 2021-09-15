namespace Task1
{
    public struct ValidationData
    {
        public const double MINVALUE = 0;
        public const double MAXVALUE = 100;

        public const string VALUEISOUTOFRANGE = "Value must not be less than 0 or greater than 100.";

        public const string INCORRECTRADIUS = "Minor Radius must not be greater than Major Radius.";

        public const string INCORRECTSIDE = "Width must not be greater than Length.";

        public const string POLYGONISNOTEXIST = "Each side must not be greater than sum of the other sides.";

    }
}
