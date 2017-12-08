using System;

namespace AdventOfCode2017.Eight
{
    public static class ConditionEvaluator
    {
        public static bool IsConditionTrue(int first, string evaluator, int second)
        {
            bool result;
            switch (evaluator)
            {
                case ">":
                    result = first > second;
                    break;

                case ">=":
                    result = first >= second;
                    break;

                case "<":
                    result = first < second;
                    break;

                case "<=":
                    result = first <= second;
                    break;

                case "==":
                    result = first == second;
                    break;

                case "!=":
                    result = first != second;
                    break;

                default:
                    throw new ArgumentException("Undefined evaluator");
            }

            return result;
        }
    }
}