using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Obalon.Models
{
    public class PatientModel
    {
        #region Properties
        public int Id { get; set; }
        public string Gender { get; set; }
        public int HeightFt { get; set; }
        public int HeightIn { get; set; }
        public int Age { get; set; }
        public int LastSeen { get; set; }
        public int WeightLoss { get; set; }
        public int BMIChange { get; set; }
        public int TotalBodyLoss { get; set; }
        public int Status { get; set; }

        #endregion

        public string DisplayStatus
        {
            get
            {
                switch (Status)
                {
                    case 1: return "1st Balloon";
                    case 2: return "2nd Balloon";
                    case 3: return "3d Balloon";
                    default: return "1st Balloon";
                }
            }
        }

        public string DisplayLastSeen
        {
            get
            {
                return LastSeen == 1 ? "Yesterday" : String.Concat(LastSeen, " days ago");
            }
        }

        public List<SelectListItem> AvailableEvents
        {
            get
            {
                List<SelectListItem> eventsSelect = new List<SelectListItem>();

                eventsSelect.Add(new SelectListItem() { Text = "Checkup", Value = "0" });
                
                if (Status < 1)
                    eventsSelect.Add(new SelectListItem() { Text = "1st Balloon", Value = "1" });

                if (Status < 2)
                    eventsSelect.Add(new SelectListItem() { Text = "2nd Balloon", Value = "2" });

                if (Status < 3)
                    eventsSelect.Add(new SelectListItem() { Text = "3rd Balloon", Value = "3" });
               
                return eventsSelect;
            }
        }

        #region Dummies
        public static List<PatientModel> GetAll(int docId = 0)
        {
            return Dummies;
        }

        static List<PatientModel> Dummies
        {
            get
            {
                List<PatientModel> models = new List<PatientModel>();
                models.Add(new PatientModel
                {
                    Id = 987534,
                    Gender = "M",
                    Age = 27,
                    HeightFt = 5,
                    HeightIn = 11,
                    BMIChange = -2,
                    LastSeen = 2,
                    WeightLoss = 12,
                    Status = 1,
                    TotalBodyLoss = 12
                });
                models.Add(new PatientModel
                {
                    Id = 987514,
                    Gender = "F",
                    Age = 17,
                    HeightFt = 5,
                    HeightIn = 11,
                    BMIChange = -7,
                    LastSeen = 7,
                    WeightLoss = 5,
                    Status = 2,
                    TotalBodyLoss = 17
                });
                models.Add(new PatientModel
                {
                    Id = 987527,
                    Gender = "F",
                    Age = 32,
                    HeightFt = 5,
                    HeightIn = 11,
                    BMIChange = 2,
                    LastSeen = 5,
                    WeightLoss = -7,
                    Status = 1,
                    TotalBodyLoss = 2
                });
                models.Add(new PatientModel
                {
                    Id = 987599,
                    Gender = "M",
                    Age = 24,
                    HeightFt = 5,
                    HeightIn = 11,
                    BMIChange = -7,
                    LastSeen = 5,
                    WeightLoss = 12,
                    Status = 1,
                    TotalBodyLoss = 12
                });
                models.Add(new PatientModel
                {
                    Id = 987932,
                    Gender = "M",
                    Age = 99,
                    HeightFt = 5,
                    HeightIn = 11,
                    BMIChange = -2,
                    LastSeen = 3,
                    WeightLoss = 1,
                    Status = 2,
                    TotalBodyLoss = 9
                });
                models.Add(new PatientModel
                {
                    Id = 987344,
                    Gender = "M",
                    Age = 101,
                    HeightFt = 5,
                    HeightIn = 11,
                    BMIChange = -2,
                    LastSeen = 12,
                    WeightLoss = 0,
                    Status = 3,
                    TotalBodyLoss = 22
                });

                return models;
            }
        }

        public static PatientModel Dummy
        {
            get
            {
                return new PatientModel
                {
                    Id = 987534,
                    Gender = "M",
                    Age = 27,
                    HeightFt = 5,
                    HeightIn = 11,
                    BMIChange = -2,
                    LastSeen = 2,
                    WeightLoss = 12,
                    Status = 1,
                    TotalBodyLoss = 12
                };
            }
        }

        #endregion
    }
}