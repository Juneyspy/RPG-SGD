using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
namespace QuantumTek.EncryptedSave
{
    /// <summary> Shows how to use Encrypted Save. </summary>
    public class ES_Demo : MonoBehaviour
    {
        public InputField text;
        public Slider knobX;
        public Slider knobY;
        public RectTransform knob;

        //variables below this line are place holders, thhey should be put into the dont destory as public variables which will...
        //...get called in the save function for saving 

        public string bosses;
        public TextMeshProUGUI healthhodl;
        public int Health;
        public string SceneName;
        public GameObject player;

        public GameObject inv;
        public GameObject TotalInv;





        void Start()
        {
            Health = player.GetComponent<PlayerScript>().playerHP;
            healthhodl.text = Health.ToString();
            SceneName = SceneManager.GetActiveScene().name;
        }

        public void healthup()
        {
            Health++;
            healthhodl.text = Health.ToString();

        }

        public void healthdown()
        {
            Health--;
            healthhodl.text = Health.ToString();

        }


        public void SetKnobPos()
        {
            if (!knob || !knobX || !knobY) return;
            // Set knob position based on sliders
            knob.anchoredPosition = new Vector2(knobX.value, knobY.value);
        }

        public void Save()
        {
            if (!text || !knob) return;
            // Saves the value of the text component.
            ES_Save.Save(SceneName, "Scene name");
            ES_Save.Save(text.text, "test string");
            ES_Save.SaveTransform(transform, "test transform");
            ES_Save.SaveRectTransform(knob, "test rect transform");
            ES_Save.Save(knobX.value, "test x");
            ES_Save.Save(knobY.value, "test y");
            //ES_Save.Save(Health.int, "test int");
            ES_Save.Save(Health, "test num");
        }

        public void Load()
        {
            if (!text || !knob || !knobX || !knobY) return;
            // Loads the saved value of the text component.
            text.text = ES_Save.Load<string>("test string");
            SceneName = ES_Save.Load<string>("Scene name");
            // Requests to load the saved transform data, which will load on the next LateUpdate call to the ES_Save GameObject, if there is one. Otherwise nothing will happen.
            ES_Save.LoadTransform(transform, "test transform");
            ES_Save.LoadRectTransform(knob, "test rect transform");
            knobX.value = ES_Save.Load<float>("test x");
            knobY.value = ES_Save.Load<float>("test y");
            //Health.int = ES_Save.Load<float>("test int");
            Health = ES_Save.Load<int>("test num");
        }
    }
}