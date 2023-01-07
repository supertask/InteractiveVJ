using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

using Lasp;
using PrefsGUI;
using PrefsGUI.RosettaUI;
using RosettaUI;

namespace InteractiveVJ
{
    public class AudioInputSetting : MonoBehaviour, IElementCreator
    {
        [SerializeField] public SpectrumAnalyzer spectrumAnalyzer;
        [SerializeField] public AudioLevelTracker highPassTracker;
        [SerializeField] public AudioLevelTracker midPassTracker;
        [SerializeField] public AudioLevelTracker lowPassTracker;

        public PrefsFloat spectrumDynamicRangeDB = new("Spectrum dynamic range (dB)", 60f);
        public PrefsFloat highPassDynamicRangeDB = new("High pass dynamic range (dB)", 40f);
        public PrefsFloat midPassDynamicRangeDB = new("Mid pass dynamic range (dB)", 40f);
        public PrefsFloat lowPassDynamicRangeDB = new("Low pass dynamic range (dB)", 40f);


        void Start()
        {
            spectrumAnalyzer.dynamicRange = spectrumDynamicRangeDB.Get();
            highPassTracker.dynamicRange = highPassDynamicRangeDB.Get();
            midPassTracker.dynamicRange = midPassDynamicRangeDB.Get();
            lowPassTracker.dynamicRange = lowPassDynamicRangeDB.Get();
        }

        void Update()
        {
        }

        public Element CreateElement(LabelElement label)
        {
            return UI.Page(
                spectrumDynamicRangeDB.CreateElement().RegisterValueChangeCallback(() =>
                {
                    spectrumAnalyzer.dynamicRange = spectrumDynamicRangeDB.Get();
                }),
                highPassDynamicRangeDB.CreateElement().RegisterValueChangeCallback(() =>
                {
                    highPassTracker.dynamicRange = highPassDynamicRangeDB.Get();
                }),
                midPassDynamicRangeDB.CreateElement().RegisterValueChangeCallback(() =>
                {
                    midPassTracker.dynamicRange = midPassDynamicRangeDB.Get();
                }),
                lowPassDynamicRangeDB.CreateElement().RegisterValueChangeCallback(() =>
                {
                    lowPassTracker.dynamicRange = lowPassDynamicRangeDB.Get();
                })
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