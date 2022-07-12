using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public PlayerShip player;
    public Slider hitpointsBoard;
    public Slider shieldEnergyBoard;

    private void Update()
    {
        hitpointsBoard.value = player.hitpoints;
        shieldEnergyBoard.value = player.shieldEnergy;

    }

}



