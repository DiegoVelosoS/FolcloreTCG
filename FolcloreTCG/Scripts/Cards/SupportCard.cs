using UnityEngine;

public class SupportCard : Card
{
    public bool isContinuous = false;
    public bool isActivated = false;

    public override void PlayCard()
    {
        base.PlayCard();
        // Lógica específica para cartas de suporte
    }

    public override void ActivateEffect()
    {
        if (!isActivated)
        {
            base.ActivateEffect();
            // Efeito específico do suporte
            if (!isContinuous)
            {
                isActivated = true;
            }
        }
    }
} 