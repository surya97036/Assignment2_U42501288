/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System;
using System.Text;

namespace ISM6225_Fall_2023_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 3, 50, 75 };
            int upper = 99, lower = 0;
            IList<IList<int>> missingRanges = FindMissingRanges(nums1, lower, upper);
            string result = ConvertIListToNestedList(missingRanges);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine();

            //Question2:
            Console.WriteLine("Question 2");
            string parenthesis = "()[]{}";
            bool isValidParentheses = IsValid(parenthesis);
            Console.WriteLine(isValidParentheses);
            Console.WriteLine();
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] prices_array = { 7, 1, 5, 3, 6, 4 };
            int max_profit = MaxProfit(prices_array);
            Console.WriteLine(max_profit);
            Console.WriteLine();
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string s1 = "69";
            bool IsStrobogrammaticNumber = IsStrobogrammatic(s1);
            Console.WriteLine(IsStrobogrammaticNumber);
            Console.WriteLine();
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            int[] numbers = { 1, 2, 3, 1, 1, 3 };
            int noOfPairs = NumIdenticalPairs(numbers);
            Console.WriteLine(noOfPairs);
            Console.WriteLine();
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] maximum_numbers = { 3, 2, 1 };
            int third_maximum_number = ThirdMax(maximum_numbers);
            Console.WriteLine(third_maximum_number);
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string currentState = "++++";
            IList<string> combinations = GeneratePossibleNextMoves(currentState);
            string combinationsString = ConvertIListToArray(combinations);
            Console.WriteLine(combinationsString);
            Console.WriteLine();
            Console.WriteLine();

            //Question 8:
            Console.WriteLine("Question 8:");
            string longString = "leetcodeisacommunityforcoders";
            string longStringAfterVowels = RemoveVowels(longString);
            Console.WriteLine(longStringAfterVowels);
            Console.WriteLine();
            Console.WriteLine();
        }

        /*
        
        Question 1:
        You are given an inclusive range [lower, upper] and a sorted unique integer array nums, where all elements are within the inclusive range. A number x is considered missing if x is in the range [lower, upper] and x is not in nums. Return the shortest sorted list of ranges that exactly covers all the missing numbers. That is, no element of nums is included in any of the ranges, and each missing number is covered by one of the ranges.
        Example 1:
        Input: nums = [0,1,3,50,75], lower = 0, upper = 99
        Output: [[2,2],[4,49],[51,74],[76,99]]  
        Explanation: The ranges are:
        [2,2]
        [4,49]
        [51,74]
        [76,99]
        Example 2:
        Input: nums = [-1], lower = -1, upper = -1
        Output: []
        Explanation: There are no missing ranges since there are no missing numbers.

        Constraints:
        -109 <= lower <= upper <= 109
        0 <= nums.length <= 100
        lower <= nums[i] <= upper
        All the values of nums are unique.

        Time complexity: O(n), space complexity:O(1)
        */

        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            try
            {
                int missRange = nums.Length; // Calculate the number of elements in the given array.
                IList<IList<int>> missingRanges = new List<IList<int>>(); // Prepare a list to store the identified missing ranges.

                if (missRange == 0)
                {
                    // In the case of an empty 'nums' array, it implies that there are no missing values in the entire range.
                    missingRanges.Add(new List<int> { lower, upper }); // Include the full range as a missing range.
                    return missingRanges;
                }

                if (nums[0] > lower)
                {
                    // If the first number in the 'nums' array is larger than the lower bound, it indicates missing values between the lower bound and the first element.
                    missingRanges.Add(new List<int> { lower, nums[0] - 1 });
                }

                for (int i = 1; i < missRange; ++i)
                {
                    // Explore the missing ranges between adjacent numbers in the 'nums' array.
                    if ((long)nums[i] - nums[i - 1] > 1)
                    {
                        // Identify the missing range between two consecutive numbers.
                        missingRanges.Add(new List<int> { nums[i - 1] + 1, nums[i] - 1 });
                    }
                }

                if (nums[missRange - 1] < upper)
                {
                    // If the last number in the 'nums' array is smaller than the upper bound, it implies that there's a missing range between the last number and the upper bound.
                    missingRanges.Add(new List<int> { nums[missRange - 1] + 1, upper });
                }

                return missingRanges;
            }
            catch (Exception)
            {
                // Handle any exceptions that may occur.
                throw;
            }
        }

        /*
         
        Question 2

        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.An input string is valid if:
        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.
 
        Example 1:

        Input: s = "()"
        Output: true
        Example 2:

        Input: s = "()[]{}"
        Output: true
        Example 3:

        Input: s = "(]"
        Output: false

        Constraints:

        1 <= s.length <= 104
        s consists of parentheses only '()[]{}'.

        Time complexity:O(n^2), space complexity:O(1)
        */

        public static bool IsValid(string s)
        {
            try
            {
                // Create a stack to keep track of opening brackets
                Stack<char> stack = new Stack<char>();

                // Iterate through each character in the input string
                foreach (char c in s)
                {
                    // Check if the current character is an opening bracket
                    if (c == '(' || c == '{' || c == '[')
                    {
                        // Push the opening bracket onto the stack to track it
                        stack.Push(c);
                    }
                    // Check if the current character is a closing bracket
                    else if (c == ')' || c == '}' || c == ']')
                    {
                        // Check if the stack is empty (no corresponding opening bracket found)
                        if (stack.Count == 0)
                        {
                            // If the stack is empty, there's no matching opening bracket, so the string is invalid
                            return false;
                        }

                        // Pop the top bracket from the stack (the last encountered opening bracket)
                        char openBracket = stack.Pop();

                        // Check if the current closing bracket matches the last open bracket
                        if ((c == ')' && openBracket != '(') ||
                            (c == '}' && openBracket != '{') ||
                            (c == ']' && openBracket != '['))
                        {
                            // If the closing bracket does not match the corresponding open bracket, the string is invalid
                            return false;
                        }
                    }
                }

                // If the stack is empty at the end, all brackets are matched and valid
                return stack.Count == 0;
            }
            catch (Exception)
            {
                // Handle any exceptions that may occur
                throw;
            }
        }

        /*

        Question 3:
        You are given an array prices where prices[i] is the price of a given stock on the ith day.You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
        Example 1:
        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

        Example 2:
        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transactions are done and the max profit = 0.
 
        Constraints:
        1 <= prices.length <= 105
        0 <= prices[i] <= 104

        Time complexity: O(n), space complexity:O(1)
        */

        public static int MaxProfit(int[] prices)
        {
            try
            {
                // Check if the input array is null or contains less than 2 elements
                if (prices == null || prices.Length < 2)
                {
                    // If so, it's impossible to make a profit, so return 0
                    return 0;
                }

                // Initialize variables to keep track of the minimum price and maximum profit
                int minPrice = prices[0];
                int maxProfit = 0;

                // Iterate through the array starting from the second element (index 1)
                for (int i = 1; i < prices.Length; i++)
                {
                    // Check if the current price is lower than the previously recorded minimum price
                    if (prices[i] < minPrice)
                    {
                        // If so, update the minimum price
                        minPrice = prices[i];
                    }
                    // Check if the profit from selling at the current price is greater than the recorded maximum profit
                    else if (prices[i] - minPrice > maxProfit)
                    {
                        // If so, update the maximum profit
                        maxProfit = prices[i] - minPrice;
                    }
                }

                // Return the maximum profit achieved
                return maxProfit;
            }
            catch (Exception)
            {
                // Handle any exceptions that may occur.
                throw;
            }
        }

        /*
        
        Question 4:
        Given a string num which represents an integer, return true if num is a strobogrammatic number.A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).
        Example 1:

        Input: num = "69"
        Output: true
        Example 2:

        Input: num = "88"
        Output: true
        Example 3:

        Input: num = "962"
        Output: false

        Constraints:
        1 <= num.length <= 50
        num consists of only digits.
        num does not contain any leading zeros except for zero itself.

        Time complexity:O(n), space complexity:O(1)
        */

        public static bool IsStrobogrammatic(string s)
        {
            try
            {
                // Define a dictionary that holds valid pairs of strobogrammatic digits.
                Dictionary<char, char> pairs = new Dictionary<char, char>
                    {
                        {'0', '0'},
                        {'1', '1'},
                        {'6', '9'},
                        {'8', '8'},
                        {'9', '6'}
                    };

                // Initialize two pointers, 'left' and 'right', to check the string symmetrically.
                int left = 0;
                int right = s.Length - 1;

                // Continue checking until the 'left' pointer is less than or equal to the 'right' pointer.
                while (left <= right)
                {
                    // Get the characters at the 'left' and 'right' positions.
                    char leftDigit = s[left];
                    char rightDigit = s[right];

                    // Check if the left digit is a valid strobogrammatic digit and if it corresponds to the right digit.
                    if (!pairs.ContainsKey(leftDigit) || pairs[leftDigit] != rightDigit)
                    {
                        // If not, the string is not strobogrammatic, so return false.
                        return false;
                    }

                    // Move the 'left' pointer to the right, and the 'right' pointer to the left for the next comparison.
                    left++;
                    right--;
                }

                // If the loop completes without finding any non-strobogrammatic pairs, the string is strobogrammatic.
                return true;
            }
            catch (Exception)
            {
                // Handle any exceptions that may occur.
                throw;
            }
        }


        /*

        Question 5:
        Given an array of integers nums, return the number of good pairs.A pair (i, j) is called good if nums[i] == nums[j] and i < j. 

        Example 1:

        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        Example 2:

        Input: nums = [1,1,1,1]
        Output: 6
        Explanation: Each pair in the array are good.
        Example 3:

        Input: nums = [1,2,3]
        Output: 0

        Constraints:

        1 <= nums.length <= 100
        1 <= nums[i] <= 100

        Time complexity:O(n), space complexity:O(n)

        */

        public static int NumIdenticalPairs(int[] nums)
        {
            try
            {
                // Create a dictionary to count the occurrences of each number.
                Dictionary<int, int> count = new Dictionary<int, int>();

                // Initialize a variable to keep track of good pairs.
                int goodPairs = 0;

                // Iterate through the given 'nums' array.
                foreach (int num in nums)
                {
                    // Check if the current number already exists in the dictionary.
                    if (count.ContainsKey(num))
                    {
                        // If the number exists, it means we have found a good pair.
                        // Increment 'goodPairs' by the count of the existing number in the dictionary.
                        goodPairs += count[num];

                        // Increment the count of the existing number in the dictionary.
                        count[num]++;
                    }
                    else
                    {
                        // If the number doesn't exist in the dictionary, add it with a count of 1.
                        count[num] = 1;
                    }
                }

                // Return the total count of good pairs.
                return goodPairs;
            }
            catch (Exception)
            {
                // Handle any exceptions that may occur.
                throw;
            }
        }

        /*
        Question 6

        Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

        Example 1:

        Input: nums = [3,2,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2.
        The third distinct maximum is 1.
        Example 2:

        Input: nums = [1,2]
        Output: 2
        Explanation:
        The first distinct maximum is 2.
        The second distinct maximum is 1.
        The third distinct maximum does not exist, so the maximum (2) is returned instead.
        Example 3:

        Input: nums = [2,2,3,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2 (both 2's are counted together since they have the same value).
        The third distinct maximum is 1.
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1

        Time complexity:O(nlogn), space complexity:O(n)
        */

        public static int ThirdMax(int[] nums)
        {
            try
            {
                // Initialize three variables to track the first, second, and third maximum values.
                long firstMax = long.MinValue;
                long secondMax = long.MinValue;
                long thirdMax = long.MinValue;

                // Iterate through the elements in the 'nums' array.
                foreach (int num in nums)
                {
                    if (num > firstMax)
                    {
                        // If the current number is greater than the first maximum,
                        // update the third and second maximum accordingly and set the first maximum to the current number.
                        thirdMax = secondMax;
                        secondMax = firstMax;
                        firstMax = num;
                    }
                    else if (num < firstMax && num > secondMax)
                    {
                        // If the current number is between the first and second maximum,
                        // update the third and second maximum and set the second maximum to the current number.
                        thirdMax = secondMax;
                        secondMax = num;
                    }
                    else if (num < secondMax && num > thirdMax)
                    {
                        // If the current number is between the second and third maximum,
                        // update the third maximum to the current number.
                        thirdMax = num;
                    }
                }

                // Check if a third maximum exists (not equal to long.MinValue).
                // If it exists, return the third maximum; otherwise, return the first maximum.
                return thirdMax != long.MinValue ? (int)thirdMax : (int)firstMax;
            }
            catch (Exception)
            {
                // Handle any exceptions that may occur.
                throw;
            }
        }

        /*
        
        Question 7:

        You are playing a Flip Game with your friend. You are given a string currentState that contains only '+' and '-'. You and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move, and therefore the other person will be the winner.Return all possible states of the string currentState after one valid move. You may return the answer in any order. If there is no valid move, return an empty list [].
        Example 1:
        Input: currentState = "++++"
        Output: ["--++","+--+","++--"]
        Example 2:

        Input: currentState = "+"
        Output: []
 
        Constraints:
        1 <= currentState.length <= 500
        currentState[i] is either '+' or '-'.

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static IList<string> GeneratePossibleNextMoves(string currentState)
        {
            try
            {
                // Initialize a list to store possible next states.
                List<string> nextStates = new List<string>();

                // Iterate through the characters of the 'currentState' string, stopping at the second-to-last character.
                for (int i = 0; i < currentState.Length - 1; i++)
                {
                    // Check if the current character and the next character are both '+' (consecutive '++').
                    if (currentState[i] == '+' && currentState[i + 1] == '+')
                    {
                        // Create a char array representing the new state by replacing '++' with '--'.
                        char[] newState = currentState.ToCharArray();
                        newState[i] = '-';
                        newState[i + 1] = '-';

                        // Add the new state as a string to the list of possible next states.
                        nextStates.Add(new string(newState));
                    }
                }

                // Return the list of possible next states.
                return nextStates;
            }
            catch (Exception)
            {
                // Handle any exceptions that may occur.
                throw;
            }
        }

        /*

        Question 8:

        Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:

        Input: s = "leetcodeisacommunityforcoders"
        Output: "ltcdscmmntyfrcdrs"

        Example 2:

        Input: s = "aeiou"
        Output: ""

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static string RemoveVowels(string s)
        {
            try
            {
                // Initialize an empty string to store the result.
                string result = "";

                // Define a string containing all vowels.
                string vowels = "aeiouAEIOU";

                // Iterate through each character in the input string.
                foreach (char c in s)
                {
                    // Check if the character is not a vowel, and if so, append it to the result.
                    if (vowels.IndexOf(c) == -1)
                    {
                        result += c;
                    }
                }

                // Return the resulting string.
                return result;
            }
            catch (Exception)
            {
                // Handle any exceptions that may occur.
                throw;
            }
        }


        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<string> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "\"" + input[i] + "\""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}