using Blossomic.Models;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlossomicPlayground
{
    public class Program
    {
        public static async Task Main(string[] __)
        {
            var uwu = "ed2a (NULCTRL MEISO FLIP - Reaxt)";
            FileInfo testInfoFile = new($@"C:\Program Files (x86)\Steam\steamapps\common\Beat Saber\Beat Saber_Data\CustomLevels\{uwu}\Info.dat");
            FileInfo testDiffFile = new($@"C:\Program Files (x86)\Steam\steamapps\common\Beat Saber\Beat Saber_Data\CustomLevels\{uwu}\ExpertPlusStandard.dat");

            BeatmapInfo testInfo =  await JsonSerializer.DeserializeAsync<BeatmapInfo>(testInfoFile.OpenRead());
            BeatmapDifficulty testDiff = await JsonSerializer.DeserializeAsync<BeatmapDifficulty>(testDiffFile.OpenRead());

            testDiff.CustomData.CustomEvents.ForEach(x => _ = x);
            using Stream testInfoSave = File.Create(Path.Combine(@"C:\Users\Auros\Desktop\test-info.json"));
            using Stream testDiffSave = File.Create(Path.Combine(@"C:\Users\Auros\Desktop\test-diff.json"));

            await JsonSerializer.SerializeAsync(testInfoSave, testInfo);
            await JsonSerializer.SerializeAsync(testDiffSave, testDiff);
        }
    }
}