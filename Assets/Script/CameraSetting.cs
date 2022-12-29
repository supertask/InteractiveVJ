﻿using System;
using System.Collections.Generic;
using PrefsGUI;
using PrefsGUI.RosettaUI;
using RosettaUI;
using UnityEngine;
using UnityEngine.UIElements;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable ConvertToConstant.Local
using Klak.Spout;

namespace InteractiveVJ
{
    public class CameraSetting : MonoBehaviour, IElementCreator
    {
        [SerializeField] public SpoutSender spoutSender; 

        private PrefsString cameraSpoutName = new("Camera Spout Name", "UnityInteractiveVJ");

        void Start()
        {
            spoutSender.spoutName = cameraSpoutName.Get();
        }

        void Update()
        {
        }

        public Element CreateElement(LabelElement label)
        {
            return UI.Page(

                UI.Row(
                    cameraSpoutName.CreateElement().RegisterValueChangeCallback(() =>
                    {
                        spoutSender.spoutName = cameraSpoutName.Get();
                    })
                )
            );
        }
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




    }
}