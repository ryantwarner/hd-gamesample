using UnityEngine;
using UnityEngine.GameFoundation;
using UnityEngine.GameFoundation.DataAccessLayers;
using UnityEngine.GameFoundation.DataPersistence;

public class GameInventory : MonoBehaviour
{
    private static GameInventory _instance;

    public static GameInventory Instance { get { return _instance; } }

    public GameObject m_InventoryUIContainer;

    static Inventory m_Keychain;

    private void Awake()
    {
        // this data layer will not save any data, it is usually used for examples or tests
        IDataAccessLayer dataLayer = new MemoryDataLayer(GameFoundationSerializableData.Empty);

        // you always need to call Initialize once per session
        GameFoundation.Initialize(dataLayer);

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        m_Keychain = InventoryManager.GetInventory("keychain");
    }

    void Start()
    {
        // get the coin item by its ID
        /*InventoryItem coinItem = Wallet.GetItem("coin");

        Debug.LogFormat("coins in wallet at start: {0}", coinItem.quantity);

        coinItem.quantity -= 25;

        Debug.LogFormat("coins in wallet: {0}", coinItem.quantity);*/
    }

    public void AddItem(string itemReference)
    {
        if (m_Keychain.ContainsItem(itemReference)) return;
        m_Keychain.AddItem(itemReference);
        int keyTypeID = StatManager.GetIntValue(m_Keychain.GetItem(itemReference), "keyType");
        _instance.m_InventoryUIContainer.transform.GetChild(keyTypeID).gameObject.SetActive(true);
    }

    public void RemoveItem(string itemReference)
    {
        if (!m_Keychain.ContainsItem(itemReference)) return;
        m_Keychain.RemoveItem(itemReference);
    }

    public GameItem GetItem(string itemReference)
    {
        return m_Keychain.GetItem(itemReference);
    }

    public bool ContainsItem(string itemReference)
    {
        return m_Keychain.ContainsItem(itemReference);
    }

    public bool ContainsItem(string itemReference, string itemValueReference, float itemValue)
    {
        GameItem item = m_Keychain.GetItem(itemReference);
        float value = StatManager.GetIntValue(item, itemValueReference);
        return value == itemValue;
    }
}