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
        public static int MathChallenge(int num)
        {
            // العملات المتاحة: قيم ثابتة
            int[] coins = { 1, 2, 5 };

            // القيمة القصوى التي تمثل "ما لا نهاية" (لا يوجد حل بعد)
            const int INFINITY = 10000;

            // مصفوفة البرمجة الديناميكية: dp[i] ستخزن أقل عدد من العملات اللازمة لتكوين المبلغ i.
            int[] dp = new int[num + 1];

            // 1. التهيئة:
            // اجعل جميع المجاميع (عدا الصفر) تحتاج إلى عدد "لا نهائي" من العملات مبدئياً.
            for (int i = 1; i <= num; i++)
            {
                dp[i] = INFINITY;
            }

            // المجموع 0 لا يتطلب أي عملة.
            dp[0] = 0;

            // 2. البناء الديناميكي: حل المشكلة لكل مبلغ من 1 حتى num
            for (int i = 1; i <= num; i++) // i هو المبلغ الذي نحاول تكوينه (من 1 إلى num)
            {
                // 3. قاعدة الانتقال: نحاول إيجاد أفضل حل للمبلغ i 

                // لكل عملة متوفرة لدينا
                foreach (int coin in coins)
                {
                    // الشرط: يمكن استخدام العملة فقط إذا كانت قيمتها لا تتجاوز المبلغ i
                    if (coin <= i)
                    {
                        // المبلغ المتبقي بعد استخدام هذه العملة
                        int remainingAmount = i - coin;

                        // عدد العملات المطلوبة لتكوين المبلغ المتبقي (remainingAmount)
                        int coinsForRemaining = dp[remainingAmount];

                        // إذا كان المبلغ المتبقي يمكن تكوينه (أي coinsForRemaining ليس INFINITY)
                        if (coinsForRemaining != INFINITY)
                        {
                            // الحل الجديد هو: عدد العملات للمتبقي + 1 (العملة الحالية)
                            int newTotalCoins = coinsForRemaining + 1;

                            // نقارن بين الحل الجديد والحل الحالي المخزن في dp[i] ونختار الأقل.
                            dp[i] = Math.Min(dp[i], newTotalCoins);
                        }
                    }
                }
            }

            // النتيجة النهائية
            return dp[num];
        }
    }
}
