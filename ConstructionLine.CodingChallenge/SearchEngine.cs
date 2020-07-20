using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        private readonly List<Shirt> _shirts;
        private SearchResults _searchResults;
        private readonly List<SizeCount> _sizeCount;
        private readonly List<ColorCount> _colorCount;

        public SearchEngine(List<Shirt> shirts)
        {
            _shirts = shirts;
            _sizeCount = new List<SizeCount>();
            foreach(var size in Size.All)
            {
                _sizeCount.Add(new SizeCount(size, 0));
            }

            _colorCount = new List<ColorCount>();
            foreach (var color in Color.All)
            {
                _colorCount.Add(new ColorCount(color, 0));
            }
            _searchResults = new SearchResults
            {
                Shirts = new List<Shirt>(),
                SizeCounts = _sizeCount,
                ColorCounts = _colorCount
            };

        }


        public SearchResults Search(SearchOptions options)
        {
            var selectedShirts = _shirts.Where(item => options.Colors.Any(Color => Color.Name.Equals(item.Color.Name))
            && options.Sizes.Any(size => size.Name.Equals(item.Size.Name))).ToList();

            var colorGrp = from shirts in selectedShirts
                       group shirts by shirts.Color into colorGroup
                       select new
                       {
                           Color = colorGroup.Key,
                           Count = colorGroup.Count(),
                       };

            var sizeGrp = from shirts in selectedShirts
                           group shirts by shirts.Size into sizeGroup
                           select new
                           {
                               Size = sizeGroup.Key,
                               Count = sizeGroup.Count(),
                           };

            _searchResults.Shirts = selectedShirts;
            foreach(var c in colorGrp.ToList())
            {
                var val = _searchResults.ColorCounts.FirstOrDefault(x => x.Color.Id.Equals(c.Color.Id));
                val.Count = c.Count;
            }

            foreach (var c in sizeGrp.ToList())
            {
                var val = _searchResults.SizeCounts.FirstOrDefault(x => x.Size.Id.Equals(c.Size.Id));
                val.Count = c.Count;
            }
            return _searchResults;
        }
    }
}