using UnityEngine;
using System.Collections;

public class MoveTexture : MonoBehaviour
{
    private Material m_CurrentMaterial;
    [SerializeField]
    private float m_SpeedOffset;
    private float m_Offset;

	// Use this for initialization
	void Start ()
    {
        m_CurrentMaterial = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update ()
    {
        m_Offset += 0.001f;
        m_CurrentMaterial.SetTextureOffset("_MainTex", new Vector2(m_Offset*m_SpeedOffset*Time.deltaTime, 0));
	}
}
