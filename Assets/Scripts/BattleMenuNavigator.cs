using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class BattleMenuNavigator : MonoBehaviour
{
    [Header("Menu Buttons (in order)")]
    public Button[] menuButtons;
    private int currentIndex = 0;

    // Reference to PlayerInput component
    private PlayerInput playerInput;

    private InputAction navigateAction;
    private InputAction confirmAction;

    void Start()
    {
        HighlightButton(currentIndex);

        playerInput = GetComponent<PlayerInput>();
        if (playerInput != null)
        {
            navigateAction = playerInput.actions["Navigate"];
            confirmAction = playerInput.actions["Submit"];

            if (navigateAction != null)
                navigateAction.performed += OnNavigate;
            if (confirmAction != null)
                confirmAction.performed += OnConfirm;
        }
    }

    private void OnDestroy()
    {
        if (navigateAction != null)
            navigateAction.performed -= OnNavigate;
        if (confirmAction != null)
            confirmAction.performed -= OnConfirm;
    }

    private void OnNavigate(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        if (value.y > 0.5f)
            MoveSelection(-1);
        else if (value.y < -0.5f)
            MoveSelection(1);
    }

    private void OnConfirm(InputAction.CallbackContext context)
    {
        menuButtons[currentIndex].onClick.Invoke();
    }

    void MoveSelection(int direction)
    {
        SetHighlight(menuButtons[currentIndex], false);
        currentIndex += direction;
        if (currentIndex < 0)
            currentIndex = menuButtons.Length - 1;
        else if (currentIndex >= menuButtons.Length)
            currentIndex = 0;
        HighlightButton(currentIndex);
    }

    void HighlightButton(int index)
    {
        SetHighlight(menuButtons[index], true);
    }

    void SetHighlight(Button button, bool highlight)
    {
        var colors = button.colors;
        colors.normalColor = highlight ? new Color(1f, 0.9f, 0.6f) : Color.white; // soft gold highlight
        button.colors = colors;
    }
}
