using UnityEngine;

[CreateAssetMenu(fileName = "LevelCreationData.asset", menuName = "LevelCreation/Creation", order = 0)]
public class LevelCreationData : ScriptableObject
{
    public int _numberOfWalkers;
    public int _numberOfIterations;

    public int _tileSize;
    public int _tileSeparation;
    public int _tileScale;
}
