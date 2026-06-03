using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Panels Setup")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject mapPanel;

    [Header("Scene Name")]
    [SerializeField] private string firstLevelSceneName = "Level1";

    private void Start()
    {
        // गेम सुरु हुँदा सधैं Main Menu Panel देखिने र Map Panel लुक्ने सुनिश्चित गर्ने
        if (mainMenuPanel != null) mainMenuPanel.SetActive(true);
        if (mapPanel != null) mapPanel.SetActive(false);
    }

    // १. यो Function लाई 'Start' Button को OnClick() मा Assign गर्नुहोस्
    public void OnStartButtonClick()
    {
        // 'IsFirstTime' चेक गर्ने (डिफॉल्ट १ = True हुन्छ)
        int isFirstTime = PlayerPrefs.GetInt("IsFirstTime", 1);

        if (isFirstTime == 1)
        {
            // पहिलो पटक हो भने: सिधै Level 1 Scene लोड गर्ने
            SceneManager.LoadScene(firstLevelSceneName);
        }
        else
        {
            // दोस्रो पटक हो भने: Main Menu लुकाउने र Map Panel देखाउने
            if (mainMenuPanel != null) mainMenuPanel.SetActive(false);
            if (mapPanel != null) mapPanel.SetActive(true);
        }
    }

    // २. यो Function लाई 'Quit' Button को OnClick() मा Assign गर्नुहोस्
    public void OnQuitButtonClick()
    {
        Debug.Log("Game is shutting down..."); // Unity Editor मा चेक गर्नको लागि
        
        Application.Quit(); // मोबाइल वा बिल्ड भर्सनमा गेम बन्द गर्नको लागि
    }
}