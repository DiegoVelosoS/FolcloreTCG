using UnityEngine;
using System.Collections;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager Instance { get; private set; }

    [Header("Configurações de Animação")]
    public float cardPlayDuration = 0.5f;
    public float cardAttackDuration = 0.3f;
    public float cardDestroyDuration = 0.4f;
    public float cardHoverScale = 1.1f;
    public float cardHoverDuration = 0.2f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator PlayCardAnimation(Transform cardTransform, Vector3 targetPosition)
    {
        Vector3 startPosition = cardTransform.position;
        float elapsedTime = 0;

        while (elapsedTime < cardPlayDuration)
        {
            cardTransform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / cardPlayDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cardTransform.position = targetPosition;
    }

    public IEnumerator AttackAnimation(Transform attacker, Transform defender)
    {
        Vector3 attackerStartPosition = attacker.position;
        Vector3 defenderPosition = defender.position;
        Vector3 attackPosition = Vector3.Lerp(attackerStartPosition, defenderPosition, 0.5f);

        // Mover para frente
        float elapsedTime = 0;
        while (elapsedTime < cardAttackDuration / 2)
        {
            attacker.position = Vector3.Lerp(attackerStartPosition, attackPosition, elapsedTime / (cardAttackDuration / 2));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Retornar
        elapsedTime = 0;
        while (elapsedTime < cardAttackDuration / 2)
        {
            attacker.position = Vector3.Lerp(attackPosition, attackerStartPosition, elapsedTime / (cardAttackDuration / 2));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        attacker.position = attackerStartPosition;
    }

    public IEnumerator DestroyCardAnimation(Transform cardTransform)
    {
        float elapsedTime = 0;
        Vector3 startScale = cardTransform.localScale;
        Color startColor = cardTransform.GetComponent<SpriteRenderer>().color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0);

        while (elapsedTime < cardDestroyDuration)
        {
            float t = elapsedTime / cardDestroyDuration;
            cardTransform.localScale = Vector3.Lerp(startScale, Vector3.zero, t);
            cardTransform.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(cardTransform.gameObject);
    }

    public IEnumerator HoverCardAnimation(Transform cardTransform, bool isHovering)
    {
        float elapsedTime = 0;
        Vector3 startScale = cardTransform.localScale;
        Vector3 targetScale = isHovering ? startScale * cardHoverScale : startScale;

        while (elapsedTime < cardHoverDuration)
        {
            cardTransform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / cardHoverDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cardTransform.localScale = targetScale;
    }

    public IEnumerator ShakeCamera(float duration, float magnitude)
    {
        Vector3 originalPosition = Camera.main.transform.position;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            Camera.main.transform.position = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Camera.main.transform.position = originalPosition;
    }
} 