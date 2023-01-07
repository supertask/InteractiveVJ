using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

using PrefsGUI;
using PrefsGUI.RosettaUI;
using RosettaUI;
using Lasp;
using UnityEngine.VFX;

namespace InteractiveVJ
{

    public class VFXSetting : MonoBehaviour, IElementCreator
    {
        public VisualEffect waveVfx; 

        public PrefsFloat midiTwistPercent = new ("MIDI Twist Percent", 0f);


        void Start()
        {
            waveVfx.SetFloat("_MidiTwistPercent", 0f);
        }

        void Update()
        {
        }


        public Element CreateElement(LabelElement label)
        {
            return UI.Page(

                //UI.Box(
                //    UI.Tabs(
                //        ("Twist",
                //            () => UI.Column(
                //                twistInputType.CreateElement().RegisterValueChangeCallback(() =>
                //                {
                //                    EffectInputType inputType = twistInputType.Get();
                //                    if (inputType == EffectInputType.MIDI_BUTTON) {
                //                    }
                //                }),
                //                twistPercent.CreateSlider(-0.3f, 0.3f).RegisterValueChangeCallback(() => { scannedMeshMaterial.SetFloat("_TwistPercent", twistPercent.Get()); }),
                //                twistTimeScale.CreateElement().RegisterValueChangeCallback(() => { scannedMeshMaterial.SetFloat("_TwistTimeScale", twistTimeScale.Get()); }),
                //                twistWaveAmplitude.CreateElement().RegisterValueChangeCallback(() => { scannedMeshMaterial.SetFloat("_TwistWaveAmplitude", twistWaveAmplitude.Get()); }),
                //                twistRadius.CreateElement().RegisterValueChangeCallback(() => { scannedMeshMaterial.SetFloat("_TwistRadius", twistRadius.Get()); })
                //            )
                //        ),
                //    )
                //)

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