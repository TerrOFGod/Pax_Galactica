using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class PlaceLogick : MonoBehaviour
{
    public static PlaceLogick Instance { get; private set; }
    private PlacedEntity _currentPlaced;

    public void Place(BuildingProfile building)
    {
        if (_currentPlaced != null) return;

        GameObject ghost = Instantiate(building.BuildingView);
        _currentPlaced = new PlacedEntity(ghost.GetComponent<BuildingView>(),
            ghost.GetComponent<CollisionTriger>());
    }
    public void Update()
    {
        var inputModulr = (CustomStendModule)EventSystem.current.currentInputModule;
        if (_currentPlaced != null)
        {
            if (Input.GetMouseButtonDown(0) && _currentPlaced.TryPlace())
            {
                _currentPlaced = null;
            }
            else
            {
                _currentPlaced.MovieView(inputModulr.GetMousePositionOnGameObject());
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
        private CollisionTriger _triger;
        private bool _isPlaced = false;
        public PlacedEntity (BuildingView view, CollisionTriger triger)
        {
            _view = view;
            _triger = triger;
        }

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
