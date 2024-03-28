using SOLID.PRINCIPLE.Database;
using SOLID.PRINCIPLE.SingleResponsibility.Student;
using SOLID.PRINCIPLE.SingleResponsibility.Voice;
using System;
using System.Collections.Generic;
using System.Speech.Synthesis;

namespace SOLID.PRINCIPLE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DatabaseContext context = new DatabaseContext();
            StudentFunctions studentFunctions = new StudentFunctions(context);

            //Create new Student
            //StudentEntity student = new StudentEntity();
            //Console.WriteLine("Enter Student Name");
            //string name = Console.ReadLine();
            //student.name = name;
            //studentFunctions.Save(student);

            ////liskov substitution test
            //StudentEntity studentEntity = new StudentEntity();
            //studentEntity.id = 5;
            //Console.WriteLine(studentEntity.getId());

            //studentFunctions.GetAll();
            
            Console.WriteLine("Avaliable Voice List");
            VoiceFunction voiceFunction = new VoiceFunction();
            List<VoiceEntity> voices = voiceFunction.GetVoiceList();
            foreach (var voice in voices)
            {
                Console.WriteLine($"{voice.voice_name}\n");
            }
            Console.WriteLine("Enter Voice Name");
            string voiceName = Console.ReadLine();

            Console.WriteLine("Enter Text You Want to speak");
            string SpeakText = Console.ReadLine();

            voiceFunction.Speak(SpeakText,voiceName);
        }
    }
}
