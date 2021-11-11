using System;
using System.Drawing;
using TwitterUCU;

namespace CompAndDel
{

    public class Twitter2
    {
        private string texto;
        private string path;
        public Twitter2(string texto, string path)
        {
            this.texto = texto;
            this.path = path;
        }

        public void SendToTwitter(){
        var twitter = new TwitterImage();
        Console.WriteLine(twitter.PublishToTwitter(this.texto, this.path));
        }
        
        
    }
}