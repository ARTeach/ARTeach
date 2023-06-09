using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Savoll : MonoBehaviour
{

    public TextAsset assetSavoll;

    private string[] Savoll;

    private string[,] savollBag;


    int indexSavoll;
    int maxSavoll;
    bool ambilSavoll;
    char kalitJ;

    public Text txtSavoll, txtVarA, txtVarB, txtVarC, txtVarD;

    bool isNatija;
    private float davomiyligi;
    public float davomiyligiBaxolash;

    int jvbTogri, jvbXato;
    float qiymat;

    public GameObject panel;
    public GameObject imgPeortachaan, imgNatija;
    public Text txtNatija;

    // Start is called before the first frame update
    void Start()
    {
        davomiyligi = davomiyligiPeortachaan;

        savoll = assetSavoll.ToString().Split('#');

        savollBag = new string[savoll.Length, 6];
        maxSavoll = savoll.Length;
        OlahSavoll();

        ambilSavoll = true;
        TampilkanSavoll();

        print(savollBag[1, 3]);

    }

    private void OlahSavoll()
    {
        for (int i = 0; i < savoll.Length; i++)
        {
            string[] tempSavoll = savoll[i].Split('+');
            for (int j = 0; j < tempSavoll.Length; j++)
            {
                savollBag[i, j] = tempSavoll[j];
                continue;
            }
            continue;
        }
    }

    private void TampilkanSavoll()
    {
        if (indexSavoll < maxSavoll)
        {
            if (ambilSavoll)
            {
                txtSavoll.text = savollBag[indexSavoll, 0];
                txtVarA.text = savollBag[indexSavoll, 1];
                txtVarB.text = savollBag[indexSavoll, 2];
                txtVarC.text = savollBag[indexSavoll, 3];
                txtVarD.text = savollBag[indexSavoll, 4];
                kunciJ = savollBag[indexSavoll, 5][0];

                ambilSavoll = false;
            }
        }
    }


    public void Var(string varHuruf)
    {
        CheckJavob(varHuruf[0]);

        if (indexSavoll == maxSavoll - 1)
        {
            isJavob = true;
        }
        else
        {
            indexSavoll++;
            ambilSavoll = true;
        }

        panel.SetActive(true);
    }

    private float HitungOrtacha()
    {
        return ortacha = (float)jvbTogri / maxSavoll * 100;
    }

    public GameObject TogriObj;
    public GameObject NotogriObj;
    private void CheckJavob(char huruf)
    {
        if (huruf.Equals(kunciJ))
        {
            TogriObj.SetActive(true);
            NotogriObj.SetActive(false);
            jvbTogri++;
        }
        else
        {
            NotogriObj.SetActive(true);
            TogriObj.SetActive(false);
            jvbNotogri++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (panel.activeSelf)
        {
            davomiyligiPeortachaan -= Time.deltaTime;

            if (isJavob)
            {
                imgPeortachaan.SetActive(true);
                imgJavob.SetActive(false);

                if (davomiyligiPeortachaan <= 0)
                {
                    txtJavob.text = "Soni togri : " + jvbTogri + "\nSoni Notogri : " + jvbNotogri + "\n\nOrtacha : " + HitungOrtacha();

                    imgPeortachaan.SetActive(false);
                    imgJavob.SetActive(true);

                    davomiyligiPeortachaan = 0;

                }
            }
            else
            {
                imgPeortachaan.SetActive(true);
                imgJavob.SetActive(false);

                if (davomiyligiPeortachaan <= 0)
                {
                    panel.SetActive(false);
                    davomiyligiPeortachaan = davomiyligi;

                    TampilkanSavoll();
                }
            }
        }


    }
}

