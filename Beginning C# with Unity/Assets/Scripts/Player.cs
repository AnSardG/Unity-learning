using UnityEngine;

namespace Beginning.CSharp
{
    public interface IPersistable
    {
        void Save();
    }
    public struct Player : IPersistable
    {
        private int lives;

        public Player(int lives, string name, int score) : this()
        {
            Lives = lives;
            Name = name;
            Score = score;
        }

        public Player(int score) : this(3, "Unknown", score) { }
        public string Name { get; set; }
        public int Score { get; set; }

        public int Lives { get => lives; set => lives = ++value; }


        public void Save()
        {
            Debug.Log("Save");
        }
    }     
}
