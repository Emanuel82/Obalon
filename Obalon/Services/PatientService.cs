using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Obalon.Models;
using Obalon.Utils;

namespace Obalon.Services
{

    public interface IPatientService
    {
        ResponseItemList<PatientModel> GetPatients(int doctorId);

        ResponseItemList<PatientModel> SearchPatients(); // tb si niste criterii : .. evenimente ?

        ResponseItem<PatientModel> GetPatient(int pacientId);
        
        string Test();
    }

    public class PatientService : IPatientService
    {
        public PatientService()
        {

        }



        public ResponseItemList<PatientModel> GetPatients(int doctorId)
        {
            ResponseItemList<PatientModel> returnValue = null;

            try
            {

            }
            catch (Exception ex)
            {
                //logger.Error("Error while calling GetPatients", ex);
            }

            return returnValue;
        }

        public ResponseItem<PatientModel> GetPatient(int pacientId)
        {
            ResponseItem<PatientModel> returnValue = null;

            try
            {

            }
            catch (Exception ex)
            {
                //logger.Error("Error while calling GetPatient", ex);
            }

            return returnValue;
        }
        
        
        public ResponseItemList<PatientModel> SearchPatients()
        {
            ResponseItemList<PatientModel> returnValue = null;

            try
            {

            }
            catch (Exception ex)
            {
                //logger.Error("Error while calling SearchPacients", ex);
            }

            return returnValue;
        }

        public string Test()
        {
            return "aloha";
        }
    }
}
