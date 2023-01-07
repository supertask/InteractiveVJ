using System;
using System.Collections.Generic;
using PrefsGUI;
using PrefsGUI.RosettaUI;
using RosettaUI;
using UnityEngine;
using UnityEngine.UIElements;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable ConvertToConstant.Local
using Lasp;

namespace InteractiveVJ
{

    public class EffectSetting : MonoBehaviour, IElementCreator
    {
        [SerializeField] public Material scannedMeshMaterial; 
        [SerializeField] public AudioLevelTracker audioHighPass; 
        [SerializeField] public AudioLevelTracker audioMidPass; 
        [SerializeField] public AudioLevelTracker audioLowPass; 

        public enum EffectInputType
        {
            MIDI_BUTTON,
            ROSETTA_UI,
            AUDIO_HIGH,
            AUDIO_MID,
            AUDIO_LOW,
        }

        private PrefsParam<EffectInputType> twistInputType = new ("Twist Input Type", EffectInputType.AUDIO_MID);
        private PrefsFloat twistPercent = new ("Twist Percent", 0f);
        private PrefsFloat twistTimeScale = new ("Twist Time Scale", 8f);
        private PrefsFloat twistWaveAmplitude = new ("Twist Wave Amplitude", 3.5f);
        private PrefsFloat twistRadius = new ("Twist Radius", 0.5f);

        private PrefsParam<EffectInputType> distortion3DInputType = new ("Distortion 3D Input Type", EffectInputType.AUDIO_MID);
        private PrefsFloat distortion3DStrength = new ("Distortion 3D Strength", 0f);
        private PrefsFloat distortion3DTimeScale = new ("Distortion 3D Time Scale", 6f);
        private PrefsVector3 distortion3DUsage3D = new ("Distortion 3D Usage 3D", new Vector3(1f, 1f, 1f));

        private EffectInputType currTwistInputType;
        private EffectInputType currDistortion3DInputType;

        void Start()
        {
           // spoutSender.spoutName = cameraSpoutName.Get();
        }

        void Update()
        {
            UpdateMaterial(twistInputType.Get(), "_TwistPercent", twistPercent.Get());
            UpdateMaterial(distortion3DInputType.Get(), "_Distortion3DStrength", distortion3DStrength.Get());
        }

        void UpdateMaterial(EffectInputType inputType, string shaderKey, float effectUsage)
        {

            if (inputType == EffectInputType.AUDIO_HIGH) {
                scannedMeshMaterial.SetFloat(shaderKey, effectUsage * audioHighPass.normalizedLevel);
            }
            else if (inputType == EffectInputType.AUDIO_MID) {
                scannedMeshMaterial.SetFloat(shaderKey, effectUsage * audioMidPass.normalizedLevel);
            }
            else if (inputType == EffectInputType.AUDIO_LOW) {
                scannedMeshMaterial.SetFloat(shaderKey, effectUsage * audioLowPass.normalizedLevel);
            }
        }

        //const float scrollHeight = 300f;


        public Element CreateElement(LabelElement label)
        {
            return UI.Page(

                UI.Box(
                     UI.Tabs(
                         ("Twist",
                             () => UI.Column(
                                twistInputType.CreateElement().RegisterValueChangeCallback(() =>
                                {
                                    EffectInputType inputType = twistInputType.Get();
                                    if (inputType == EffectInputType.MIDI_BUTTON) {
                                    }
                                }),
                                twistPercent.CreateSlider(-0.3f, 0.3f).RegisterValueChangeCallback(() => { scannedMeshMaterial.SetFloat("_TwistPercent", twistPercent.Get()); }),
                                twistTimeScale.CreateElement().RegisterValueChangeCallback(() => { scannedMeshMaterial.SetFloat("_TwistTimeScale", twistTimeScale.Get()); }),
                                twistWaveAmplitude.CreateElement().RegisterValueChangeCallback(() => { scannedMeshMaterial.SetFloat("_TwistWaveAmplitude", twistWaveAmplitude.Get()); }),
                                twistRadius.CreateElement().RegisterValueChangeCallback(() => { scannedMeshMaterial.SetFloat("_TwistRadius", twistRadius.Get()); })
                            )
                        ),
                        ("Distortion 3D",
                            () => UI.Column(
                               distortion3DInputType.CreateElement().RegisterValueChangeCallback(() =>
                               {
                                   EffectInputType inputType = distortion3DInputType.Get();
                                   if (inputType == EffectInputType.MIDI_BUTTON) {
                                   }
                               }),
                               distortion3DStrength.CreateSlider(0f, 0.1f).RegisterValueChangeCallback(() => { scannedMeshMaterial.SetFloat("_Distortion3DStrength", distortion3DStrength.Get()); }),
                               distortion3DTimeScale.CreateElement().RegisterValueChangeCallback(() => { scannedMeshMaterial.SetFloat("_Distortion3DTimeScale", distortion3DTimeScale.Get()); }),
                               distortion3DUsage3D.CreateElement().RegisterValueChangeCallback(() => { scannedMeshMaterial.SetVector("_Distortion3DUsage3D", distortion3DUsage3D.Get()); })
                           )
                        )
                    )
                )

            );
        }
        /*
        private Element WindowedImage(string label, Func<Texture> getImage, float maxSideSize)
        {
            return UI.Row(
                //UI.DynamicElementIf(() => label != null, () => UI.Label(label)),
                UI.WindowLauncher(
                    label,
                    UI.Window(label,
                        //UI.Image(getImage()).SetWidth(300f).SetHeight(300f)
                        AutoResizableImage(label, getImage, maxSideSize)
                    )
                )
            );
        }

        private Element AutoResizableImage(string label, Func<Texture> getImage, float maxSideSize)
        {
            return UI.Box(
                    UI.DynamicElementOnStatusChanged(getImage, image =>
                    {
                        if (image == null) return UI.Label("No image");
                        float aspect = (float)image.width / image.height;
                        float width = Mathf.Min(maxSideSize, image.width);
                        float height = Mathf.Min(maxSideSize, image.height);
                        width = Mathf.Min(maxSideSize, height * aspect);
                        height = Mathf.Min(maxSideSize, width / aspect);
                        return UI.Image(image).SetWidth(width).SetHeight(height);
                    })
            );
        }
        */




    }
}