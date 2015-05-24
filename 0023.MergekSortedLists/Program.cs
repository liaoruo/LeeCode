using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0023.MergekSortedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode l1 = new ListNode(0);
            l1.next = new ListNode(0);
            l1.next.next = new ListNode(0);

            ListNode l2 = new ListNode(0);
            l2.next = new ListNode(2);
            l2.next.next = new ListNode(3);

            ListNode l3 = new ListNode(1);
            l3.next = new ListNode(2);
            l3.next.next = new ListNode(3);

           
            Solution solution = new Solution();
            var ret=solution.MergeKLists(new ListNode[] { l1, l2, l3 });
            while(ret!=null)
            {
                System.Console.Write(ret.val + " ");
                ret = ret.next;
            }
            System.Console.WriteLine();
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
        public ListNode MergeKLists(ListNode[] lists)
        {
            SortedDictionary<int, ListNode> sd = new SortedDictionary<int, ListNode>();
            Dictionary<int, int> dupdic = new Dictionary<int, int>();

            foreach (var list in lists)
            {
                var clone = list;
                while (clone != null)
                {
                    if (dupdic.ContainsKey(clone.val))
                    {
                        dupdic[clone.val]++;
                        clone = clone.next;
                    }
                    else
                    {
                        dupdic.Add(clone.val, 1);
                        sd.Add(clone.val, clone);
                        break;
                    }
                }
            }

            ListNode ret=new ListNode(int.MinValue);
            ListNode temp=ret;
            while (sd.Count != 0)
            {
                var min = sd.ElementAt(0).Value.val;

                while(dupdic[min]>0)
                {
                    temp.next = new ListNode(min);
                    temp = temp.next;
                    dupdic[min]--;
                }

                var clone = sd.ElementAt(0).Value.next;
                sd.Remove(min);
                while (clone != null)
                {
                    if (dupdic.ContainsKey(clone.val))
                    {
                        if (dupdic[clone.val] != 0)
                        {
                            dupdic[clone.val]++;
                            clone = clone.next;
                        }
                        else
                        {
                            dupdic[clone.val]++;
                            sd.Add(clone.val, clone);
                            break;
                        }
                        
                    }
                    else
                    {
                        dupdic.Add(clone.val, 1);
                        sd.Add(clone.val, clone);
                        break;
                    }

                }
                

            }

            return ret.next;
        }
    }
}
