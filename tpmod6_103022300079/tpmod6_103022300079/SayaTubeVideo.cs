using System;
using System.Diagnostics;

namespace tpmod6_103022300079
{
    public class SayaTubeVideo
    {
        private int id;
        private string title;
        private int playCount;

        public SayaTubeVideo(string title)
        {
            Debug.Assert(!string.IsNullOrEmpty(title) && title.Length <= 100, "Judul video tidak boleh null dan panjang maksimal 100 karakter.");

            Random rand = new Random();
            this.id = rand.Next(10000, 100000);
            this.title = title;
            this.playCount = 0;
        }

        public void IncreasePlayCount(int count)
        {
            Debug.Assert(count >= 0 && count <= 10000000, "Jumlah play count harus antara 0 dan 10.000.000.");

            try
            {
                checked
                {
                    this.playCount += count;
                }
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Error: Terjadi overflow pada jumlah play count.");
            }
        }

        public void PrintVideoDetails()
        {
            Console.WriteLine("Video ID: " + this.id);
            Console.WriteLine("Title: " + this.title);
            Console.WriteLine("Play Count: " + this.playCount);
        }

        public static void Main(string[] args)
        {
            SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract - [NAMA_PRAKTIKAN]");

            video.IncreasePlayCount(5);
            video.PrintVideoDetails();

            Console.WriteLine("\nMenguji batas input play count:");
            try
            {
                video.IncreasePlayCount(10000001);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.WriteLine("\nMenguji overflow dengan loop:");
            for (int i = 0; i < 500; i++)
            {
                video.IncreasePlayCount(int.MaxValue / 2);
            }
        }
    }
}
