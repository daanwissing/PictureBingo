using System.Collections.Generic;
using System.Threading.Tasks;


namespace PictureBingo
{

    public class BingoData
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }

    public class BingoService
    {

        public Task<List<BingoData>> GetBingoData()
        {
            var result = new List<BingoData>
            {
                new BingoData {Name="Chase"},
                new BingoData{Name="Marshall"},
                new BingoData{Name="Ryder"}
            };
            return Task.FromResult(result);
        }

    }
}