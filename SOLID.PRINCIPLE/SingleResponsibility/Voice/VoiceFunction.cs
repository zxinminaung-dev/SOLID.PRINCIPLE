using System;
using System.Collections.Generic;
using System.Speech.Synthesis;
using System.Text;

namespace SOLID.PRINCIPLE.SingleResponsibility.Voice
{
    internal class VoiceFunction
    {
        public List<VoiceEntity> GetVoiceList()
        {
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            List<VoiceEntity> voiceList = new List<VoiceEntity>();
            foreach (var voice in synthesizer.GetInstalledVoices())
            {
                VoiceEntity model = new VoiceEntity();  
                var info = voice.VoiceInfo;
                model.voice_name = info.Name;
                model.voice_culture = info.Culture.ToString();
                model.voice_gender = info.Gender.ToString();
                voiceList.Add(model);
                //Console.WriteLine($"Name: {info.Name}, Culture: {info.Culture}, Gender: {info.Gender}");
            }
            return voiceList;
        }
        public void Speak(string text, string speakerName)
        {
            // Create a SpeechSynthesizer instance
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();            
            Console.WriteLine("ready ...........");
            synthesizer.SelectVoice(speakerName);
            synthesizer.Speak(text);
            Console.WriteLine("Finish");
            synthesizer.Dispose();
        }
    }
}
