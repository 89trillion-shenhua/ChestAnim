using Base;

public class GameData : Singleton<GameData>

{
    public int coinsCount;
    
    public void ChangeCoinsData(int addCount)
    {
        coinsCount += addCount;
    }
}