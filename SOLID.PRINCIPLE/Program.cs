using SOLID.PRINCIPLE.Database;
using SOLID.PRINCIPLE.InterfaceSegregationPriciple;
using SOLID.PRINCIPLE.SingleResponsibility.Student;
using SOLID.PRINCIPLE.SingleResponsibility.Teacher;
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
            //StudentFunctions studentFunctions = new StudentFunctions(context);

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

            //Console.WriteLine("Avaliable Voice List");
            //VoiceFunction voiceFunction = new VoiceFunction();
            //List<VoiceEntity> voices = voiceFunction.GetVoiceList();
            //foreach (var voice in voices)
            //{
            //    Console.WriteLine($"{voice.voice_name}\n");
            //}
            //Console.WriteLine("Enter Voice Name");
            //string voiceName = Console.ReadLine();

            //Console.WriteLine("Enter Text You Want to speak");
            //string SpeakText = Console.ReadLine();
            //voiceFunction.Speak(SpeakText, voiceName, true);

            TeacherRepository teacherRepo = new TeacherRepository(context);
            ITeacherInterface<TeacherEntity> _teacherInterface = teacherRepo; 



            TeacherEntity teacherEntity = new TeacherEntity();
            Console.WriteLine("Enter teacher name");
            string tempName = Console.ReadLine();
            teacherEntity.name = tempName;

            _teacherInterface.SaveorUpdate(teacherEntity);
           

            List<TeacherEntity> teacherList = _teacherInterface.Get();

            if (teacherList.Count > 0)
            {
                Console.WriteLine("Teacher List");
                foreach( var teacher in teacherList )
                {
                    Console.WriteLine($"Teacher Id = {teacher.id}");
                    Console.WriteLine($"Teacher Name = {teacher.name}");
                }
            }
            else
            {
                Console.WriteLine("There is no teacher in teacher table");
            }
        }
    }
}
