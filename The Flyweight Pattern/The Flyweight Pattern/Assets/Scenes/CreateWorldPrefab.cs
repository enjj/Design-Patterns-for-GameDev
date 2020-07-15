using UnityEngine;

public class CreateWorldPrefab : MonoBehaviour{

    public int depth;
    public int width;
    public GameObject cube;

    private void Start() {
        for (int x = 0; x < width; x++) {
            for (int z = 0; z < depth; z++) {
                Vector3 pos = new Vector3(x, Mathf.PerlinNoise(x *0.2f, z * 0.2f) * 3, z);
                GameObject gameObject = Instantiate(cube, pos, Quaternion.identity);
            }
        } 
    }

}

