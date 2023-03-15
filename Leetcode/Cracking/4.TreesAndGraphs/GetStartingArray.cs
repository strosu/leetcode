using System;
namespace _4.TreesAndGraphs
{
    public static class GetStartingArray
    {
        public static List<LinkedList<int>> GetComposingLists(this TreeNode<int> current)
        {
            var result = new List<LinkedList<int>>();
            if (current == null)
            {
                result.Add(new LinkedList<int>());
                return result;
            }

            var prefix = new LinkedList<int>();
            prefix.AddFirst(current.Value);

            var leftLists = GetComposingLists(current.Left);
            var rightLists = GetComposingLists(current.Right);

            foreach (var leftList in leftLists)
            {
                foreach (var rightList in rightLists)
                {
                    var results = new List<LinkedList<int>>();
                    MergeLists(leftList, rightList, prefix, results);
                    result.AddRange(results);
                }
            }

            return result;
        }

        private static void MergeLists(LinkedList<int> first, LinkedList<int> second, LinkedList<int> prefix, List<LinkedList<int>> results)
        {
            if (!first.Any() || !second.Any())
            {
                LinkedList<int> result = new LinkedList<int>(prefix);

                if (first.Any())
                {
                    results.Add(new LinkedList<int>(prefix.Concat(first)));
                    return;
                }

                if (second.Any())
                {
                    results.Add(new LinkedList<int>(prefix.Concat(first)));
                    return;
                }

                results.Add(result);
                return;
            }

            var headFirst = first.First;
            first.RemoveFirst();

            prefix.AddLast(headFirst);
            MergeLists(first, second, prefix, results);

            prefix.RemoveLast();
            first.AddFirst(headFirst);

            var headSecond = second.First;
            second.RemoveFirst();

            prefix.AddLast(headSecond);
            MergeLists(first, second, prefix, results);

            prefix.RemoveLast();
            second.AddFirst(headSecond);
        }

    }
}

