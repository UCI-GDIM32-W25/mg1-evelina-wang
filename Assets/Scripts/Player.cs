using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _plantPrefab;
    [SerializeField] private int _numSeeds = 5; 
    [SerializeField] private PlantCountUI _plantCountUI;

    private int _numSeedsLeft;
    private int _numSeedsPlanted;

    private void Start ()
    {
        _numSeedsLeft=_numSeeds;
        _numSeedsPlanted=0;
        _plantCountUI.UpdateSeeds(_numSeedsLeft,_numSeedsPlanted);
    }

    private void Update()
    {
        Vector3 movement=Vector3.zero;

        if(Input.GetKey(KeyCode.W))
        {
            movement.y+=1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement.y-=1;
        }
        if(Input.GetKey(KeyCode.A))
        {
            movement.x-=1;
        }
        if(Input.GetKey(KeyCode.D))
        {
            movement.x+=1;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlantSeed();
        }
        _playerTransform.position+=movement*_speed*Time.deltaTime;
    }

    public void PlantSeed ()
    {
        if(_numSeedsLeft<=0)
        return;
        Instantiate(_plantPrefab,_playerTransform.position,Quaternion.identity);
        _numSeedsLeft--;
        _numSeedsPlanted++;
        _plantCountUI.UpdateSeeds(_numSeedsLeft,_numSeedsPlanted);
    }
}
