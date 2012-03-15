namespace SimpleOCR
{
    class ImageChar
    {
        public ImageChar(int height, bool[] colors)
        {
            Height = height;
            Colors = new bool[30, height];
            LastXPosition = 0;
            for (var i = 0; i < colors.Length; i++)
                Colors[0, i] = colors[i];
        }

        private int LastXPosition { get; set; }
        public int Height { get; set; }
        public bool[,] Colors { get; set; }
        public string Letter { get; set; }

        public void AppendColors(bool[] colors)
        {
            LastXPosition++;
            for (var i = 0; i < colors.Length; i++)
                Colors[LastXPosition, i] = colors[i];
        }

        public override string ToString()
        {
            return Letter;
        }

        public override bool Equals(object obj)
        {
            return obj is ImageChar && Equals((ImageChar)obj);
        }

        public bool Equals(ImageChar obj)
        {
            for (var i = 0; i < 1; i++)
            {
                for (var j = 0; j < 1; j++)
                {
                    if (Colors[i, j] != obj.Colors[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            return Colors.GetHashCode();
        }
    }
}