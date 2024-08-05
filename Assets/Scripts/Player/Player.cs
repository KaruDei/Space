using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private GameEvents _gameEvents;

    [Header("Elements")]
    [SerializeField] private List<GameObject> _oxygenElements;
    [SerializeField] private List<GameObject> _fuelElements;

    [Header("Audio")]
    [SerializeField] private AudioSource _oxygenAudio;
    [SerializeField] private AudioSource _fuelAudio;

    [Header("Time")]
    [SerializeField] private float _oxygenUseTime;
    [SerializeField] private float _fuelUseTime;

    private int _oxygen;
    private float _oxygenTimer;

    private int _fuel;
    private float _fuelTimer;

    private void Start()
    {
        if (_oxygenElements.Count != 0 && _fuelElements.Count != 0)
        {
            _oxygen = _oxygenElements.Count;
            _fuel = _fuelElements.Count;
            UpdateFuelElements();
            UpdateOxygenElements();
        }
        else
            Debug.LogError($"Oxygen Elements: {_oxygenElements.Count}, \nFuel Elements: {_fuelElements.Count}");
    }

    private void FixedUpdate()
    {
        AddTime();
    }

    private void AddTime()
    {
        if (_gameEvents.GameStatus())
        {
            if (_oxygenTimer + Time.fixedDeltaTime >= _oxygenUseTime && _oxygen > 0)
            {
                RemoveOxygen();
            }
            else
                _oxygenTimer += Time.fixedDeltaTime;

            if (_playerMovement.IsMoving)
            {
                if (_playerMovement.IsAfterburner)
                {
                    if (_fuelTimer + Time.fixedDeltaTime * 2 >= _fuelUseTime && _fuel > 0)
                        RemoveFuel();
                    else
                        _fuelTimer += Time.fixedDeltaTime * 2;
                }
                else
                {
                    if (_fuelTimer + Time.fixedDeltaTime >= _fuelUseTime && _fuel > 0)
                        RemoveFuel();
                    else
                        _fuelTimer += Time.fixedDeltaTime;
                }

            }
        }
    }

    private void RemoveFuel()
    {
        _fuel--;
        if (_fuel < _fuelElements.Count / 2)
            _fuelAudio.Play();

        _fuelTimer = 0f;
        UpdateFuelElements();
    }

    private void RemoveOxygen()
    {

    }

    private void UpdateOxygenElements()
    {
        if (_oxygenElements.Count != 0)
        {
            if (_oxygen <= 0)
                _gameEvents.GameOver("Oxygen ended!");

            for (int i = 0; i < _oxygenElements.Count; i++)
            {
                if (_oxygen > i)
                    _oxygenElements[i].SetActive(true);
                else
                    _oxygenElements[i].SetActive(false);
            }
        }
    }

    private void UpdateFuelElements()
    {
        if (_fuelElements.Count != 0)
        {
            if (_fuel <= 0)
                _gameEvents.GameOver("Fuel ended!");

            for (int i = 0; i < _fuelElements.Count; i++)
            {
                if (_fuel > i)
                    _fuelElements[i].SetActive(true);
                else
                    _fuelElements[i].SetActive(false);
            }
        }
    }

    public void GetQxygenAndFuel()
    {
        _oxygen = _oxygenElements.Count;
        _fuel = _fuelElements.Count;
        _fuelTimer = 0f;
        _oxygenTimer = 0f;

        UpdateOxygenElements();
        UpdateFuelElements();
    }
}