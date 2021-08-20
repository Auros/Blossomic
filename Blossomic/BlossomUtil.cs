using Blossomic.Models;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blossomic
{
    public class BlossomUtil
    {
        public static async Task<BeatmapDifficulty> Load(string path)
        {
            FileInfo diffFile = new(path);
            BeatmapDifficulty diff = (await JsonSerializer.DeserializeAsync<BeatmapDifficulty>(diffFile.OpenRead()))!;
            return diff;
        }

        public static async Task Save(BeatmapDifficulty beatmap, string path)
        {
            using Stream save = File.Create(path);
            await JsonSerializer.SerializeAsync(save, beatmap);
        }
    }
}