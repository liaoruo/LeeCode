using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0019.RemoveNthNodeFromEndofList
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
            Solution solution = new Solution();
            var ret = solution.RemoveNthFromEnd(head, 5);
            while (ret != null)
            {
                System.Console.Write(ret.val+" ");
                ret = ret.next;
            }
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
        }
    }

    public class Solution
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var cnt = 0;
            var temp = head;
            while (temp != null)
            {
                cnt++;
                temp = temp.next;
            }
            if (cnt == n)
            {
                return head.next;
            }
            else if (cnt < n)
            {
                throw new Exception("Error");
            }
            else
            {
                var skip = cnt - n-1;
                var i=0;
                temp = head;
                while (i < skip)
                {
                    i++;
                    temp = temp.next;
                }
                temp.next = temp.next.next;
                return head;
            }
        }
    }
}
