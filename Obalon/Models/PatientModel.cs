using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public int BMI { get; set; }



        #endregion

        public static List<PatientModel> GetAll(int docId)
        {
            return Dummies;
        }

        static List<PatientModel> Dummies
        {
            get
            {
                List<PatientModel> models = new List<PatientModel>();
                models.Add(new PatientModel { Id = 987534, Gender = "M", Age = 17, HeightFt = 5, HeightIn = 11 });
                models.Add(new PatientModel { Id = 987514, Gender = "M", Age = 17, HeightFt = 5, HeightIn = 11 });
                models.Add(new PatientModel { Id = 987527, Gender = "M", Age = 17, HeightFt = 5, HeightIn = 11 });
                models.Add(new PatientModel { Id = 987599, Gender = "M", Age = 17, HeightFt = 5, HeightIn = 11 });
                models.Add(new PatientModel { Id = 987932, Gender = "M", Age = 17, HeightFt = 5, HeightIn = 11 });
                models.Add(new PatientModel { Id = 987344, Gender = "M", Age = 17, HeightFt = 5, HeightIn = 11 });

                return models;
            }
        }
    }
}