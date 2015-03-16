using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0002.AddTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode list1 = new ListNode(1);
            list1.next = new ListNode(8);
            list1.next.next = new ListNode(6);
            list1.next.next.next = new ListNode(5);

            ListNode list2 = new ListNode(1);
            list2.next = new ListNode(2);
            list2.next.next = new ListNode(3);
            list2.next.next.next = new ListNode(4);

            var solution = new Solution();
            var ret = solution.AddTwoNumbers(list1, list2);
            //var ret = solution.ReverseList(list1);

            while (ret != null)
            {
                System.Console.WriteLine(ret.val);
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
        public ListNode ReverseList(ListNode list)
        {
            if (list == null || list.next == null)
            {
                return list;
            }
            ListNode A,B,C;
            A = list;
            B = list.next;
            C = list.next.next;
            //Tail Node
            A.next = null;

            while(C!=null)
            {                
                B.next = A;
                A = B;
                B = C;
                C = C.next;
            }
            B.next = A;
            return B;
        }
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {            
            if (l1 == null)
            {
                return l2;
            }
            if (l2 == null)
            {
                return l1;
            }

            bool hasAddOne = false;
            ListNode ret = new ListNode(0);
            ListNode temp = ret;
            while (true)
            {
                if (l1 != null)
                {
                    temp.val += l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    temp.val += l2.val;
                    l2 = l2.next;
                }
                if (hasAddOne)
                {
                    hasAddOne = false;
                    temp.val++;
                }
                if (temp.val >= 10)
                {
                    temp.val %= 10;
                    hasAddOne = true;
                }

                if (l1 == null && l2 == null)
                {
                    break;
                }
                else
                {
                    temp.next = new ListNode(0);
                    temp = temp.next;
                }
            }
            if (hasAddOne)
            {
                temp.next = new ListNode(1);
            }
            return ret;
        }
    }
}
