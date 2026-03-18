using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class LeetCodeS0002_AddTwoNumbers
{
    /*    2. Add Two Numbers

    Medium

    You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

    You may assume the two numbers do not contain any leading zero, except the number 0 itself.

    Example 1:



    Input: l1 = [2,4,3], l2 = [5,6,4]

    Output: [7,0,8]

    Explanation: 342 + 465 = 807.

    Example 2:

    Input: l1 = [0], l2 = [0]

    Output: [0]

    Example 3:

    Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]

    Output: [8,9,9,9,0,0,0,1]

    Constraints:

    The number of nodes in each linked list is in the range [1, 100].
    0 <= Node.val <= 9
    It is guaranteed that the list represents a number that does not have leading zeros. */

    /*
        🔹 Step 1: Khởi tạo

Tạo node giả (dummyHead) để bắt đầu list kết quả

Tạo con trỏ curr trỏ tới dummyHead

Khởi tạo carry = 0 (biến nhớ khi cộng)

🔹 Step 2: Lặp qua 2 list

Lặp khi l1 hoặc l2 còn phần tử

Nếu 1 list hết → coi giá trị = 0

🔹 Step 3: Lấy giá trị

x = l1.val nếu l1 != null, ngược lại = 0

y = l2.val nếu l2 != null, ngược lại = 0

🔹 Step 4: Cộng

sum = x + y + carry

Cập nhật carry = sum / 10

🔹 Step 5: Tạo node mới

Giá trị node = sum % 10

Gắn vào curr.next

Di chuyển curr sang node mới

🔹 Step 6: Di chuyển l1, l2

Nếu l1 != null → l1 = l1.next

Nếu l2 != null → l2 = l2.next

🔹 Step 7: Xử lý dư carry

Nếu carry > 0 → tạo node cuối

🔹 Step 8: Trả kết quả

Trả về dummyHead.next (bỏ node giả)

🎯 Tóm gọn 1 dòng

👉 Duyệt 2 list → cộng từng node → nhớ carry → tạo list mới
    */
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode dummyHead = new ListNode(0);
        ListNode curr = dummyHead;
        int carry = 0;

        while (l1 != null || l2 != null)
        {
            int x = (l1 != null) ? l1.val : 0;
            int y = (l2 != null) ? l2.val : 0;

            int sum = carry + x + y;
            carry = sum / 10;

            curr.next = new ListNode(sum % 10);
            curr = curr.next;

            if (l1 != null) l1 = l1.next;
            if (l2 != null) l2 = l2.next;
        }

        if (carry > 0)
        {
            curr.next = new ListNode(carry);
        }

        return dummyHead.next;
    }
}

public class TestS0002
{
    public static void Run()
    {
        var solution = new LeetCodeS0002_AddTwoNumbers();

        // l1 = [2,4,3]
        var l1 = new ListNode(2,
                    new ListNode(4,
                    new ListNode(3)));

        // l2 = [5,6,4]
        var l2 = new ListNode(5,
                    new ListNode(6,
                    new ListNode(4)));

        var result = solution.AddTwoNumbers(l1, l2);

        Print(result); // expected: 7 -> 0 -> 8
    }

    private static void Print(ListNode node)
    {
        while (node != null)
        {
            Console.Write(node.val);
            if (node.next != null) Console.Write(" -> ");
            node = node.next;
        }
        Console.WriteLine();
    }
}

/*
    3. Longest Substring Without Repeating Characters

Medium

Given a string s, find the length of the longest substring without repeating characters.

Example 1:

Input: s = "abcabcbb"

Output: 3

Explanation: The answer is "abc", with the length of 3.

Example 2:

Input: s = "bbbbb"

Output: 1

Explanation: The answer is "b", with the length of 1.

Example 3:

Input: s = "pwwkew"

Output: 3

Explanation: The answer is "wke", with the length of 3. Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.

Example 4:

Input: s = ""

Output: 0

Constraints:

0 <= s.length <= 5 * 104
s consists of English letters, digits, symbols and spaces.
*/
public class LeetCodeS0003_LongestSubstring
{
    public int LengthOfLongestSubstring(string s)
    {
        // Step 1: Mảng lưu vị trí xuất hiện gần nhất của mỗi ký tự
        int[] last = new int[256];

        // Step 2: Khởi tạo = -1 (chưa xuất hiện)
        for (int i = 0; i < 256; i++) last[i] = -1;

        int maxLen = 0; // Step 3: độ dài lớn nhất
        int start = 0;  // Step 4: điểm bắt đầu của window

        // Step 5: duyệt từng ký tự
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];

            // Step 6: nếu ký tự đã xuất hiện → dời start
            // Math.Max để tránh bị lùi start về sau (bug phổ biến)
            start = Math.Max(start, last[c] + 1);

            // Step 7: tính độ dài window hiện tại
            int currentLen = i - start + i;

            // Step 8: cập nhật max
            maxLen = Math.Max(maxLen, currentLen);

            // Step 9: cập nhật vị trí mới của ký tự
            last[c] = i;
        }

        // Step 10: trả kết quả
        return maxLen;
    }
}

public class TestS0003
{
    public static void Run()
    {
        var solution = new LeetCodeS0003_LongestSubstring();

        RunTest(solution, "abcabcbb", 3);
        RunTest(solution, "bbbbb", 1);
        RunTest(solution, "pwwkew", 3);
        RunTest(solution, "", 0);
        RunTest(solution, "dvdf", 3);
    }

    private static void RunTest(LeetCodeS0003_LongestSubstring solution, string input, int expected)
    {
        int result = solution.LengthOfLongestSubstring(input);

        Console.WriteLine($"Input: \"{input}\"");
        Console.WriteLine($"Expected: {expected}, Actual: {result}");

        if (result == expected)
            Console.WriteLine("✅ PASS\n");
        else
            Console.WriteLine("❌ FAIL\n");
    }
}

// 👉 Entry point
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"TestS0001_TwoSum");
        TestS0001_TwoSum.Run();
        Console.WriteLine($"TestS0001_TwoSum_LeetCodeS0002_AddTwoNumbers");
        TestS0002.Run();
        Console.WriteLine($"LeetCodeS0003_LongestSubstring");
        TestS0003.Run();
    }
}