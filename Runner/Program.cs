using System;
using System.Collections.Generic;

class LeetCodeS0001_TwoSum
{
    /*    1. Two Sum

    Easy

    Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

    You may assume that each input would have exactly one solution, and you may not use the same element twice.

    You can return the answer in any order.

    Example 1:

    Input: nums = [2,7,11,15], target = 9

    Output: [0,1]

    Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

    Example 2:

    Input: nums = [3,2,4], target = 6

    Output: [1,2]

    Example 3:

    Input: nums = [3,3], target = 6

    Output: [0,1]

    Constraints:

    2 <= nums.length <= 104
    -109 <= nums[i] <= 109
    -109 <= target <= 109
    Only one valid answer exists.
    Follow-up: Can you come up with an algorithm that is less than O(n2) time complexity?

    */
    public int[] TwoSum(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            if (dict.ContainsKey(complement))
            {
                return new int[] { dict[complement], i };
            }

            dict[nums[i]] = i;
        }

        return new int[0];
    }

    /*     Bài này yêu cầu bạn tìm 2 vị trí (index) trong mảng số nguyên sao cho tổng của 2 số tại đó bằng đúng target, 
với điều kiện mỗi phần tử chỉ được dùng 1 lần và luôn đảm bảo chỉ có đúng 1 đáp án. 
Nghĩa là bạn không cần xử lý nhiều trường hợp hay chọn phương án tối ưu giữa nhiều kết quả—chỉ cần tìm đúng cặp thỏa mãn là được. 
Ví dụ, với [2,7,11,15] và target = 9, vì 2 + 7 = 9 nên trả về [0,1]. 
Điểm quan trọng là bạn phải trả về index chứ không phải giá trị, 
và mục tiêu nâng cao của bài là tìm cách giải nhanh hơn O(n²) (tức không dùng brute force duyệt tất cả cặp).
 */


    public int[] TwoSum_WorkFlow(int[] nums, int target)
    {
        // create dict, for nums length, complement = target - nums[0],
        // check if dict contain Key complement -> It will be return result correct
        // check nums[index] current add to dict with key value
        var dict = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            if (dict.ContainsKey(complement))
            {
                return new int[] { dict[complement], i };
            }

            dict[nums[i]] = i;
        }

        return new int[0];
    }
}

// 👉 Class test data + chạy
class TestS0001_TwoSum
{
    public static void Run()
    {
        var solution = new LeetCodeS0001_TwoSum();

        var nums = new int[] { 2, 7, 11, 15 };
        var target = 9;

        var result = solution.TwoSum(nums, target);
        var result_TwoSum_WorkFlow = solution.TwoSum_WorkFlow(nums, target);

        Console.WriteLine($"Result: [{result[0]}, {result[1]}]");
    }
}

// 👉 Entry point
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"TestS0001_TwoSum");
        TestS0001_TwoSum.Run();
    }
}