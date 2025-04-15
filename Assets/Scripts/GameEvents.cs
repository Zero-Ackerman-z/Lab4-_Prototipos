using System;
namespace Assets.Scripts
{
    public static class GameEvents
    {
        public static Action<int> OnHealthChanged;
        public static Action<int> OnMaxHealthSet;
        public static Action<int> OnScoreChanged;
        public static Action OnPlayerDeath;
        public static Action OnPlayerWin;
    }
}