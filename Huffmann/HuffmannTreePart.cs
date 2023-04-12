namespace Huffmann;

public class HuffmannTreePart
{
    public bool IsBase { get; set; }
    public string Letter { get; set; }
    public HuffmannTreePart LeftNext { get; set; }
    public HuffmannTreePart RightNext { get; set; }
    public int Count { get; set; }
}