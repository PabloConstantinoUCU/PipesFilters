using System;
using System.Drawing;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using TwitterUCU;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y retorna su negativo.
    /// </remarks>
    public class FilterUpload : IFilter
    {
        string Path { get; set; }
        string Message { get; set; }

        TwitterImage twitter = new TwitterImage();

        public FilterUpload(string message, string path)
        {
            this.Message = message;
            this.Path = path;
        }

        public IPicture Filter(IPicture image)
        {
            Console.WriteLine(this.twitter.PublishToTwitter(this.Message,this.Path));


            return image;
        }
    }
}
