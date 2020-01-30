using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;

using EyeOpen.Imaging.Processing;

namespace Solution.CareBook.Gui.Test.Common
{
    internal static class Tools
    {
        public static string ImgSimilarityRate;

        public static Boolean ImageCompare(string image1, string image2)
        {
            if (image1 != null && image2 != null)
            {
                var ha = HashAlgorithm.Create();
                var f1 = new FileStream(image1, FileMode.Open);
                var f2 = new FileStream(image2, FileMode.Open);
                /* Calculate Hash */
                var hash1 = ha.ComputeHash(f1);
                var hash2 = ha.ComputeHash(f2);
                f1.Close();
                f2.Close();
                /* Show Hash in TextBoxes */
                var txtHash1 = BitConverter.ToString(hash1);
                var txtHash2 = BitConverter.ToString(hash2);
                /* Compare the hashs */
                return txtHash1.Equals(txtHash2);
            }
            return false;
        }

        public static Boolean ImageSimilarity(string image1, string image2)
        {
            ImgSimilarityRate = SharedResources.GetResource().ImgSimilarityRate;

            if (image1 != null && image2 != null)
            {
                var f1 = new ComparableImage(new FileInfo(image1));
                var f2 = new ComparableImage(new FileInfo(image2));
                /* Calculate Image Similarity */
                var sim = f1.CalculateSimilarity(f2);
                /* Show Hash in TextBoxes */
                return sim * 100 > Convert.ToInt32(ImgSimilarityRate);
            }
            return false;
        }

        public static Boolean CheckImageExist(string image)
        {
            if (image != null)
            {
                return File.Exists(image);
            }
            return false;
        }

        public static
            TimeSpan Time(Action action)
        {
            var stopwatch = Stopwatch.StartNew();
            action();
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
    }

}