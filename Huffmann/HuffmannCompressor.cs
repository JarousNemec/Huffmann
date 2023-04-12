namespace Huffmann;

public class HuffmannCompressor
{
    public string Compress(string input)
    {
        List<char> letters = new List<char>();
        List<HuffmannTreePart> countOfChars = new List<HuffmannTreePart>();
        foreach (var letter in input)
        {
            if (countOfChars.All(x => x.Letter != letter.ToString()))
            {
                countOfChars.Add(new HuffmannTreePart()
                {
                    IsBase = true,
                    Letter = letter.ToString(),
                    Count = input.Count(x => x == letter)
                });
                letters.Add(letter);
            }
        }

        countOfChars = countOfChars.OrderBy(x => x.Count).ToArray().ToList();
        items = countOfChars;
        ConcatParts();
        var tree = items[0];

        Dictionary<char, string> letterCodes = new();
        foreach (var letter in letters)
        {
            letterCodes.Add(letter, GetPathToChar(letter, tree, string.Empty));
        }

        var compressed = string.Empty;
        foreach (var letter in input)
        {
            compressed += letterCodes[letter];
        }
        return compressed;
    }

    private List<HuffmannTreePart> items;

    private void ConcatParts()
    {
        var first = GetPartWithLowestCount(items);
        items.Remove(first);
        var second = GetPartWithLowestCount(items);
        items.Remove(second);
        var concat = new HuffmannTreePart()
        {
            IsBase = false, Count = first.Count + second.Count, Letter = first.Letter + second.Letter, LeftNext = first,
            RightNext = second
        };
        items.Add(concat);
        items = items.OrderBy(x => x.Count).ToArray().ToList();
        if (items.Count > 1)
        {
            ConcatParts();
        }
    }

    private HuffmannTreePart GetPartWithLowestCount(List<HuffmannTreePart> items)
    {
        var output = items[0];
        var count = items[0].Count;
        foreach (var item in items)
        {
            if (item.Count < count)
            {
                output = item;
                count = item.Count;
            }
        }

        return output;
    }

    private string GetPathToChar(char goal,HuffmannTreePart tree, string path)
    {
        if (tree.LeftNext.Letter.Contains(goal))
        {
            tree = tree.LeftNext;
            path += "0";
        }
        else
        {
            tree = tree.RightNext;
            path += "1";
        }

        if (tree.Letter.Length > 1)
            path = GetPathToChar(goal, tree, path);
        
        return path;
    }
}