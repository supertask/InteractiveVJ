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

    public class EnvVFXSetting : MonoBehaviour, IElementCreator
    {
        public VisualEffect warpVFX; 
        public VisualEffect textVFX; 
        public VisualEffect candyVFX; 
        public VisualEffect particleVFX; 
        public VisualEffect petalVFX; 
        public VisualEffect ribbonVFX; 
        public VisualEffect emojiVFX; 
        public VisualEffect eyeballVFX; 

        public PrefsBool enableWarp = new ("Enable Warp", false);
        public PrefsBool enableText = new ("Enable Text", false);
        public PrefsBool enableCandy = new ("Enable Candy", false);
        public PrefsBool enableParticle = new ("Enable Particle", false);
        public PrefsBool enablePetal = new ("Enable Petal", false);
        public PrefsBool enableRibbon = new ("Enable Ribbon", false);
        public PrefsBool enableEmoji = new ("Enable Emoji", false);
        public PrefsBool enableEyeball = new ("Enable Eyeball", false);


        void Start()
        {
            warpVFX.enabled = enableWarp;
            textVFX.enabled = enableText;
            candyVFX.enabled = enableCandy;
            particleVFX.enabled = enableParticle;
            petalVFX.enabled = enablePetal;
            ribbonVFX.enabled = enableRibbon;
            emojiVFX.enabled = enableEmoji;
            eyeballVFX.enabled = enableEyeball;
        }

        public Element CreateElement(LabelElement label)
        {
            return UI.Page(
                UI.Box(
                    UI.Tabs(
                        ("Warp",
                            () => UI.Column(
                                enableWarp.CreateElement().RegisterValueChangeCallback(() => {
                                    warpVFX.enabled = enableWarp;
                                })
                            )
                        ),
                        ("Text",
                            () => UI.Column(
                                enableText.CreateElement().RegisterValueChangeCallback(() => {
                                    textVFX.enabled = enableText;
                                })
                            )
                        ),
                        ("Candy",
                            () => UI.Column(
                                enableCandy.CreateElement().RegisterValueChangeCallback(() => {
                                    candyVFX.enabled = enableCandy;
                                })
                            )
                        ),
                        ("Particle",
                            () => UI.Column(
                                enableParticle.CreateElement().RegisterValueChangeCallback(() => {
                                    particleVFX.enabled = enableParticle;
                                })
                            )
                        ),
                        ("Petal",
                            () => UI.Column(
                                enablePetal.CreateElement().RegisterValueChangeCallback(() => {
                                    petalVFX.enabled = enablePetal;
                                })
                            )
                        ),
                        ("Ribbon",
                            () => UI.Column(
                                enableRibbon.CreateElement().RegisterValueChangeCallback(() => {
                                    ribbonVFX.enabled = enableRibbon;
                                })
                            )
                        ),
                        ("Emoji",
                            () => UI.Column(
                                enableEmoji.CreateElement().RegisterValueChangeCallback(() => {
                                    emojiVFX.enabled = enableEmoji;
                                })
                            )
                        ),
                        ("Eyeball",
                            () => UI.Column(
                                enableEyeball.CreateElement().RegisterValueChangeCallback(() => {
                                    eyeballVFX.enabled = enableEyeball;
                                })
                            )
                        )
                    )
                )
            );
        }


    }
}