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
        ResponseItemList<Patient> GetPatients(int doctorId);

        ResponseItemList<Patient> SearchPatients(); // tb si niste criterii : .. evenimente ?

        ResponseItem<Patient> GetPatient(int pacientId);
        
        string Test();
    }

    public class PatientService : IPatientService
    {
        public PatientService()
        {

        }



        public ResponseItemList<Patient> GetPatients(int doctorId)
        {
            ResponseItemList<Patient> returnValue = null;

            try
            {

            }
            catch (Exception ex)
            {
                //logger.Error("Error while calling GetPatients", ex);
            }

            return returnValue;
        }

        public ResponseItem<Patient> GetPatient(int pacientId)
        {
            ResponseItem<Patient> returnValue = null;

            try
            {

            }
            catch (Exception ex)
            {
                //logger.Error("Error while calling GetPatient", ex);
            }

            return returnValue;
        }
        
        
        public ResponseItemList<Patient> SearchPatients()
        {
            ResponseItemList<Patient> returnValue = null;

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
