using UnityEngine;

public static class ResultsDataHolder
{
    // “еперь хранит общее количество монет, собранное на момент финиша
    public static int LastLevelScore { get; set; }
    public static string CurrentLevelName { get; set; }
    // ћожешь добавить сюда LastLevelTime, если решишь его использовать позже
}