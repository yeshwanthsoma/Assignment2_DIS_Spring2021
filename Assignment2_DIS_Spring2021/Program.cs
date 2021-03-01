using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment2_DIS_Spring2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question1:
            Console.WriteLine("Question 1");
            int[] ar1 = { 2, 5, 1, 3, 4, 7 };
            int n1 = 3;
            ShuffleArray(ar1, n1);
            Console.WriteLine();

            //Question 2 
            Console.WriteLine("Question 2");
            int[] ar2 = {0,1,0,3,12};
            MoveZeroes(ar2);
            Console.WriteLine();

            //Question3
            Console.WriteLine("Question 3");
            int[] ar3 = { 1, 2, 3, 1, 1, 3 };
            CoolPairs(ar3);
            Console.WriteLine();

            //Question 4
            Console.WriteLine("Question 4");
            int[] ar4 = { 2, 7, 11, 15 };
            int target = 9;
            TwoSum(ar4, target);
            Console.WriteLine();

            //Question 5
            Console.WriteLine("Question 5");
            string s5 = "korfsucy";
            int[] indices = { 6, 4, 3, 2, 1, 0, 5, 7 };
            RestoreString(s5, indices);
            Console.WriteLine();

            //Question 6
            Console.WriteLine("Question 6");
            string s61 = "bulls";
            string s62 = "sunny";
            if(Isomorphic(s61,s62))
            {
                Console.WriteLine("Yes the two strings are Isomorphic");
            }
            else
            {
                Console.WriteLine("No, the given strings are not Isomorphic");
            }
            Console.WriteLine();

            //Question 7
            Console.WriteLine("Question 7");
            int[,] scores = { { 1, 91 }, { 1, 92 }, { 2, 93 }, { 2, 97 }, { 1, 60 }, { 2, 77 }, { 1, 65 }, { 1, 87 }, { 1, 100 }, { 2, 100 }, { 2, 76 } };
            HighFive(scores);
            Console.WriteLine();

            //Question 8
            Console.WriteLine("Question 8");
            int n8 = 19;
            if(HappyNumber(n8))
            {
                Console.WriteLine("{0} is a happy number",n8);
            }
            else
            {
                Console.WriteLine("{0} is not a happy number", n8);
            }

            Console.WriteLine();

            //Question 9
            Console.WriteLine("Question 9");
            int[] ar9 = { 7, 1, 5, 3, 6, 4 };
            int profit = Stocks(ar9);
            if(profit == 0)
            {
                Console.WriteLine("No Profit is possible");
            }
            else
            {
                Console.WriteLine("Profit is {0}",profit);
            }
            Console.WriteLine();

            //Question 10
            Console.WriteLine("Question 10");
            int n10 = 3;
            Stairs(n10);
            Console.WriteLine();
        }

        //Question 1
        /// <summary>
        /// Shuffle the input array nums consisting of 2n elements in the form [x1,x2,...,xn,y1,y2,...,yn].
        /// Print the array in the form[x1, y1, x2, y2, ..., xn, yn].
        ///Example 1:
        ///Input: nums = [2,5,1,3,4,7], n = 3
        ///Output: [2,3,5,4,1,7]
        ///  Explanation: Since x1 = 2, x2 = 5, x3 = 1, y1 = 3, y2 = 4, y3 = 7 then the answer is [2,3,5,4,1,7].
        ///Example 2:
        ///Input: nums = [1,2,3,4,4,3,2,1], n = 4
        ///Output: [1,4,2,3,3,2,4,1]
        ///Example 3:
        ///Input: nums = [1,1,2,2], n = 2
        ///Output: [1,2,1,2]
        /// </summary>

        private static void ShuffleArray(int[] nums, int n)
        {
            try
            {
                for (int i = 0, j = n; i <= n-1 && j <= 2*n-1; i++, j++)
                {
                    Console.Write(nums[i]+" "+nums[j]+" ");
                }
                Console.WriteLine();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);   //Print Error Message
                throw;
            }
        }

        //Question 2:
        /// <summary>
        /// Write a method to move all 0's to the end of the given array. You should maintain the relative order of the non-zero elements. 
        /// You must do this in-place without making a copy of the array.
       /// Example:
       ///Input: [0,1,0,3,12]
       /// Output: [1,3,12,0,0]
       /// </summary>
       
        private static void MoveZeroes(int[] ar2)
        {
            int count = 0;
            try
            {
                for(int i = 0; i < ar2.Length; i++)        //Counting no of zeros
                {
                    if (ar2[i] == 0)
                    {
                        count++;
                    }
                }

                for(int i = 0,j=0; i < ar2.Length-count && j<ar2.Length; j++)       //bringing all the non-zeros togeather
                {
                    if (ar2[j] != 0)
                    {
                        ar2[i] = ar2[j];
                        i++;
                    }
                }

                for(int i = 0; i < ar2.Length; i++)                         //Adding zeroes at last
                {
                    if (i >= ar2.Length - 2)
                    {
                        ar2[i] = 0;
                    }
                    Console.Write(ar2[i] + " ");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);   //Print Error Message
                throw;
            }
        }
        

        //Question 3
        /// <summary>
        /// For an array of integers - nums
        ///A pair(i, j) is called cool if nums[i] == nums[j] and i<j
        ///Print the number of cool pairs
        ///Example 1
        ///Input: nums = [1,2,3,1,1,3]
        ///Output: 4
        ///Explanation: There are 4 cool pairs (0,3), (0,4), (3,4), (2,5) 
        ///Example 3:
        ///Input: nums = [1, 2, 3]
        ///Output: 0
        ///Constraints: time complexity should be O(n).
        /// </summary>

        private static void CoolPairs(int[] nums)
        {
            int count = 0;
            try
            {
                Dictionary<int, int> dict = new Dictionary<int, int>();
                for(int i = 0; i < nums.Length; i++)
                {
                    if (!dict.ContainsKey(nums[i]))             //adding new key-value if it is not exists
                    {
                        dict.Add(nums[i], 1);
                    }
                    else
                    {
                        count += dict[nums[i]];             //counting no of cool pairs
                        dict[nums[i]] += 1;
                    }
                    
                }

                Console.WriteLine(count);
                
 
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);   //Print Error Message
                throw;
            }
        }

        //Question 4:
        /// <summary>
        /// Given integer target and an array of integers, print indices of the two numbers such that they add up to the target.
        ///You may assume that each input would have exactly one solution, and you may not use the same element twice.
        /// You can print the answer in any order
        ///Example 1:
        ///Input: nums = [2,7,11,15], target = 9
        /// Output: [0,1]
        ///Output: Because nums[0] + nums[1] == 9, we print [0, 1].
        ///Example 2:
        ///Input: nums = [3,2,4], target = 6
        ///Output: [1,2]
        ///Example 3:
        ///Input: nums = [3,3], target = 6
        ///Output: [0,1]
        ///Constraints: Time complexity should be O(n)
        /// </summary>
        private static void TwoSum(int[] nums, int target)
        {
            try
            {
                Dictionary<int, int> dict = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (!dict.ContainsValue(target-nums[i]))        //adding new other value if it is not exists
                    {
                        dict.Add(i, nums[i]);
                    }
                    else
                    {
                        int key=dict.FirstOrDefault(x=>x.Value == (target - nums[i])).Key;      //if other value exists print the pair
                        Console.WriteLine(i + "," + key);
                        break;
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);    //Print Error Message
                throw;
            }

        }

        //Question 5:
        /// <summary>
        /// Given a string s and an integer array indices of the same length.
        ///The string s will be shuffled such that the character at the ith position moves to indices[i] in the shuffled string.
        ///Print the shuffled string.
        ///Example 1
        ///Input: s = "korfsucy", indices = [6,4,3,2,1,0,5,7]
        ///Output: "usfrocky"
        ///Explanation: As shown in the assignment document, “K” should be at index 6, “O” should be at index 4 and so on. “korfsucy” becomes “usfrocky”
        ///Example 2:
        ///Input: s = "USF", indices = [0,1,2]
        ///Output: "USF"
        ///Explanation: After shuffling, each character remains in its position.
        ///Example 3:
        ///Input: s = "ockry", indices = [1, 2, 3, 0, 4]
        ///Output: "rocky"
        /// </summary>
        private static void RestoreString(string s, int[] indices)
        {
            Dictionary<int, char> dict = new Dictionary<int, char>();
            
            try
            {
               for(int i =0; i < s.Length; i++)     //Adding the key-value pairs 
                {
                    dict.Add(indices[i], s[i]);
                }

               for(int i = 0; i < s.Length; i++)    //Printing the key-value pairs
                {
                    Console.Write(dict[i]);
                }
                
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);  //Print Error Message
                throw;
            }
        }

        //Question 6
        /// <summary>
        /// Determine whether two give strings s1 and s2, are isomorphic.
        ///Two strings are isomorphic if the characters in s1 can be replaced to get s2.
        ///All occurrences of a character must be replaced with another character while preserving the order of characters.
        ///No two characters may map to the same character but a character may map to itself.
        ///Example 1:
        ///Input:s1 = “bulls” s2 = “sunny”
        ///Output : True
        ///Explanation: ‘b’ can be replaced with ‘s’ and similarly ‘u’ with ‘u’, ‘l’ with ‘n’ and ‘s’ with ‘y’.
        ///Example 2:
        ///Input: s1 = “usf” s2 = “add”
        ///Output : False
        ///Explanation: ‘u’ can be replaced with ‘a’, but ‘s’ and ‘f’ should be replaced with ‘d’ to produce s2, which is not possible. So False.
        ///Example 3:
        ///Input : s1 = “ab” s2 = “aa”
        ///Output: False
        /// </summary>
        private static bool Isomorphic(string s1, string s2)
        {
            try
            {
                if (s1.Length != s2.Length)     //if different lengths return false
                {
                    return false;
                }
                Dictionary<string, string> dict1 = new Dictionary<string, string>();
                Dictionary<string, string> dict2 = new Dictionary<string, string>();

                for(int i = 0; i < s1.Length; i++)      
                {

                    if (dict1.ContainsKey(s1[i].ToString()))                
                    {
                        if (!dict1[s1[i].ToString()].Equals(s2[i].ToString()))  //if the chars doesn't match return false
                        {
                            return false;
                        }
                    }

                    else
                    {
                        if (dict2.ContainsKey(s2[i].ToString()))        //if it has different char return false
                        {
                            return false;
                        }

                        dict1.Add(s1[i].ToString(), s2[i].ToString());
                        dict2.Add(s2[i].ToString(), "0");
                    }

                }

                return true;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);   //Print Error Message
                throw;
            }
        }

        //Question 7
        /// <summary>
        /// Given a list of the scores of different students, items, where items[i] = [IDi, scorei] represents one score from a student with IDi, calculate each student's top five average.
        /// Print the answer as an array of pairs result, where result[j] = [IDj, topFiveAveragej] represents the student with IDj and their top five average.Sort result by IDj in increasing order.
        /// A student's top five average is calculated by taking the sum of their top five scores and dividing it by 5 using integer division.
        /// Example 1:
        /// Input: items = [[1, 91], [1,92], [2,93], [2,97], [1,60], [2,77], [1,65], [1,87], [1,100], [2,100], [2,76]]
        /// Output: [[1,87],[2,88]]
        /// Explanation: 
        /// The student with ID = 1 got scores 91, 92, 60, 65, 87, and 100. Their top five average is (100 + 92 + 91 + 87 + 65) / 5 = 87.
        /// The student with ID = 2 got scores 93, 97, 77, 100, and 76. Their top five average is (100 + 97 + 93 + 77 + 76) / 5 = 88.6, but with integer division their average converts to 88.
        /// Example 2:
        /// Input: items = [[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100]]
        /// Output: [[1,100],[7,100]]
        /// Constraints:
        /// 1 <= items.length <= 1000
        /// items[i].length == 2
        /// 1 <= IDi <= 1000
        /// 0 <= scorei <= 100
        /// For each IDi, there will be at least five scores.
        /// </summary>
        private static void HighFive(int[,] items)
        {
            try
            {

                Dictionary<int, List<int>> scores = new Dictionary<int, List<int>>();
                for(int i = 0; i < items.Length/2; i++)
                { 
                    if (scores.ContainsKey(items[i, 0]))        
                    {
                        scores[items[i, 0]].Add(items[i, 1]);
                        scores[items[i, 0]].Sort();
                        scores[items[i, 0]].Reverse();          //sort them and reverse them
                    }
                    else
                    {
                        List<int> temp = new List<int>();       
                        temp.Add(items[i, 1]);
                        scores.Add(items[i, 0], temp);      //Adding all the key-value pairs
                    }
                }
                Dictionary<int,int> results = new Dictionary<int,int>();
                List<int> score = new List<int>();
                foreach (var p in scores)
                {
                    int temp=0;
                    for(int i = 0; i < 5; i++)
                    {
                        temp = temp + p.Value[i];       //Adding all the scores
                    }
                    temp = temp / 5;                    //Calculating the means
                    results.Add(p.Key, temp);
                    score.Add(temp);                //add thisnscore to dict
                }
                score.Sort();
                Console.Write("[");
                foreach (int q in score)
                {
                    Console.Write("["+ results.FirstOrDefault(x => x.Value == (q)).Key+","+q+"]");      //Printing all the dictionary values
                }

                Console.Write("]");


            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);   //Print Error Message
                throw;
            }
        }

        //Question 8
        /// <summary>
        /// Write an algorithm to determine if a number n is happy.
        ///A happy number is a number defined by the following process:
        ///•	Starting with any positive integer, replace the number by the sum of the squares of its digits.
        ///•	Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
        ///•	Those numbers for which this process ends in 1 are happy.
        ///Return true if n is a happy number, and false if not.
        ///Example 1:
        ///Input: n = 19
        ///Output: true
        ///Explanation:
        ///12 + 92 = 82
        ///82 + 22 = 68
        ///62 + 82 = 100
        ///12 + 02 + 02 = 1
        ///Example 2:
        ///Input: n = 2
        ///Output: false
        ///Constraints:
        ///1 <= n <= 231 - 1
        /// </summary>

        private static bool HappyNumber(int n)
        {
            try
            {
                if (n < 0)
                {
                    return false;
                }
                int num = n;
                int result = n;

                while (result > 9)          //for numbers greater than 9
                {
                    result = 0;
                    while (num > 0)
                    {
                        int temp = num % 10;        
                        result += temp*temp;        //Calculating the sum of squares of digits
                        num /= 10;
                    }
                    num = result;

                }


                if(result == 1 || result == 7)      //if a number becomes single digit 1 or 7 then it is a happy number
                {
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);   //Print Error Message
                throw;
            }
        }

        //Question 9
        /// <summary>
        /// Professor Manish is planning to invest in stocks. He has the data of the price of a stock for the next n days.  
        /// Tell him the maximum profit he can earn from the given stock prices.Choose a single day to buy a stock and choose another day in the future to sell the stock for a profit
        /// If you cannot achieve any profit return 0.
        /// Example 1:
        /// Input: prices = [7,1,5,3,6,4]
        /// Output: 5
        /// Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        /// Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.
        /// Example 2:
        /// Input: prices = [7,6,4,3,1]
        /// Output: 0
        ///Explanation: In this case, no transactions are done and the max profit = 0.
        ///Try to solve it in O(n) time complexity.
        /// </summary>

        private static int Stocks(int[] prices)
        {
            try
            {
                int maximumProfit = 0;          //maximum profit
                int stock = prices[0];
                for(int i = 0; i < prices.Length; i++)
                {
                    stock = Math.Min(stock, prices[i]);         //searching for the minimum buying value
                    maximumProfit = Math.Max(maximumProfit, prices[i] - stock);     //searching for the maximum profit value

                }
                return maximumProfit;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);   //Print Error Message
                throw;
            }
        }

        //Question 10
        /// <summary>
        /// Professor Clinton is climbing the stairs in the Muma College of Business. He generally takes one or two steps at a time.
        /// One day he came across an idea and wanted to find the total number of unique ways that he can climb the stairs. Help Professor Clinton.
        /// Print the number of unique ways. 
        /// Example 1:
        ///Input: n = 2
        ///Output: 2
        ///Explanation: There are two ways to climb to the top.
        ///1. 1 step + 1 step
        ///2. 2 steps
        ///Example 2:
        ///Input: n = 3
        ///Output: 3
        ///Explanation: There are three ways to climb to the top.
        ///1. 1 step + 1 step + 1 step
        ///2. 1 step + 2 steps
        ///3. 2 steps + 1 step
        ///Hint : Use the concept of Fibonacci series.
        /// </summary>

        private static void Stairs(int steps)
        {
            try
            {
                int res=0;
                if (steps == 0|| steps==1)          //if the steps are 0 or 1 return 0 or 1
                {
                    Console.WriteLine(steps);
                }
                else
                {
                    int a = 0, b = 1;
                    
                    for(int i = 0; i < steps; i++)      //Calculating the fibonacci series value
                    {
                        res = a + b;
                        a = b;
                        b = res;
                    }
                    Console.WriteLine(res);
                }
              
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);   //Print Error Message
                throw;
            }
        }
    }
}

/*    Self Reflection:
 *    I have learnt a new appraoch for the Happy Number Problem 
 *    Also got to know the IDE of visual studio and also the many features like Debugging.
 *    I have learnt more in dealing with 2 dimentional arrays in HighFive Problem
 *    I have taken around 5-5.5 hours to complete the whole assignment */




