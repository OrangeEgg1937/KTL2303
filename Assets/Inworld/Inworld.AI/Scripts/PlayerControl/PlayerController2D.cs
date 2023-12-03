/*************************************************************************************************
 * Copyright 2022 Theai, Inc. (DBA Inworld)
 *
 * Use of this source code is governed by the Inworld.ai Software Development Kit License Agreement
 * that can be found in the LICENSE.md file or at https://www.inworld.ai/sdk-license
 *************************************************************************************************/


using Inworld.Entities;

namespace Inworld.Sample
{
    public class PlayerController2D : PlayerController
    {
        public void InitialMurderEvent()
        {
            InworldCharacter currentSelected = InworldController.CurrentCharacter;
            print(currentSelected.ID);
            if (InworldController.CurrentCharacter)
                InworldController.CurrentCharacter.SendText("You feel that now have a chance to take Alex life.");
        }

        protected override void Start()
        {
            if (m_PushToTalk)
            {
                InworldController.CharacterHandler.ManualAudioHandling = true;
                InworldController.Audio.AutoPush = false;
            }
        }
        
        protected override void OnEnable()
        {
            base.OnEnable();
            InworldController.CharacterHandler.OnCharacterRegistered += OnCharacterRegistered;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            if (!InworldController.Instance)
                return;
            InworldController.CharacterHandler.OnCharacterRegistered -= OnCharacterRegistered;
        }
        
        protected virtual void OnCharacterRegistered(InworldCharacterData charData)
        {
            
        }
    }
}

