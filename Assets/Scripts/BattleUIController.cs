using UnityEngine;
using UnityEngine.UI;

public class BattleUIController : MonoBehaviour
{
    [Header("Battle Buttons")]
    public Button attackButton;
    public Button defendButton;
    public Button skillButton;
    public Button itemButton;

    void Start()
    {
        // Hook up button listeners
        attackButton.onClick.AddListener(OnAttack);
        defendButton.onClick.AddListener(OnDefend);
        skillButton.onClick.AddListener(OnSkill);
        itemButton.onClick.AddListener(OnItem);
    }

    void OnAttack()
    {
        Debug.Log("Attack selected!");
        // TODO: Open target selection or trigger attack logic
    }

    void OnDefend()
    {
        Debug.Log("Defend selected!");
        // TODO: Trigger defense buff or end turn
    }

    void OnSkill()
    {
        Debug.Log("Skill menu opened!");
        // TODO: Open skill list UI
    }

    void OnItem()
    {
        Debug.Log("Item menu opened!");
        // TODO: Open inventory UI
    }
}
