namespace MemoryCardGame.Models
{
    public static class EnumExtension
    {
        // Converts Values to user friendly strings that are printed on the console
        public static string ToDisplayString(Values value)
        {
            switch (value)
            {
                case Values.Ace:
                    return " A";
                case Values.Two:
                    return " 2";
                case Values.Three:
                    return " 3";
                case Values.Four:
                    return " 4";
                case Values.Five:
                    return " 5";
                case Values.Six:
                    return " 6";
                case Values.Seven:
                    return " 7";
                case Values.Eight:
                    return " 8";
                case Values.Nine:
                    return " 9";
                case Values.Ten:
                    return "10";
                case Values.Jack:
                    return " J";
                case Values.Queen:
                    return " Q";
                case Values.King:
                    return " K";
                default:
                    return null;
            }
        }

        // Converts Suits to user friendly strings that are printed on the console
        public static char ToDisplayString(Suits suit)
        {
            switch (suit)
            {
                case Suits.Clubs:
                    return '♣';
                case Suits.Diamonds:
                    return '♦';
                case Suits.Hearts:
                    return '♥';
                case Suits.Spades:
                    return '♠';
                default:
                    return ' ';
            }
        }
    }
}
