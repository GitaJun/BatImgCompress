using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ImgCompresser.Classess
{
    public class ImgCollector
    {
        private static readonly SortedSet<string> imgExtensions;
        static ImgCollector()
        {
            imgExtensions = new SortedSet<string>()
            {
                ".BMP",
                ".JPG",
                ".JPEG",
                ".PNG",
                ".GIF",
                ".BMP".ToLower(),
                ".JPG".ToLower(),
                ".JPEG".ToLower(),
                ".PNG".ToLower(),
                ".GIF".ToLower()
            };
        }

        /// <summary>
        /// 收集图片（遍历所有子目录）
        /// </summary>
        /// <param name="directory">图片目录对象</param>
        /// <returns>图片列表</returns>
        public List<FileInfo> CollectImg(DirectoryInfo directory)
        {
            List<FileInfo> imgs = new List<FileInfo>();
            foreach (var file in directory.GetFiles("*", SearchOption.AllDirectories))
            {
                if (imgExtensions.Contains(file.Extension))
                {
                    imgs.Add(file);
                }
            }
            return imgs;
        }


    }
}
