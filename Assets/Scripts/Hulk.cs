using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hulk : MonoBehaviour
{
    public int health = 100; // жизни персонажа
    public int damage = 10; // урон по врагу
    public Transform fist;
    public Transform target;
    public float distance;// расстояние на котором сработает удар
    public Slider healthSlider;
    bool isDead;


    Animator anim; // аниматор
	
	void Start ()
    {
        anim = GetComponent<Animator>(); // Получаем аниматор
            healthSlider.value = health;

    }


    public void Attack()
    {
        if (isDead)
            return;
        anim.SetTrigger("Punch");
        if (Vector3.Distance(fist.position, target.position) <= distance)
            DealDamage();
    }
    void DealDamage()
    {
        if (target.GetComponentInChildren<Renderer>().enabled == false)
            return;
        var enemy = target.GetComponent<Hulk>();
        if (enemy != null)
        {
            enemy.health -= damage;
            enemy.healthSlider.value = enemy.health;
            if (enemy.health < 0)
                enemy.Die();
        }
        

        
    }

    public void Die()
    {
        anim.SetBool("Stunned", true);
        isDead = true;
    }
    private void Update()
    {

    }

}
