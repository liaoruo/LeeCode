using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0021.MergeTwoSortedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(3);
            l1.next.next.next = new ListNode(4);
            l1.next.next.next.next = new ListNode(5);
            ListNode l2 = new ListNode(1);
            l2.next = new ListNode(2);
            l2.next.next = new ListNode(3);
            l2.next.next.next = new ListNode(4);
            l2.next.next.next.next = new ListNode(5);
            Solution solution = new Solution();
            var ret = solution.MergeTwoLists(l1, null);
            while (ret != null)
            {
                System.Console.Write(ret.val + " ");
                ret = ret.next;
            }
        }
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;
            ListNode ret = new ListNode(int.MinValue);
            ListNode temp = ret;
            while(l1!=null && l2!=null)
            {
                if (l1.val < l2.val)
                {
                    temp.next = l1;
                    l1 = l1.next;
                    temp = temp.next;
                }
                else
                {
                    temp.next = l2;
                    l2 = l2.next;
                    temp = temp.next;
                }
            }
            while (l1 != null)
            {
                temp.next = l1;
                l1 = l1.next;
                temp = temp.next;
            }
            while (l2 != null)
            {
                temp.next = l2;
                l2 = l2.next;
                temp = temp.next;
            }
            return ret.next;
        }
    }
}
