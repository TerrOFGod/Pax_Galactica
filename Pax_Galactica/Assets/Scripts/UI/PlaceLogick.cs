using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class PlaceLogick : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerPlane;
    public static PlaceLogick Instance { get; private set; }
    private PlacedEntity _currentPlaced;

    public void Place(BuildingProfile building)
    {
        if (_currentPlaced != null) return;

        GameObject ghost = Instantiate(building.BuildingView);
        _currentPlaced = new PlacedEntity(ghost.GetComponent<BuildingView>(),
            ghost.GetComponent<CollisionTriger>(), building.Building);
    }
    public void Update()
    {
       // var inputModulr = (CustomStendModule)EventSystem.current.currentInputModule;
        if (_currentPlaced != null)
        {
            if (Input.GetMouseButtonDown(0) && _currentPlaced.TryPlace())
            {
                Instantiate(_currentPlaced.Building, _currentPlaced.View.transform.position, _currentPlaced.View.transform.rotation);
                Destroy(_currentPlaced.View.gameObject);
                _currentPlaced = null;
                Debug.Log(111);
            }
            else
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity, layerPlane))
                {
                    _currentPlaced.MovieView(hit.point);
                }
                
            }

        }
    }

    private void OnEnable()
    {
        Instance = this;
    }
    private void OnDisable()
    {
        Instance = null;
    }

    public class PlacedEntity
    {
        private BuildingView _view;
        private GameObject _building;
        private CollisionTriger _triger;
        private bool _isPlaced = false;
        public PlacedEntity (BuildingView view, CollisionTriger triger, GameObject building)
        {
            _building = building;
            _view = view;
            _triger = triger;
        }

        public GameObject Building => _building;

        public BuildingView View => _view;

        public void MovieView(Vector3 pos)
        {
            _view.CurrentTransform.position = pos;
        }
    
        public bool TryPlace()
        {
            if (_isPlaced) throw new System.InvalidOperationException();
            if (_triger.IsCollised) return false;

            Destroy(_triger);
            _isPlaced = true;
            return true;
        }
    }
}
