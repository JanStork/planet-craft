using UnityEngine;
public class cameraMove : MonoBehaviour
{
    public float rychlostPohybu = 8f;
    public float zrychleni = 8f;
    public Vector2 minSou�adnice = new Vector2(-13.9f, -11.6f);
    public Vector2 maxSou�adnice = new Vector2(22f, 9.1f);
    void Update()
    {
        float horizont�ln�Input = Input.GetAxis("Horizontal");
        float vertik�ln�Input = Input.GetAxis("Vertical");
        float rychlost = rychlostPohybu;

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            rychlost *= zrychleni;
        }

        Vector3 pohyb = new Vector3(horizont�ln�Input, vertik�ln�Input, 0f) * rychlost * Time.deltaTime;
        Vector3 novaPozice = transform.position + pohyb;

        // Omezen� pohybu na zadan� sou�adnice
        novaPozice.x = Mathf.Clamp(novaPozice.x, minSou�adnice.x, maxSou�adnice.x);
        novaPozice.y = Mathf.Clamp(novaPozice.y, minSou�adnice.y, maxSou�adnice.y);

        transform.position = novaPozice;
    }
}