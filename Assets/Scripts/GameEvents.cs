using System;
namespace Assets.Scripts
{
    public static class GameEvents1
    {
        public delegate void IntEvent(int value);
        public delegate void SimpleEvent();

        
        public static event IntEvent OnHealthChanged;
        public static event IntEvent OnMaxHealthSet;
        public static event IntEvent OnScoreChanged;
        public static event SimpleEvent OnPlayerDeath;
        public static event SimpleEvent OnPlayerWin;

        public static void RaiseHealthChanged(int value) => OnHealthChanged?.Invoke(value);
        public static void RaiseMaxHealthSet(int value) => OnMaxHealthSet?.Invoke(value);
        public static void RaiseScoreChanged(int value) => OnScoreChanged?.Invoke(value);
        public static void RaisePlayerDeath() => OnPlayerDeath?.Invoke();
        public static void RaisePlayerWin() => OnPlayerWin?.Invoke();

    }
}