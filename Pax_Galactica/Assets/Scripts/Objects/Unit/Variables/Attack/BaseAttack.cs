using UnityEngine;

public class BaseAttack : MonoBehaviour
{
    [SerializeField]
    private float delay;
    [SerializeField]
    private int damage;

    private float currentDelay;

    private void Awake()
    {
        currentDelay = delay;
    }

    public void Attack(BaseObject baseObject)
    {
        currentDelay = Mathf.Min(currentDelay + Time.deltaTime, delay);

        if (currentDelay == delay)
        {
            baseObject.Health.TakeDamage(damage);
            currentDelay = 0f;
        }
    }
}