using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoresAndCooldowns : MonoBehaviour {

    [SerializeField] private ExplosionGun player;
    [SerializeField] private MyPlayerController points;
    [SerializeField] private Text score;

    public Slider coolDownSlider;

    private void Start()
    {
        coolDownSlider.minValue = 0;
        coolDownSlider.maxValue = 5;
    }

    private void Update()
    {
        coolDownSlider.value = player.cooldown-Time.time;

        score.text = points.score.ToString();

    }
}
