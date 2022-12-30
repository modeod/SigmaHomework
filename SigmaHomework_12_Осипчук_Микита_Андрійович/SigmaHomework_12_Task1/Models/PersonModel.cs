using System.Drawing;

namespace SigmaHomework_12_Task1.Models
{
    [Serializable]
    public class PersonModel
    {
        public string Name { get; set; } = "";

        public uint Age { get; set; }

        public Status Status { get; set; }

        public Point CurrentPosition { get; set; }

        public uint MaxTimeInSecondsToUseCashier { get; set; }
    }
}