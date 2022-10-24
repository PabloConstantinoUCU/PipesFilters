using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using TwitterUCU;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            // imagen
            Console.WriteLine("HOLA MUNDO");
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");

            // pipes y filters
            FilterSave filterSave1 = new FilterSave("luke");
            FilterUpload filterUpload1 = new FilterUpload("Luke greyscale", "luke1.jpg");
            FilterUpload filterUpload2 = new FilterUpload("Luke greyscale inverted", "luke2.jpg");

            IPipe pipeNull1 = new PipeNull();

            IPipe pipeSerial1 = new PipeSerial(filterSave1, pipeNull1);

            IPipe pipeSerialUp2 = new PipeSerial(filterUpload2, pipeSerial1);
            IPipe pipeSerial20 = new PipeSerial(filterSave1, pipeSerialUp2);

            IFilter filterNegative = new FilterNegative();
            IPipe pipeSerial2 = new PipeSerial(filterNegative, pipeSerial20);

            IPipe pipeSerialUp3 = new PipeSerial(filterUpload1, pipeSerial2);
            IPipe pipeSerial3 = new PipeSerial(filterSave1, pipeSerialUp3);

            IFilter filterGreyscale = new FilterGreyscale();
            IPipe pipeSerial4 = new PipeSerial(filterGreyscale, pipeSerial3);

            IPicture imagenFiltros = pipeSerial4.Send(picture);

            /* string NombreFinal = filterSave1.Nombre;
            // twitter API
            var twitter = new TwitterImage();
            //Console.WriteLine(twitter.PublishToTwitter("Lucas",NombreFinal)); */


        }
    }
}
