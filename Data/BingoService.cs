using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Linq;


namespace PictureBingo
{

    public class BingoData
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }

    public class BingoService
    {
        public List<string> GetBingoOptions()
        {
            var dir = "wwwroot/pics";
            return Directory.EnumerateDirectories(dir)
                .Select(d => Path.GetRelativePath(dir, d))
                .ToList();
        }

        public Task<List<BingoData>> GetBingoData(string subdir)
        {
            var dir = Path.Combine("wwwroot","pics", subdir);

            var result = new List<BingoData>();
            foreach(var file in Directory.EnumerateFiles(dir))
            {
                result.Add(new BingoData
                {
                    Name = Path.GetFileNameWithoutExtension(file),
                    Path = Path.Combine("pics", subdir, Path.GetFileName(file))
                });
            }
            return Task.FromResult(result);
        }

    }
}