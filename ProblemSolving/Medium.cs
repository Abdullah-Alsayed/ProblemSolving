namespace ProblemSolving
{
    public static class Medium
    {
        public static int ReverseInteger(int num)
        {
            int result = 0;
            while (num != 0)
            {
                int digit = num % 10; // Extract last digit
                num /= 10;            // Remove last digit

                // Check for overflow before multiplying by 10
                if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && digit > 7)) return 0;
                if (result < int.MinValue / 10 || (result == int.MinValue / 10 && digit < -8)) return 0;

                result = result * 10 + digit; // Add the digit to the reversed number
            }
            return result;
        }


        public static int StringToInteger(string s)
        {
            return 0;
        }
    }
}
