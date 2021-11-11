using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
//using CompAndDel.Twitter2;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
        PictureProvider provider = new PictureProvider();
        IPicture picture = provider.GetPicture(@"luke.jpg");
        IFilter filterOne = new FilterGreyscale();
        IFilter filterTwo= new FilterNegative();
        //IFilter filterThree= new FilterBlurConvolution();
        IPipe isnull = new PipeNull();

        IPipe SerialTwo = new PipeSerial(filterTwo, isnull );
        IPipe SerialOne = new PipeSerial(filterOne,SerialTwo);
        
        IPicture picture2 = SerialTwo.Send(picture);
        IPicture picture3 = SerialOne.Send(picture2);

        provider.SavePicture(picture2,"..\\..\\luke1.jpg");
        provider.SavePicture(picture3,"..\\..\\luke2.jpg");

        Twitter2 twitter  = new Twitter2("Hello 123 ", "..\\..\\luke1.jpg");
        twitter.SendToTwitter();


        }
    }
}
