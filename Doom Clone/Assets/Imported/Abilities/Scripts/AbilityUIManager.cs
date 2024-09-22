using UnityEngine;
using UnityEngine.UI;

public class AbilityUIManager : MonoBehaviour
{
    [SerializeField] private CurrentlyActiveAbility _activeAbility;
    [SerializeField] private Image _abilitySprite;

    [SerializeField] private SliderController _cooldownSlider;

    public void SwapSpriteImage(){
        Debug.Log("Swapping UI Elements");

        _abilitySprite.sprite = _activeAbility._activeAbility._spriteImage;
        _cooldownSlider.max = _activeAbility._activeAbility._cooldownTimer;
    }
}
