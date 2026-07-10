using UnityEngine;
public class GameManager : MonoBehaviour
{
    [SerializeField] private DayConfiguration _day;

    [SerializeField] private HUB _hub;

    [SerializeField] private Selector _selector;
    [SerializeField] private ClientSpawner _clientSpawner;

    [SerializeField] private Cauldron _cauldron;

    [SerializeField] private const int MAX_PLAYER_LIVES = 3;
    private int numberPlayerLives;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _damage;
    [SerializeField] private AudioClip _nice;

    private int _indexCurrentDay;
    private int _currentClient;
    private Day _currentDay;


    void Start()
    {
        numberPlayerLives = MAX_PLAYER_LIVES;

        _day = Instantiate(_day);

        _cauldron.SendOrder += CompareRecipes;
        _selector.OnPauseGame += PauseGame;

        _currentDay = _day.Day[_indexCurrentDay];

        StartSpawn();

        _hub.RecipeSpawner.SpawnRecipes(_currentDay.Recipes);
    }


    public void StartSpawn()
    {

        TrySpawnClient();
    }

    public void TrySpawnClient()
    {

        if (_currentClient >= _currentDay.ClientDay.Length)
        {
            Debug.Log("DayComplete");
            return;
        }

        var getClient = _currentDay.ClientDay[_currentClient];

        _clientSpawner.SpawnClient(getClient);
        _clientSpawner.CurrentClient.OnClientExit = TrySpawnClient;
        _clientSpawner.CurrentClient.OnClientOrder = ShowOrder;
        _clientSpawner.CurrentClient.OnClientTime = UpdateOrder;
        _clientSpawner.CurrentClient.OnFailedOrder = FailedOrder;
    }

    public void ShowOrder(ItemData data)
    {
        _hub.RecipeView.SetView(data,_clientSpawner.CurrentClient._clientData);
        _hub.RecipeView.Show();
    }

    public void UpdateOrder(float time)
    {
        _hub.RecipeView.UpdateFill(time);

    }
    public void FailedOrder()
    {
        ReciveDamage();
    }

    public void PauseGame(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0;
            _hub.pauseView.Pause();
            return;
        }

        Time.timeScale = 1;
        _hub.pauseView.Resume();
    }

    public void SumarVida(int amount)
    {
        numberPlayerLives += amount;
    }

    public void CompareRecipes(ItemID itemDelivered)
    {
        if (itemDelivered.ID == _clientSpawner.CurrentClient.RequestedOrder.ID)
        {
            NiceTry();
            return;
        }
        ReciveDamage();
    }

    public void NiceTry()
    {
        _currentClient++;
        _clientSpawner.CurrentClient.ExitToShop();
        _hub.RecipeView.Hide();

        _audioSource.clip = _nice;
        _audioSource.Play();
    }

    private void ReciveDamage()
    {
        _audioSource.clip = _damage;
        _audioSource.Play();

        numberPlayerLives += -1;
        _hub.LifeView.Damage((MAX_PLAYER_LIVES - numberPlayerLives) - 1);
        _hub.RecipeView.Hide();

        _currentClient++;
        _clientSpawner.CurrentClient.ExitToShop();

        if (numberPlayerLives <= 0)
        {
            _hub.GameOverView.Show();
        }
    }
}
