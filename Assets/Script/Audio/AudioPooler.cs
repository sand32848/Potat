using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using static AudioManager;

public class AudioPooler : SingletonClass<AudioPooler>
{
    [SerializeField] private AudioPool[] _pools;
    [SerializeField] private Dictionary<string, AudioPool> _poolDictionary;

    private void Awake()
    {
        SingletonClassCallOnAwake();

        List<GameObject> createdPool = new List<GameObject>();
        _poolDictionary = new Dictionary<string, AudioPool>();

        if (_pools == null) throw new Exception("_pools is empty");

        foreach (AudioPool pool in _pools)
        {
            createdPool.Clear();

            // Pool create
            pool.pool = new ObjectPool<GameObject>
                (createFunc: () =>
                {
                    return Instantiate(pool.prefab);

                }, actionOnGet: objects =>
                {
                    objects.transform.SetParent(null);
                    if (objects.TryGetComponent(out PoolAudio pl))
                    {
                        pl.soundType = pool.soundType;
                    }
                    objects.SetActive(true);

                }, actionOnRelease: objects =>
                {
                    objects.SetActive(false);
                    objects.transform.SetParent(this.transform);

                }, actionOnDestroy: objects =>
                {
                    Destroy(objects);
                }, collectionCheck: false, defaultCapacity: pool.defaultCapacity, maxSize: pool.maxCapacity);

            // Dictionary Setup
            _poolDictionary.Add(pool.soundType.ToString(), pool);


            // Pool's objects Setup
            for (int i = 0; i < pool.initialObject; i++)    // Create a new default pool
            {
                GameObject objectToSpawn = StartSpawnFromPool(pool.soundType, Vector3.zero, Quaternion.identity);
                createdPool.Add(objectToSpawn);

            }

            for (int i = 0; i < createdPool.Count; i++) // Releash item to pool
            {
                returnObject(pool.soundType, createdPool[i]);
            }

        }
    }
    private GameObject StartSpawnFromPool(AudioManager.SoundType soundType, Vector3 position, Quaternion rotation)
    {
        if (!_poolDictionary.ContainsKey(soundType.ToString()))
        {
            throw new Exception("There is no " + soundType.ToString() + " tag in the pooling system to spawn.");
        }

        GameObject objectToSpawn = _poolDictionary[soundType.ToString()].pool.Get();


        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        return objectToSpawn;
    }
    public GameObject SpawnFromPool(AudioClip audioClip, AudioSettingClass audioUISettings, Vector3 position, Quaternion rotation)
    {
        if (!_poolDictionary.ContainsKey(audioUISettings.soundType.ToString()))
        {
            throw new Exception("There is no " + audioUISettings.soundType.ToString() + " tag in the pooling system to spawn.");
        }

        GameObject objectToSpawn = _poolDictionary[audioUISettings.soundType.ToString()].pool.Get();

        if (objectToSpawn.TryGetComponent(out AudioSource audioSource))
        {
            audioUISettings.SetAudioSetting(audioSource);
            audioSource.clip = audioClip;
            //audioSource.clip = GameAsset.Instance.FindClip(audioClipString);
            audioSource.Play();
        }

        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        return objectToSpawn;
    }
    public GameObject SpawnPoolIntoParent(AudioClip audioClip, AudioSettingClass audioUISettings, Transform _objectTransform, Quaternion rotation)
    {
        if (!_poolDictionary.ContainsKey(audioUISettings.soundType.ToString()))
        {
            throw new Exception("There is no " + audioUISettings.soundType.ToString() + " tag in the pooling system to spawn.");
        }

        GameObject objectToSpawn = _poolDictionary[audioUISettings.soundType.ToString()].pool.Get();

        if (objectToSpawn.TryGetComponent(out AudioSource audioSource))
        {
            audioUISettings.SetAudioSetting(audioSource);
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        objectToSpawn.transform.SetParent(_objectTransform);
        objectToSpawn.transform.position = _objectTransform.position;
        objectToSpawn.transform.rotation = rotation;

        return objectToSpawn;
    }
    public void returnObject(AudioManager.SoundType soundType, GameObject returnObejct)
    {
        if (!_poolDictionary.ContainsKey(soundType.ToString()))
        {
            throw new Exception("There is no " + soundType.ToString() + " tag in the pooling system to return object.");
        }

        _poolDictionary[soundType.ToString()].pool.Release(returnObejct);
    }
}

[System.Serializable]
public class AudioPool
{
    [SerializeField] private AudioManager.SoundType _soundType = AudioManager.SoundType.MASTER_MAIN;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _defaultCapacity;
    [SerializeField] private int _maxCapacity;
    [SerializeField] private int _initialObject;
    public ObjectPool<GameObject> pool;

    public AudioManager.SoundType soundType => _soundType;
    public GameObject prefab => _prefab;
    // Default pool size: initial size of the stack/list that will contain your elements
    public int defaultCapacity => _defaultCapacity;
    // Pool size: maximum number of free items that are in the pool at any given time.
    // If you return an item to a pool that is full, this item will be destroyed instead.
    public int maxCapacity => _maxCapacity;
    public int initialObject => _initialObject;
}

