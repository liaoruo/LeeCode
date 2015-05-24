using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0024.SwapNodesinPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            var ln = new ListNode(1);
            ln.next = new ListNode(2);
            ln.next.next = new ListNode(3);
            ln.next.next.next = new ListNode(4);
            ln.next.next.next.next = new ListNode(5);

            Solution solution = new Solution();
            var ret = solution.SwapPairs(ln);

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
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            var newHead = new ListNode(int.MinValue);
            newHead.next = head;

            var n0 = newHead;
            var n1 = newHead.next;
            var n2 = newHead.next.next;

            while(true)
            {
                n0.next = n2;                
                n1.next = n2.next;
                n2.next = n1;

                n0 = n1;
                if (n0 == null || n0.next == null || n0.next.next == null)
                {
                    break;
                }
                else
                {
                    n1 = n0.next;
                    n2 = n0.next.next;
                }

            }
            

            return newHead.next ;
        }
    }

}
