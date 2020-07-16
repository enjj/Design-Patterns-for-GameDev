using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject eggPrefab;
    public GameObject medPrefab;
    public Terrain terrain;
    TerrainData terrainData;

    // Start is called before the first frame update
    void Start() {
        terrainData = terrain.terrainData;
        InvokeRepeating("CreateEgg", 1, 0.5f);
        InvokeRepeating("CreateMedKit", 1, 1.0f);
    }

    void CreateEgg() {
        int x = (int)Random.Range(0, terrainData.size.x);
        int z = (int)Random.Range(0, terrainData.size.z);
        Vector3 pos = new Vector3(x, 0, z);
        pos.y = terrain.SampleHeight(pos) + 10;
        GameObject egg = Instantiate(eggPrefab, pos, Quaternion.identity);
    }

    void CreateMedKit() {
        int x = (int)Random.Range(0, terrainData.size.x);
        int z = (int)Random.Range(0, terrainData.size.z);
        Vector3 pos = new Vector3(x, 0, z);
        pos.y = terrain.SampleHeight(pos) + 10;
        GameObject medkit = Instantiate(medPrefab, pos, Quaternion.identity);
    }
}
