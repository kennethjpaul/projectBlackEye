namespace WindowsFormsApplication1
{
    internal class mainTile
    {
       public string Title,Link,Img;

        public mainTile()
        {
            
        }
        public void add_mainTile(string _title, string _link)
        {
            Title = _title;
            Link = _link;
        }
        public void add_newsTile(string _title, string _link, string _img)
        {
            Title = _title;
            Link = _link;
            Img = _img;
        }

    }
}