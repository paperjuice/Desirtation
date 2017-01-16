using UnityEngine;
using UnityEngine.UI;

public class mcStats : MonoBehaviour {

    private debuff mcDebuff;
    private consumablePotency _cp;
    private mcWeaponCollision _mcWeapon;

    [SerializeField] ParticleSystem blood;
    [Header("Mc Dead Body ")]
    [SerializeField] GameObject deadBody;

    [Header("Stats text")]
    [SerializeField] TextMesh textKnowledge;
    [SerializeField] TextMesh textYouthfulness;
    [SerializeField] TextMesh textFortitude;
    [SerializeField] TextMesh textWisdom;
    [SerializeField] TextMesh textHealth;
    [SerializeField] TextMesh textSpirit;
    [SerializeField] TextMesh textDamage;
    [SerializeField] TextMesh textArmour;
    [SerializeField] TextMesh textCriticalChance;
    [SerializeField] TextMesh textLuck;

    
    //knowledge
    // [SerializeField] GameObject textKnowledge;
    public static float knowledge = 0f;

    //age
    private float age=0;
    public float Age{
        get{return age;}
        set{age = value;}
    }
    private float agingPerSecond;
    private GameObject guiAge;
    private Text textAge;

    //health
    private GameObject guiHealth; 
    private float currentHealth=50f;
    public  float CurrentHealth{
        get{return currentHealth;}
        set{currentHealth = value;}
    }
    private float maxHealth;
    public float MaxHealth{
        get{return maxHealth;}
        set{maxHealth = value;}
    }

    //Spirit
    private GameObject guiSpirit;
    private float currentSpirit=20f;
    private float maxSpirit;

    
    //youthfulness
    private float youthfulness;
    private float bonusYouthfulness;
    public float BonusYouthfulness
    {
        get{return bonusYouthfulness;}
        set{bonusYouthfulness=value;}
    }

    //fortitude
    private float fortitude;
    private float bonusFortitude;
    public float BonusFortitude
    {
        get{return bonusFortitude;}
        set{bonusFortitude=value;}
    }

    //wisdom
    private float wisdom;
    private float bonusWisdom;
    public float BonusWisdom
    {
        get{return bonusWisdom;}
        set{bonusWisdom =value;}
    }

    //luck
    private float luck;

    //damage
    private float mcDamage;

    //armour
    private float damageProcessedBasedOnArmour;


    //critChance
    private float damageIfCrited;
    
    



    void Awake()
    {
        guiAge = GameObject.FindGameObjectWithTag("ageFill");
        textAge = GameObject.FindGameObjectWithTag("ageText").GetComponent<Text>();
        guiSpirit = GameObject.FindGameObjectWithTag("spiritFill");
        mcDebuff = GetComponent<debuff>();
        _cp = GetComponent<consumablePotency>();
        _mcWeapon = GameObject.FindGameObjectWithTag("mcWeapon").GetComponent<mcWeaponCollision>();
    }

    
    void Update()
    {
       // Death();
        GUI();
        AgePerSecond();
    }


    private void AgePerSecond()
    {
        Age = Mathf.Clamp(Age,0f,float.MaxValue);
        Age += Time.deltaTime * 0.001f;
    }

    public void IncrementAgeOnDamageReceived(float damageReceived)
    {
        if(damageReceived>0)
        {
            Age += Armour(damageReceived);
            damageReceived = 0f;
            blood.Play();
            Death();
        }
    }

    public void Knowledge(float knowledgeGain)
    {
        if (knowledgeGain > 0f)
        {
            knowledge += knowledgeGain;
            knowledgeGain = 0f;
        }
    }

    public float Youthfulness()
    {
        youthfulness = (knowledge+1) * (1 + (age / 2.5f) / (1 + age))+BonusYouthfulness;
        return youthfulness;
    }

    public float Fortitude()
    {
        if (age <= 17)
            fortitude = knowledge * ((age+1) / 17)*0.1f + BonusFortitude;
        else
            fortitude = knowledge * (17 / age) * 0.1f+ BonusFortitude;
        
        return fortitude;
    }

    public float Wisdom()
    {
        wisdom = knowledge * (1+age * 0.03f) + BonusWisdom;
        return wisdom;
    }

    public float Spirit(float decreasAmount)
    {
        if (decreasAmount > 0)
        {
            currentSpirit -= decreasAmount;
            decreasAmount = 0f;
        }

        maxSpirit = 20 + Youthfulness()*0.1f;
        currentSpirit = Mathf.Clamp(currentSpirit, 0f, maxSpirit);

        if (currentSpirit < maxSpirit)
            currentSpirit += Time.deltaTime*1.4f;
        
        return currentSpirit;
    }

    public float Luck()
    {
        luck = (Youthfulness() / Youthfulness() + 10f) * 10f*0f; //needs modification
        return luck;
    }

    public float McDamage(float weaponDamage)
    {
        mcDamage = Fortitude() + weaponDamage;;
       // print(mcDamage);
        return mcDamage;
    }

    //keep an eye on wisdom multiplier
    public float Armour(float damageReceived)
    {
        damageProcessedBasedOnArmour = damageReceived - (damageReceived * (_cp.ArmourLevel / (100f+_cp.ArmourLevel))*100f)* Wisdom();
        return damageProcessedBasedOnArmour;
    }

    //keep an eye on wisdom multiplier
    public float CritChance(float damageDealt)
    {
        float chanceToCrit = Random.Range(1f, 100f);
        if (chanceToCrit <= _cp.CritChanceLevel * (Wisdom()/10f))
            damageDealt = damageDealt * Random.Range(1.4f,2f);
        return damageDealt;
    }

    void Death()
    {
        float deathChance = 0f;
        if (Age>=62)
        {
            deathChance = Random.Range(1f,100f);
            if(deathChance<= Age / (1.5f +Age/41f))
            {
                deadBody.transform.parent = null;
                deadBody.gameObject.SetActive(true);
                gameObject.SetActive(false);
            }
        }

    }

    void GUI()
    {
        guiAge.transform.localScale = new Vector3(Mathf.Clamp(Age / 100f,0f,1f), 1f, 1f);
        guiAge.GetComponent<Image>().color = Color.Lerp(new Color32(128, 174,159, 255), Color.red, (Age/100f));
        textAge.text = "Age: " + (18f +Age).ToString("N1");

        guiSpirit.transform.localScale = new Vector3(Spirit(0) / maxSpirit, 1f, 1f);


      /*  textKnowledge.text = "Knowledge: " + knowledge.ToString("N1");
        textYouthfulness.text = "Youthfulness: " + Youthfulness().ToString("N1");
        textFortitude.text = "Fortitude: " + Fortitude().ToString("N1");
        textWisdom.text = "Wisdom: " + Wisdom().ToString("N1");
        textHealth.text = "Health: " + Health(0).ToString("N1") + "/" + maxHealth.ToString("N1");
        textSpirit.text = "Spirit: " + Spirit(0).ToString("N1") + "/" + maxSpirit.ToString("N1");
        textDamage.text = "Damage: " + McDamage(_mcWeapon.DamageWeapon).ToString("N1");
        textArmour.text = "Damage Reduction: " + ((_cp.ArmourLevel / (100f + _cp.ArmourLevel)) * 100f*Wisdom()).ToString("N1");
        textCriticalChance.text = "Critical Chance: " + CritChance(0).ToString("N1");
        textLuck.text = "Luck: " + Luck();
        textAge.text = "Age: " + (18f+age).ToString("N1");*/








    }







}
