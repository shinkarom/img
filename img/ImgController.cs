using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace img
{

    public class ImgController
    {

        private static Random rnd = new Random();

        private int CurPosition;

        List<String> AllImages = new List<string>();
        List<String> UnqueuedImages = new List<string>();
        List<String> QueuedImages = new List<string>();

        public int TotalCount { get => AllImages.Count(); }
        public int QueueCount { get => QueuedImages.Count(); }
        public int Position { get => CurPosition + 1; }
        public string Current { get => QueuedImages[CurPosition]; }

        public ImgController()
        {
            CurPosition = -1;
        }

        public void AddPath(string path)
        {
            HashSet<string> extensions = new HashSet<string> { ".bmp", ".gif", ".jpg", ".jpeg", ".png", ".tif", ".tiff" };
            foreach (var item in Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories))
                if (extensions.Contains(System.IO.Path.GetExtension(item)))
                    AllImages.Add(item);
        }

        public void MakeNewShuffle()
        {
            UnqueuedImages.Clear();
            UnqueuedImages.AddRange(AllImages);
        }

        public string Prev()
        {
            if (CurPosition > 0) CurPosition--;
            return QueuedImages[CurPosition];
        }

        public string Next()
        {
            if (UnqueuedImages.Count == 0) MakeNewShuffle();
            var rind = rnd.Next(0, UnqueuedImages.Count);
            QueuedImages.Add(UnqueuedImages[rind]);
            UnqueuedImages.RemoveAt(rind);
            CurPosition++;
            return QueuedImages[CurPosition];
        }

        public void DeleteCurrent()
        {
            var c = Current;
            int removes = 0;
            AllImages.Remove(c);
            while (QueuedImages.Contains(c))
            {
                QueuedImages.Remove(c);
                removes++;
            }
            CurPosition -= removes;
            File.Delete(c);
        }
    }
}
