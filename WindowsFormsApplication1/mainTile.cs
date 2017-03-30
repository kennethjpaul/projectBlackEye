namespace WindowsFormsApplication1
{
    internal class mainTile
    {
       public string Title,Link,Img;

        public mainTile(string _title, string _link)
        {
            Title = _title;
            Link = _link;
        }
        public mainTile(string _title, string _link, string _img)
        {
            Title = _title;
            Link = _link;
            Img = _img;
        }

    }
}