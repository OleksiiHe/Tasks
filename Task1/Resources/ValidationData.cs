namespace Task1
{
    public struct ValidationData
    {
        public const double MIN_VALUE = 0;
        public const double MAX_VALUE = 100;

        public const string VALUE_IS_OUT_OF_RANGE = "Value must not be less than 0 or greater than 100.";

        public const string INCORRECT_RADIUS = "Minor Radius must not be greater than Major Radius.";

        public const string INCORRECT_SIDE = "Width must not be greater than Length.";

        public const string POLYGON_IS_NOT_EXIST = "Each side must not be greater than sum of the other sides.";

        public const string GENERAL_WARNING = "Input data is not valid. Please check all fields and try again.";
    }
}
