using System;
using System.Collections.Generic;

namespace Lab6
{
    class Program
    {
        class Doctor
        {
            public string full_name;
            public string specialization;
            public int work_from;  // початок робочого дня
            public int work_untill; // кінець робочого дня
            public Doctor(string full_name, string specialization, int work_from, int work_untill)
            {
                this.full_name = full_name;
                this.specialization = specialization;
                this.work_from = work_from;
                this.work_untill = work_untill;

            }
            public override string ToString()
            {
                return $"{full_name},\nSpecialization: {specialization}";
            }
            public Doctor Clone()
            {
                return this.MemberwiseClone() as Doctor;
            }
        }

        class Person
        {
            public string full_name;
            public DateTime date_of_birth;
            public string gender;
            public Person(string full_name, DateTime date_of_birth, string gender)
            {
                this.full_name = full_name;
                this.date_of_birth = date_of_birth;
                this.gender = gender; 
            }
            public override string ToString()
            {
                return $"{full_name},\nDate of birth: {date_of_birth},\nGender: {gender}";
            }
            public Person Clone()
            {
                return this.MemberwiseClone() as Person;
            }
        }

        class MedicalRecord
        {
            public Person patient;
            public Doctor doctor;
            public string disease_info;
            public DateTime date_of_visit;
            public MedicalRecord(Person patient, Doctor doctor, string disease_info, DateTime date_of_visit)
            {
                this.patient = patient;
                this.doctor = doctor;
                this.disease_info = disease_info;
                this.date_of_visit = date_of_visit;
            }
            public override string ToString()
            {
                return $"Patient: {patient}\nDoctor: {doctor}\nDisease info: {disease_info}\nDate of visit: {date_of_visit}";
            }
            public MedicalRecord Clone()
            {
                MedicalRecord clone = this.MemberwiseClone() as MedicalRecord;
                clone.patient = this.patient.Clone() as Person;
                clone.doctor = this.doctor.Clone() as Doctor;
                return clone;
            }
        }
        class PatientsMedicalCard
        {
            public Person patient;
            public List<MedicalRecord> disease_records; // список записів в мед книжці пацієнта
            public PatientsMedicalCard(Person patient)
            {
                this.patient = patient;
                this.disease_records = new List<MedicalRecord>();
            }
            public void addMedicalRecord(MedicalRecord record) // додавання запису в мед книжку пацієнта
            {
                this.disease_records.Add(record);
            }
            public void displayRecords()
            {
                for (int i = 0; i < this.disease_records.Count; i++)
                {
                    Console.WriteLine($"{this.disease_records[i]}\n");
                }
            }

        }


        static void Main(string[] args)
        {
            /* Передбачити можливість внести запис до медичної книги пацієнта, скопіювати інший запис в  книзі */

            var d1 = new Doctor("Test Doctor 1", "Therapist", 8, 17);
            var p1 = new Person("Test Patient 1", new DateTime(1995, 6, 24), "Male");
            var r1 = new MedicalRecord(p1, d1, "Loss of taste and smell, headache, tiredness. Diagnosis - coronavirus", new DateTime(2018, 10, 23));
            var r2 = r1.Clone();
            r2.disease_info = "Fever, sore throat, runny nose. Diagnosis - flu";
            r2.date_of_visit = new DateTime(2021, 11, 26);

            var medical_card1 = new PatientsMedicalCard(p1);
            medical_card1.addMedicalRecord(r1);
            medical_card1.addMedicalRecord(r2);

            medical_card1.displayRecords();
        }
    }
}
