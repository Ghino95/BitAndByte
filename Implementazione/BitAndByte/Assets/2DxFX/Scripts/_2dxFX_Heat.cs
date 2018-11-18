﻿//////////////////////////////////////////////
/// 2DxFX - 2D SPRITE FX - by VETASOFT 2015 //
//////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/Heat")]
[System.Serializable]
public class _2dxFX_Heat : MonoBehaviour
{
    [HideInInspector] public Material ForceMaterial;
    [HideInInspector] public bool ActiveChange = true;
    private string shader = "2DxFX/Standard/Heat";
    [HideInInspector] [Range(0, 1)] public float _Alpha = 1f;

    [HideInInspector] [Range(0.0f, 4f)] public float Heat = 1.0f;
    [HideInInspector] [Range(0.0f, 4f)] public float Speed = 1.0f;

    [HideInInspector] public int ShaderChange = 0;
    Material tempMaterial;
    Material defaultMaterial;
    Image CanvasImage;


    void Awake()
    {
        if (this.gameObject.GetComponent<Image>() != null)
        {
            CanvasImage = this.gameObject.GetComponent<Image>();
        }
    }
    void Start()
    {
        ShaderChange = 0;
    }

    public void CallUpdate()
    {
        Update();
    }


    void Update()
    {

        if (this.gameObject.GetComponent<Image>() != null)
        {
            if (CanvasImage == null) CanvasImage = this.gameObject.GetComponent<Image>();
        }
        if ((ShaderChange == 0) && (ForceMaterial != null))
        {
            ShaderChange = 1;
            if (tempMaterial != null) DestroyImmediate(tempMaterial);
            if (this.gameObject.GetComponent<SpriteRenderer>() != null)
            {
                this.GetComponent<Renderer>().sharedMaterial = ForceMaterial;
            }
            else if (this.gameObject.GetComponent<Image>() != null)
            {
                CanvasImage.material = ForceMaterial;
            }
            ForceMaterial.hideFlags = HideFlags.None;
            ForceMaterial.shader = Shader.Find(shader);

        }
        if ((ForceMaterial == null) && (ShaderChange == 1))
        {
            if (tempMaterial != null) DestroyImmediate(tempMaterial);
            tempMaterial = new Material(Shader.Find(shader));
            tempMaterial.hideFlags = HideFlags.None;
            if (this.gameObject.GetComponent<SpriteRenderer>() != null)
            {
                this.GetComponent<Renderer>().sharedMaterial = tempMaterial;
            }
            else if (this.gameObject.GetComponent<Image>() != null)
            {
                CanvasImage.material = tempMaterial;
            }
            ShaderChange = 0;
        }

#if UNITY_EDITOR
        string dfname = "";
        if (this.gameObject.GetComponent<SpriteRenderer>() != null) dfname = this.GetComponent<Renderer>().sharedMaterial.shader.name;
        if (this.gameObject.GetComponent<Image>() != null)
        {
            Image img = this.gameObject.GetComponent<Image>();
            if (img.material == null) dfname = "Sprites/Default";
        }
        if (dfname == "Sprites/Default")
        {
            ForceMaterial.shader = Shader.Find(shader);
            ForceMaterial.hideFlags = HideFlags.None;
            if (this.gameObject.GetComponent<SpriteRenderer>() != null)
            {
                this.GetComponent<Renderer>().sharedMaterial = ForceMaterial;
            }
            else if (this.gameObject.GetComponent<Image>() != null)
            {
                Image img = this.gameObject.GetComponent<Image>();
                if (img.material == null)
                {
                    CanvasImage.material = ForceMaterial;
                }
            }
        }
#endif
        if (ActiveChange)
        {
            if (this.gameObject.GetComponent<SpriteRenderer>() != null)
            {
                this.GetComponent<Renderer>().sharedMaterial.SetFloat("_Alpha", 1 - _Alpha);
                this.GetComponent<Renderer>().sharedMaterial.SetFloat("_Distortion", Heat);
                this.GetComponent<Renderer>().sharedMaterial.SetFloat("_Speed", Speed);
            }
            else if (this.gameObject.GetComponent<Image>() != null)
            {
                CanvasImage.material.SetFloat("_Alpha", 1 - _Alpha);
                CanvasImage.material.SetFloat("_Distortion", Heat);
                CanvasImage.material.SetFloat("_Speed", Speed);
            }

        }

    }

    void OnDestroy()
    {
        if (this.gameObject.GetComponent<Image>() != null)
        {
            if (CanvasImage == null) CanvasImage = this.gameObject.GetComponent<Image>();
        }
        if ((Application.isPlaying == false) && (Application.isEditor == true))
        {

            if (tempMaterial != null) DestroyImmediate(tempMaterial);

            if (gameObject.activeSelf && defaultMaterial != null)
            {
                if (this.gameObject.GetComponent<SpriteRenderer>() != null)
                {
                    this.GetComponent<Renderer>().sharedMaterial = defaultMaterial;
                    this.GetComponent<Renderer>().sharedMaterial.hideFlags = HideFlags.None;
                }
                else if (this.gameObject.GetComponent<Image>() != null)
                {
                    CanvasImage.material = defaultMaterial;
                    CanvasImage.material.hideFlags = HideFlags.None;
                }
            }
        }
    }
    void OnDisable()
    {
        if (this.gameObject.GetComponent<Image>() != null)
        {
            if (CanvasImage == null) CanvasImage = this.gameObject.GetComponent<Image>();
        }
        if (gameObject.activeSelf && defaultMaterial != null)
        {
            if (this.gameObject.GetComponent<SpriteRenderer>() != null)
            {
                this.GetComponent<Renderer>().sharedMaterial = defaultMaterial;
                this.GetComponent<Renderer>().sharedMaterial.hideFlags = HideFlags.None;
            }
            else if (this.gameObject.GetComponent<Image>() != null)
            {
                CanvasImage.material = defaultMaterial;
                CanvasImage.material.hideFlags = HideFlags.None;
            }
        }
    }

    void OnEnable()
    {
        if (this.gameObject.GetComponent<Image>() != null)
        {
            if (CanvasImage == null) CanvasImage = this.gameObject.GetComponent<Image>();
        }
        if (defaultMaterial == null)
        {
            defaultMaterial = new Material(Shader.Find("Sprites/Default"));


        }
        if (ForceMaterial == null)
        {
            ActiveChange = true;
            tempMaterial = new Material(Shader.Find(shader));
            tempMaterial.hideFlags = HideFlags.None;
            if (this.gameObject.GetComponent<SpriteRenderer>() != null)
            {
                this.GetComponent<Renderer>().sharedMaterial = tempMaterial;
            }
            else if (this.gameObject.GetComponent<Image>() != null)
            {
                CanvasImage.material = tempMaterial;
            }
        }
        else
        {
            ForceMaterial.shader = Shader.Find(shader);
            ForceMaterial.hideFlags = HideFlags.None;
            if (this.gameObject.GetComponent<SpriteRenderer>() != null)
            {
                this.GetComponent<Renderer>().sharedMaterial = ForceMaterial;
            }
            else if (this.gameObject.GetComponent<Image>() != null)
            {
                CanvasImage.material = ForceMaterial;
            }
        }

    }
}




#if UNITY_EDITOR
[CustomEditor(typeof(_2dxFX_Heat)), CanEditMultipleObjects]
public class _2dxFX_Heat_Editor : Editor
{
    private SerializedObject m_object;

    public void OnEnable()
    {

        m_object = new SerializedObject(targets);
    }

    public override void OnInspectorGUI()
    {
        m_object.Update();
        DrawDefaultInspector();

        _2dxFX_Heat _2dxScript = (_2dxFX_Heat)target;

        Texture2D icon = Resources.Load("2dxfxinspector-anim") as Texture2D;
        if (icon)
        {
            Rect r;
            float ih = icon.height;
            float iw = icon.width;
            float result = ih / iw;
            float w = Screen.width;
            result = result * w;
            r = GUILayoutUtility.GetRect(ih, result);
            EditorGUI.DrawTextureTransparent(r, icon);
        }

        EditorGUILayout.PropertyField(m_object.FindProperty("ForceMaterial"), new GUIContent("Shared Material", "Use a unique material, reduce drastically the use of draw call"));

        if (_2dxScript.ForceMaterial == null)
        {
            _2dxScript.ActiveChange = true;
        }
        else
        {
            if (GUILayout.Button("Remove Shared Material"))
            {
                _2dxScript.ForceMaterial = null;
                _2dxScript.ShaderChange = 1;
                _2dxScript.ActiveChange = true;
                _2dxScript.CallUpdate();
            }

            EditorGUILayout.PropertyField(m_object.FindProperty("ActiveChange"), new GUIContent("Change Material Property", "Change The Material Property"));
        }

        if (_2dxScript.ActiveChange)
        {

            EditorGUILayout.BeginVertical("Box");

            Texture2D icone = Resources.Load("2dxfx-icon-distortion") as Texture2D;
            EditorGUILayout.PropertyField(m_object.FindProperty("Heat"), new GUIContent("Heat Distortion", icone, "Change the distortion of the heat"));
            icone = Resources.Load("2dxfx-icon-time") as Texture2D;
            EditorGUILayout.PropertyField(m_object.FindProperty("Speed"), new GUIContent("Time Speed", icone, "Change the time speed"));

            EditorGUILayout.BeginVertical("Box");



            icone = Resources.Load("2dxfx-icon-fade") as Texture2D;
            EditorGUILayout.PropertyField(m_object.FindProperty("_Alpha"), new GUIContent("Fading", icone, "Fade from nothing to showing"));

            EditorGUILayout.EndVertical();
            EditorGUILayout.EndVertical();


        }

        m_object.ApplyModifiedProperties();

    }
}
#endif