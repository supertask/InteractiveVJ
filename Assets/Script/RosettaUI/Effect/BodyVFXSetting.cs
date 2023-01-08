using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

using PrefsGUI;
using PrefsGUI.RosettaUI;
using RosettaUI;
using Lasp;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

namespace InteractiveVJ
{

    public class BodyVFXSetting : MonoBehaviour, IElementCreator
    {
        public VisualEffect hologramVFX; 
        public VisualEffect webVFX; 
        public VisualEffect spikesVFX; 
        public VisualEffect sparkVFX; 
        public VisualEffect leavesVFX; 
        public VisualEffect particlesVFX; 
        public VisualEffect linesVFX; 
        public VisualEffect trailsVFX; 

        public PrefsBool enableHologram = new ("Enable Hologram", false);
        public PrefsBool enableWeb = new ("Enable Web", false);
        public PrefsBool enableSpikes = new ("Enable Spikes", false);
        public PrefsBool enableSpark = new ("Enable Spark", false);
        public PrefsBool enableLeaves = new ("Enable Leaves", false);
        public PrefsBool enableParticles = new ("Enable Particles", false);
        public PrefsBool enableLines = new ("Enable Lines", false);
        public PrefsBool enableTrails = new ("Enable Trails", false);

        private VFXPropertyBinder hologramVFXBinder;
        private VFXPropertyBinder webVFXBinder;
        private VFXPropertyBinder spikesVFXBinder;
        private VFXPropertyBinder sparkVFXBinder;
        private VFXPropertyBinder leavesVFXBinder;
        private VFXPropertyBinder particlesVFXBinder;
        private VFXPropertyBinder linesVFXBinder;
        private VFXPropertyBinder trailsVFXBinder;

        void Start()
        {
            hologramVFX.enabled = enableHologram;
            hologramVFXBinder = hologramVFX.GetComponent<VFXPropertyBinder>();
            hologramVFXBinder.enabled = enableHologram;
            
            webVFX.enabled = enableWeb;
            webVFXBinder = webVFX.GetComponent<VFXPropertyBinder>();
            webVFXBinder.enabled = enableWeb;

            spikesVFX.enabled = enableSpikes;
            spikesVFXBinder = spikesVFX.GetComponent<VFXPropertyBinder>();
            spikesVFXBinder.enabled = enableSpikes;

            sparkVFX.enabled = enableSpark;
            sparkVFXBinder = sparkVFX.GetComponent<VFXPropertyBinder>();
            sparkVFXBinder.enabled = enableSpark;

            leavesVFX.enabled = enableLeaves;
            leavesVFXBinder = leavesVFX.GetComponent<VFXPropertyBinder>();
            leavesVFXBinder.enabled = enableLeaves;
            
            particlesVFX.enabled = enableParticles;
            particlesVFXBinder = particlesVFX.GetComponent<VFXPropertyBinder>();
            particlesVFXBinder.enabled = enableParticles;

            linesVFX.enabled = enableLines;
            linesVFXBinder = linesVFX.GetComponent<VFXPropertyBinder>();
            linesVFXBinder.enabled = enableLines;

            trailsVFX.enabled = enableTrails;
            trailsVFXBinder = trailsVFX.GetComponent<VFXPropertyBinder>();
            trailsVFXBinder.enabled = enableTrails;
        }

        public Element CreateElement(LabelElement label)
        {
            return UI.Page(

                UI.Box(
                    UI.Tabs(
                        ("Hologram",
                            () => UI.Column(
                                enableHologram.CreateElement().RegisterValueChangeCallback(() => {
                                    hologramVFX.enabled = enableHologram;
                                    hologramVFXBinder.enabled = enableHologram;
                                })
                            )
                        ),
                        ("Web",
                            () => UI.Column(
                                enableWeb.CreateElement().RegisterValueChangeCallback(() => {
                                    webVFX.enabled = enableWeb;
                                    webVFXBinder.enabled = enableWeb;
                                })
                            )
                        ),
                        ("Spikes",
                            () => UI.Column(
                                enableSpikes.CreateElement().RegisterValueChangeCallback(() => {
                                    spikesVFX.enabled = enableSpikes;
                                    spikesVFXBinder.enabled = enableSpikes;
                                })
                            )
                        ),
                        ("Spark",
                            () => UI.Column(
                                enableSpark.CreateElement().RegisterValueChangeCallback(() => {
                                    sparkVFX.enabled = enableSpark;
                                    sparkVFXBinder.enabled = enableSpark;
                                })
                            )
                        ),
                        ("Leaves",
                            () => UI.Column(
                                enableLeaves.CreateElement().RegisterValueChangeCallback(() => {
                                    leavesVFX.enabled = enableLeaves;
                                    leavesVFXBinder.enabled = enableLeaves;
                                })
                            )
                        ),
                        ("Particles",
                            () => UI.Column(
                                enableParticles.CreateElement().RegisterValueChangeCallback(() => {
                                    particlesVFX.enabled = enableParticles;
                                    particlesVFXBinder.enabled = enableParticles;
                                })
                            )
                        ),
                        ("Lines",
                            () => UI.Column(
                                enableLines.CreateElement().RegisterValueChangeCallback(() => {
                                    linesVFX.enabled = enableLines;
                                    linesVFXBinder.enabled = enableLines;
                                })
                            )
                        ),
                        ("Trails",
                            () => UI.Column(
                                enableTrails.CreateElement().RegisterValueChangeCallback(() => {
                                    trailsVFX.enabled = enableTrails;
                                    trailsVFXBinder.enabled = enableTrails;
                                })
                            )
                        )
                    )
                )

            );
        }


    }
}