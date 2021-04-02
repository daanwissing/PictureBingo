using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;


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
            var dir = "wwwroot/pics";

            var result = new List<BingoData>();
            foreach(var file in Directory.EnumerateFiles(dir))
            {
                result.Add(new BingoData
                {
                    Name = Path.GetFileNameWithoutExtension(file),
                    Path = $"pics/{Path.GetFileName(file)}"
                });
            }
            return Task.FromResult(result);
        }

    }
}