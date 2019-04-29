using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AnimationSystem : MonoBehaviour {

    [SerializeField]
    Sprite[] m_sprites;

    SpriteRenderer m_sprite_renderer;

	// Use this for initialization
	void Start () {
        StartCoroutine(PlayAnim());
        m_sprite_renderer = GetComponent<SpriteRenderer>();
	}

    IEnumerator PlayAnim()
    {
        int i = 0;
        while(true) {
            yield return new WaitForSeconds(0.5f);
            i++;
            if (i >= 3) {
                i = 0;
            }
            m_sprite_renderer.sprite = m_sprites[i];
        }
    }
}
