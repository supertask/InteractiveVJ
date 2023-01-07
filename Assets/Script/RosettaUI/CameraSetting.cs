using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

using Klak.Spout;
using Klak.Motion;
using Unity.Mathematics;
using PrefsGUI;
using PrefsGUI.RosettaUI;
using RosettaUI;

namespace InteractiveVJ
{
    public class CameraSetting : MonoBehaviour, IElementCreator
    {
        [SerializeField] public SpoutSender spoutSender;
        [SerializeField] public Camera captureCamera; 
        [SerializeField] public BrownianMotion brownianPivot; 

        public PrefsString cameraSpoutName = new("Camera Spout Name", "UnityInteractiveVJ");
        public PrefsFloat cameraPositionZ = new("Camera Position Z", -1.25f);
        public PrefsVector3 brownianPosition = new("Brownian position", new Vector3(0.1f, 0.1f, 0.25f));
        public PrefsVector3 brownianRotation = new("Brownian rotation", new Vector3(30f, 100f, 15f));



        void Start()
        {
            spoutSender.spoutName = cameraSpoutName.Get();
            captureCamera.gameObject.transform.localPosition = new Vector3(0f, 0f, cameraPositionZ);
            brownianPivot.positionAmount = new float3(brownianPosition.Get().x, brownianPosition.Get().y, brownianPosition.Get().z);
            brownianPivot.rotationAmount = new float3(brownianRotation.Get().x, brownianRotation.Get().y, brownianRotation.Get().z);
        }

        void Update()
        {
        }

        public Element CreateElement(LabelElement label)
        {
            return UI.Page(
                cameraSpoutName.CreateElement().RegisterValueChangeCallback(() =>
                {
                    spoutSender.spoutName = cameraSpoutName.Get();
                }),
                cameraPositionZ.CreateElement().RegisterValueChangeCallback(() =>
                {
                    captureCamera.gameObject.transform.localPosition = new Vector3(0f, 0f, cameraPositionZ.Get());
                }),
                brownianPosition.CreateElement().RegisterValueChangeCallback(() =>
                {
                    var position = brownianPosition.Get();
                    brownianPivot.positionAmount = new float3(position.x, position.y, position.z);
                }),
                brownianRotation.CreateElement().RegisterValueChangeCallback(() =>
                {
                    var rotation = brownianRotation.Get();
                    brownianPivot.rotationAmount = new float3(rotation.x, rotation.y, rotation.z);
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