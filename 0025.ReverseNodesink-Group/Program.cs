using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0025.ReverseNodesink_Group
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
            ln.next.next.next.next.next = new ListNode(6);
            ln.next.next.next.next.next.next = new ListNode(7);

            Solution solution = new Solution();
            var ret = solution.ReverseKGroup(ln,2);

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
        public ListNode ReverseKGroup(ListNode head, int k)
        {

            ListNode newHead = new ListNode(int.MinValue);
            newHead.next = head;
            if (IsEnd(newHead, k))
            {
                return newHead.next;
            }
            
            ListNode tmp=newHead;
            ListNode start=null;
            var first=true;

            while (!IsEnd(tmp, k))
            {
                ListNode nextHead = null;
                if (first)
                {
                    first=false;
                    start = OneCircle(tmp, k,out nextHead);
                }
                else
                {
                    OneCircle(tmp, k,out nextHead);
                }
                tmp = nextHead;
            }

            return start;

        }

        public bool IsEnd(ListNode head ,int k)
        {
            var tmp = head;
            while (k-- > 0)
            {
                if (tmp.next == null)
                    return true;
                tmp = tmp.next;
            }
            return false;
        }
        public ListNode OneCircle(ListNode head, int k ,out ListNode nextHead)
        {
            var end = head.next;
            var n1 = head.next;
            var n2 = head.next.next;

            while (k > 1)
            {
                var n3 = n2.next;
                n2.next = n1;
                n1 = n2;
                n2 = n3;
                k--;
            }

            

            end.next = n2;
            nextHead = end;
            head.next = n1;
            return n1;
        }

    }
}
