using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

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

public class LeetCodeS0004_MedianOfTwoSortedArrays
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        // Step 0: Input ví dụ
        // nums1 = [1,3], nums2 = [2]
        // Step 1: đảm bảo nums1 là mảng nhỏ hơn
        if (nums1.Length > nums2.Length)
            return FindMedianSortedArrays(nums2, nums1);
        int m = nums1.Length; // m = 1 (sau swap)
        int n = nums2.Length; // n = 2
        int left = 0, right = m; // left=0, right=1
        // Step 2: Binary Search
        while (left <= right)
        {
            // Step 3: chia nums1
            int partition1 = (left + right) / 2;
            // Step 4: chia nums2 sao cho tổng bên trái = 1 nửa
            int partition2 = (m + n + 1) / 2 - partition1;
            // Step 5: lấy giá trị biên
            int maxLeft1 = (partition1 == 0) ? int.MinValue : nums1[partition1 - 1];
            int minRight1 = (partition1 == m) ? int.MaxValue : nums1[partition1];
            int maxLeft2 = (partition2 == 0) ? int.MinValue : nums2[partition2 - 1];
            int minRight2 = (partition2 == n) ? int.MaxValue : nums2[partition2];
            // ===== DEBUG =====
            // Ví dụ LẦN 1:
            // partition1 = 0, partition2 = 2
            // nums1: [ | 2]
            // nums2: [1, 3 | ]
            // L1=-∞, R1=2, L2=3, R2=+∞
            // Step 6: kiểm tra partition đúng chưa
            if (maxLeft1 <= minRight2 && maxLeft2 <= minRight1)
            {
                // Step 7: nếu tổng là lẻ
                if ((m + n) % 2 == 1)
                {
                    // median = max bên trái
                    // Ví dụ: max(2,1) = 2
                    return Math.Max(maxLeft1, maxLeft2);
                }
                // Step 8: nếu tổng là chẵn
                return (Math.Max(maxLeft1, maxLeft2) + Math.Min(minRight1, minRight2)) / 2.0;
            }
            // Step 9: nếu lấy quá nhiều từ nums1 → đi trái
            else if (maxLeft1 > minRight2)
            {
                // Ví dụ: L1=5 > R2=3 → sai
                right = partition1 - 1;
            }
            // Step 10: nếu lấy quá ít → đi phải
            else
            {
                // Ví dụ:
                // L1=-∞, R1=2
                // L2=3, R2=∞ → sai vì 3 > 2
                // → cần lấy thêm từ nums1
                left = partition1 + 1;
            }
            // ===== DEBUG LẦN 2 =====
            // partition1 = 1, partition2 = 1
            // nums1: [2 | ]
            // nums2: [1 | 3]
            // L1=2, R1=∞, L2=1, R2=3
            // → ĐÚNG → return 2
        }
        throw new ArgumentException("Input arrays are not sorted.");
    }
}

public class Test_Median_S0004
{
    public static void Run()
    {
        var solver = new LeetCodeS0004_MedianOfTwoSortedArrays();

        Console.WriteLine(solver.FindMedianSortedArrays(
            new int[] { 1, 3 },
            new int[] { 2 }
        )); // 2

        Console.WriteLine(solver.FindMedianSortedArrays(
            new int[] { 1, 2 },
            new int[] { 3, 4 }
        )); // 2.5

        Console.WriteLine(solver.FindMedianSortedArrays(
            new int[] { 0, 0 },
            new int[] { 0, 0 }
        )); // 0

        Console.WriteLine(solver.FindMedianSortedArrays(
            new int[] { },
            new int[] { 1 }
        )); // 1

        Console.WriteLine(solver.FindMedianSortedArrays(
            new int[] { 2 },
            new int[] { }
        )); // 2
    }

    public double FindMedianSortedArrays_2(int[] nums1, int[] nums2)
    {
        // Step 0: Input 
        // nums1= [1,3], nums2 = [2]
        // Step 1: dam bao nums1 la mang nho hon
        if (nums1.Length > nums2.Length)
            return FindMedianSortedArrays_2(nums2, nums1);
        int m = nums1.Length;
        int n = nums2.Length;
        int left = 0; int right = m; // left=0, right=1
        // Step 2: Binary search
        while (left <= right)
        {
            // Step 3: chia nums1
            int partition1 = (left + right) / 2;
            // Step 4: chia nums2 sao cho tong ben trai bang = 1 nua
            int partition2 = (m + n + 1) / 2 - partition1;
            // Step 5: lay gia tri bien
            int maxLeft1 = (partition1 == 0) ? int.MinValue : nums1[partition1 - 1];
            int minRight1 = (partition1 == m) ? int.MaxValue : nums1[partition1];
            int maxLeft2 = (partition2 == 0) ? int.MinValue : nums2[partition2 - 1];
            int minRight2 = (partition2 == n) ? int.MaxValue : nums2[partition2];

            if (maxLeft1 <= minRight2 && maxLeft2 <= minRight1)
            {
                if ((m + n) % 2 == 1)
                {
                    return Math.Max(maxLeft1, maxLeft2);
                }

                return (Math.Max(maxLeft1, maxLeft2) + Math.Min(minRight1, minRight2)) / 2.0;
            }
            else if (maxLeft1 > minRight2)
            {
                right = partition1 - 1;
            }
            else
            {
                left = partition1 + 1;
            }
        }
        throw new ArgumentException("Input arrays are not sorted.");
    }
}

public class LeetCodeS0005_LongestPalindrome
{
    public string LongestPalindrome(string s)
    {
        // Ví dụ: s = "babad"

        if (s.Length <= 1) return s;

        int res = 0;
        int l = 0;
        int r = 0;
        int len = s.Length;

        // ===== EVEN LENGTH (abba) =====
        for (int i = 0; i < len; i++)
        {
            for (int diff = 1; i - diff + 1 >= 0 && i + diff < len; diff++)
            {
                // ===== DEBUG =====
                // center = i, diff = 1
                // so sánh s[i] và s[i+1]

                if (s[i - diff + 1] != s[i + diff])
                {
                    // Ví dụ:
                    // s = "babad"
                    // i=0 → b vs a → break
                    break;
                }
                else if (res < diff * 2)
                {
                    // palindrome chẵn tìm được
                    // length = diff * 2

                    // Ví dụ:
                    // "bb" trong "cbbd"

                    res = diff * 2;
                    l = i - diff + 1;
                    r = i + diff;

                    // ===== DEBUG =====
                    // UPDATE EVEN:
                    // substring = s[l..r]
                    // ví dụ: "bb"
                }
            }
        }

        // ===== ODD LENGTH (aba) =====
        for (int i = 0; i < len; i++)
        {
            for (int diff = 1; i - diff >= 0 && i + diff < len; diff++)
            {
                // ===== DEBUG =====
                // center = i, diff = 1
                // so sánh s[i-1] và s[i+1]

                if (s[i - diff] != s[i + diff])
                {
                    // Ví dụ:
                    // i=0 → không có trái → break
                    break;
                }
                else if (res < diff * 2 + 1)
                {
                    // palindrome lẻ tìm được
                    // length = diff * 2 + 1

                    // Ví dụ:
                    // "aba" trong "babad"

                    res = diff * 2 + 1;
                    l = i - diff;
                    r = i + diff;

                    // ===== DEBUG =====
                    // UPDATE ODD:
                    // substring = s[l..r]
                    // ví dụ: "aba"
                }
            }

            // ===== DEBUG (TRACE 1 CASE) =====
            // Ví dụ i = 2 trong "babad":
            // center = 'b'
            // diff = 1 → a == a ✔️ → "aba"
            // diff = 2 → b == d ❌ → stop
        }

        // ===== FINAL =====
        // l = start, r = end
        // substring = s[l..r]

        return s.Substring(l, r - l + 1);
    }

    public string LongestPalindrome_2(string s)
    {
        if (s.Length <= 1) return s;

        int res = 0;
        int l = 0;
        int r = 0;
        int len = s.Length;

        for (int i = 0; i < len; i++)
        {
            for (int diff = 1; i - diff + 1 <= 0 && i + diff < len; i++)
            {
                if (s[i - diff + 1] != s[i + diff])
                {
                    break;
                }
                else if (res < diff * 2)
                {
                    res = diff * 2;
                    l = i - diff + 1;
                    r = i + diff;
                }
            }
        }
        return s.Substring(l, r - l + 1);
    }
}


public class TestS0005_LeetCodeS0005_LongestPalindrome
{
    public static void Run()
    {
        var sol = new LeetCodeS0005_LongestPalindrome();

        Console.WriteLine("===== TEST 1 =====");
        string s1 = "babad";
        Console.WriteLine($"Input: {s1}");
        Console.WriteLine($"Output: {sol.LongestPalindrome(s1)}");

        Console.WriteLine("\n===== TEST 2 =====");
        string s2 = "cbbd";
        Console.WriteLine($"Input: {s2}");
        Console.WriteLine($"Output: {sol.LongestPalindrome(s2)}");

        Console.WriteLine("\n===== TEST 3 =====");
        string s3 = "a";
        Console.WriteLine($"Input: {s3}");
        Console.WriteLine($"Output: {sol.LongestPalindrome(s3)}");
    }
}

public class LeetCodeS0006_Zigzag
{
    public string Convert(string s, int numRows)
    {
        // Ví dụ:
        // s = "PAYPALISHIRING", numRows = 3

        if (numRows == 1) return s;

        int maxDist = numRows * 2 - 2;
        // numRows = 3 → maxDist = 4

        StringBuilder buf = new StringBuilder();

        // ===== ROW LOOP =====
        for (int i = 0; i < numRows; i++)
        {
            int index = i;

            // ===== DEBUG =====
            // Row 0 → i = 0
            // Row 1 → i = 1
            // Row 2 → i = 2

            // ===== ROW ĐẦU & CUỐI =====
            if (i == 0 || i == numRows - 1)
            {
                // Ví dụ Row 0:
                // index = 0 → P
                // index = 4 → A
                // index = 8 → H
                // index = 12 → N

                while (index < s.Length)
                {
                    buf.Append(s[index]);

                    // ===== DEBUG =====
                    // buf = "P"
                    // buf = "PA"
                    // buf = "PAH"
                    // buf = "PAHN"

                    index += maxDist; // nhảy 4 bước
                }
            }
            else
            {
                // ===== ROW GIỮA =====
                // Ví dụ Row 1:

                // index = 1 → A
                // index = 3 → P
                // index = 5 → L
                // index = 7 → S ...

                while (index < s.Length)
                {
                    // ký tự thẳng
                    buf.Append(s[index]);

                    // ===== DEBUG =====
                    // buf = "PAHNA"

                    index += maxDist - i * 2;
                    // i = 1 → bước = 4 - 2 = 2

                    if (index >= s.Length)
                        break;

                    // ký tự chéo
                    buf.Append(s[index]);

                    // ===== DEBUG =====
                    // buf = "PAHNAP"

                    index += i * 2;
                    // i = 1 → bước = 2
                }
            }

            // ===== DEBUG =====
            // Sau mỗi row:

            // Row 0 → "PAHN"
            // Row 1 → "PAHNAPLSIIG"
            // Row 2 → "PAHNAPLSIIGYIR"
        }

        // ===== FINAL =====
        // return "PAHNAPLSIIGYIR"

        return buf.ToString();
    }

    public string Convert_2(string s, int numRows)
    {
        if (numRows <= 1) return s;

        int maxDist = numRows * 2 - 2;
        StringBuilder buf = new StringBuilder();

        for (int i = 0; i < numRows; i++)
        {
            int index = i;

            if (i == 0 || i == numRows - 1)
            {
                while (index < s.Length)
                {
                    buf.Append(s[index]);
                    index += maxDist;
                }
            }
            else
            {
                while (index < s.Length)
                {
                    buf.Append(s[index]);

                    index += maxDist - i * 2;

                    if (index > s.Length)
                        break;

                    buf.Append(s[index]);

                    index += i * 2;
                }
            }
        }

        return buf.ToString();

    }
}

public class TestS0006
{
    public static void Run()
    {
        var sol = new LeetCodeS0006_Zigzag();

        Console.WriteLine("===== TEST 1 =====");
        sol.Convert("PAYPALISHIRING", 3);

        Console.WriteLine("\n===== TEST 2 =====");
        sol.Convert("PAYPALISHIRING", 4);

        Console.WriteLine("\n===== TEST 3 =====");
        sol.Convert("A", 1);
    }
}

public class S0007_reverse_integer
{
    public int Reverse(int x)
    {
        // Ví dụ:
        // x = 123

        long rev = 0;

        // ===== LOOP =====
        while (x != 0)
        {
            // Step 1: lấy chữ số cuối
            int digit = x % 10;

            // ===== DEBUG =====
            // x = 123 → digit = 3
            // x = 12  → digit = 2
            // x = 1   → digit = 1

            // Step 2: thêm vào số đảo
            rev = rev * 10 + digit;

            // ===== DEBUG =====
            // rev = 0*10 + 3 = 3
            // rev = 3*10 + 2 = 32
            // rev = 32*10 + 1 = 321

            // Step 3: bỏ chữ số cuối của x
            x /= 10;

            // ===== DEBUG =====
            // x = 123 → 12 → 1 → 0
        }

        // Step 4: check overflow
        if (rev > int.MaxValue || rev < int.MinValue)
        {
            // ===== DEBUG =====
            // nếu vượt giới hạn 32-bit → return 0
            return 0;
        }

        // Step 5: trả kết quả
        return (int)rev;
    }

    public int Reverse_2(int x)
    {
        // x = 123
        long rev = 0;

        while (x != 0)
        {
            int degit = x % 10;
            rev = rev * 10 + degit;
            x /= 10;
        }

        if (x > int.MaxValue || x < int.MinValue)
        {
            return 0;
        }

        return (int)rev;
    }
}

public class TestS0007
{
    public static void Run()
    {
        var sol = new S0007_reverse_integer();

        Console.WriteLine("===== TEST 1 =====");
        Console.WriteLine(sol.Reverse(123));   // 321

        Console.WriteLine("===== TEST 2 =====");
        Console.WriteLine(sol.Reverse(-123));  // -321

        Console.WriteLine("===== TEST 3 =====");
        Console.WriteLine(sol.Reverse(120));   // 21

        Console.WriteLine("===== TEST 4 =====");
        Console.WriteLine(sol.Reverse(0));     // 0

        Console.WriteLine("===== TEST 5 (overflow) =====");
        Console.WriteLine(sol.Reverse(1534236469)); // 0
    }
}

public class S0008_string_to_integer_atoi
{
    public int MyAtoi(string str)
    {
        // ===== Step 0: check input =====
        // nếu null hoặc rỗng → không có gì parse → return 0
        if (string.IsNullOrEmpty(str))
            return 0;

        int i = 0;                 // con trỏ duyệt string
        int n = str.Length;        // độ dài string
        bool negative = false;     // lưu dấu âm/dương
        int num = 0;               // kết quả cuối

        // ===== Step 1: skip space =====
        // bỏ tất cả space ở đầu
        while (i < n && str[i] == ' ')
            i++;

        // ===== DEBUG =====
        // "   -42"
        // i chạy từ 0 → 1 → 2 → 3
        // dừng tại '-' (index 3)

        // nếu toàn space → return 0
        if (i == n) return 0;

        // ===== Step 2: check sign =====
        if (str[i] == '+')
        {
            // gặp dấu + → bỏ qua
            i++;
        }
        else if (str[i] == '-')
        {
            // gặp dấu - → set âm
            negative = true;
            i++;
        }

        // ===== DEBUG =====
        // "-42"
        // i = 1
        // negative = true

        // ===== Step 3: parse number =====
        // chỉ đọc khi còn là digit
        while (i < n && str[i] >= '0' && str[i] <= '9')
        {
            // lấy giá trị số từ char
            int digit = str[i] - '0';

            // ===== DEBUG =====
            // '4' → 4
            // '2' → 2

            // nếu âm → đổi dấu
            if (negative)
                digit = -digit;

            // ===== DEBUG =====
            // digit = -4, -2 nếu negative = true

            // ===== Step 4: check overflow =====

            // ⚠️ overflow âm (nhỏ hơn int.MinValue)
            if (num < int.MinValue / 10 ||
               (num == int.MinValue / 10 && digit < -8))
            {
                // ===== DEBUG =====
                // ví dụ:
                // num = -214748364
                // digit = -9 → vượt -2147483648
                return int.MinValue;
            }

            // ⚠️ overflow dương (lớn hơn int.MaxValue)
            if (num > int.MaxValue / 10 ||
               (num == int.MaxValue / 10 && digit > 7))
            {
                // ===== DEBUG =====
                // ví dụ:
                // num = 214748364
                // digit = 8 → vượt 2147483647
                return int.MaxValue;
            }

            // ===== Step 5: build number =====
            // push digit vào số
            num = num * 10 + digit;

            // ===== DEBUG =====
            // ví dụ:
            // num = 0 → 4 → 42
            // hoặc:
            // num = 0 → -4 → -42

            // move pointer
            i++;

            // ===== DEBUG =====
            // i tăng dần qua từng ký tự
        }

        // ===== Step 6: return =====
        return num;

        // ===== DEBUG FINAL =====
        // input: "   -42"
        // output: -42
    }

    public int MyAtoi(string str)
    {
        if (string.IsNullOrEmpty(str))
            return 0;

        int i = 0;
        int n = str.Length;
        bool negative = false;
        int num = 0;

        while (i < n && str[i] == ' ')
            i++;

        if (i == n) return 0;

        if (str[i] == '+')
        {
            i++;
        }
        else if (str[i] == '-')
        {
            negative = true;
            i++;
        }

        while (i < n && str[i] >= '0' && str[i] <= '9')
        {
            int digit = str[i] - '0';

            if (negative)
                digit = -digit;

            if (num < int.MinValue / 10 ||
                (num == int.MinValue / 10 && digit < -8))
            {
                return int.MinValue;
            }

            if (num > int.MaxValue / 10 ||
                (num == int.MaxValue / 10 && digit > 7))
            {
                return int.MaxValue;
            }

            num = num * 10 + digit;

            i++;
        }
        return num;
    }
}

public class TestS0008
{
    public static void Run()
    {
        var sol = new S0008_string_to_integer_atoi();

        Console.WriteLine("===== TEST 1 =====");
        Console.WriteLine(sol.MyAtoi("42")); // 42

        Console.WriteLine("===== TEST 2 =====");
        Console.WriteLine(sol.MyAtoi("   -42")); // -42

        Console.WriteLine("===== TEST 3 =====");
        Console.WriteLine(sol.MyAtoi("4193 with words")); // 4193

        Console.WriteLine("===== TEST 4 =====");
        Console.WriteLine(sol.MyAtoi("words and 987")); // 0

        Console.WriteLine("===== TEST 5 =====");
        Console.WriteLine(sol.MyAtoi("-91283472332")); // -2147483648

        Console.WriteLine("===== TEST 6 =====");
        Console.WriteLine(sol.MyAtoi("2147483648")); // 2147483647
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
        Console.WriteLine($"LeetCodeS0004_MedianOfTwoSortedArrays");
        Test_Median_S0004.Run();
        Console.WriteLine($"TestS0005_LeetCodeS0005_LongestPalindrome");
        TestS0005_LeetCodeS0005_LongestPalindrome.Run();
        Console.WriteLine($"LeetCodeS0006_Zigzag");
        TestS0006.Run();
        Console.WriteLine($"S0007_reverse_integer");
        TestS0007.Run();
        Console.WriteLine($"S0008_string_to_integer_atoi");
        TestS0008.Run();
    }
}