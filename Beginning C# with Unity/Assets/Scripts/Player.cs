namespace Beginning.CSharp
{
    public struct Player
    {
        private int lives;
        public string Name { get; set; }
        public int Score { get; set; }

        public int Lives { get => lives; set => lives = ++value; }
        
    }     
}
