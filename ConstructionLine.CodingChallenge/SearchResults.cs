using System.Collections.Generic;

namespace ConstructionLine.CodingChallenge
{
    public class SearchResults
    {
        public List<Shirt> Shirts { get; set; }


        public List<SizeCount> SizeCounts { get; set; }


        public List<ColorCount> ColorCounts { get; set; }
    }


    public class SizeCount
    {
        public Size Size { get; set; }

        public int Count { get; set; }

        public SizeCount(Size size, int count)
        {
            Size = size;
            Count = count;
        }
    }


    public class ColorCount
    {
        public Color Color { get; set; }

        public int Count { get; set; }

        public ColorCount(Color color, int count)
        {
            Color = color;
            Count = count;
        }
    }
}