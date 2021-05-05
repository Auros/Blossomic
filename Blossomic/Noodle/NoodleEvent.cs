namespace Blossomic.Noodle
{
    public class NoodleEvent<T> where T : BaseNoodleEventData
    {
        public float Time { get; set; }
        public T Data { get; set; } = null!;
    }
}
