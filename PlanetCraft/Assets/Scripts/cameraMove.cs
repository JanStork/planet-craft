using UnityEngine;
public class cameraMove : MonoBehaviour
{
    public float rychlostPohybu = 8f;
    public float zrychleni = 8f;
    public Vector2 minSouøadnice = new Vector2(-13.9f, -11.6f);
    public Vector2 maxSouøadnice = new Vector2(22f, 9.1f);
    void Update()
    {
        float horizontálníInput = Input.GetAxis("Horizontal");
        float vertikálníInput = Input.GetAxis("Vertical");
        float rychlost = rychlostPohybu;

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            rychlost *= zrychleni;
        }

        Vector3 pohyb = new Vector3(horizontálníInput, vertikálníInput, 0f) * rychlost * Time.deltaTime;
        Vector3 novaPozice = transform.position + pohyb;

        // Omezení pohybu na zadané souøadnice
        novaPozice.x = Mathf.Clamp(novaPozice.x, minSouøadnice.x, maxSouøadnice.x);
        novaPozice.y = Mathf.Clamp(novaPozice.y, minSouøadnice.y, maxSouøadnice.y);

        transform.position = novaPozice;
    }
}