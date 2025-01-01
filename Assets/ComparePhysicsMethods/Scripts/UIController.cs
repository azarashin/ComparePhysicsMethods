using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    [SerializeField]
    MonoSpawner _legacySpawner;

    [SerializeField]
    MonoSpawner _contactSpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        root.Q<Button>("button-legacy-collision").clicked += OnLegacy;
        root.Q<Button>("button-contact-collision").clicked += OnContact;
        root.Q<Button>("button-dots").clicked += OnGenerateByECS;
        
    }

    void OnDisable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        root.Q<Button>("button-legacy-collision").clicked -= OnLegacy;
        root.Q<Button>("button-contact-collision").clicked -= OnContact;
        root.Q<Button>("button-dots").clicked -= OnGenerateByECS;
    }


    private void OnLegacy()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        int numberOfObjects = root.Q<IntegerField>("input-number-of-objects").value;
        int height = root.Q<IntegerField>("input-height").value;
        float grid = root.Q<FloatField>("input-grid").value;
        Debug.Log($"UIController.OnLegacy: {numberOfObjects}, {height}, {grid}");
        _legacySpawner.Spawn(numberOfObjects, grid, height);
    }

    private void OnContact()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        int numberOfObjects = root.Q<IntegerField>("input-number-of-objects").value;
        int height = root.Q<IntegerField>("input-height").value;
        float grid = root.Q<FloatField>("input-grid").value;
        Debug.Log($"UIController.OnContact: {numberOfObjects}, {height}, {grid}");
        _contactSpawner.Spawn(numberOfObjects, grid, height);
    }

    private void OnGenerateByECS()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        int numberOfObjects = root.Q<IntegerField>("input-number-of-objects").value;
        int height = root.Q<IntegerField>("input-height").value;
        float grid = root.Q<FloatField>("input-grid").value;
//        SpawnerSystem.Enable = true;
//        SpawnerSystem.Max = numberOfObjects;
//        SpawnerSystem.Height = height; 
//        SpawnerSystem.Grid = grid;
    }
}